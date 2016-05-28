using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkenstone.Classes.Cuda
{
    unsafe class Pack32
    {
        public int[] links_in;
        public int* p_links_in;


        public int[] links_out;
        public int* p_links_out;


        public int[] ids;
        public int* p_ids;


        public int[] layers;
        public int* p_layers;


        public float[] a;
        public float* p_a;

        public float[] e;
        public float* p_e;

        public float[] t;
        public float* p_t;


        public float** weights;
        public List<float[,]> w = new List<float[,]>();


        public int dev_mem;

        public int current; //номер текущего слоя
        public Pack32(ref Network N, ref List<Link> L, ref Size picSize, int layer)
        {
            //n = layer number without output layer (from right to left)
            //не подавать последний
            ids = IDS(ref N, ref L, layer);
            dev_mem = ids.Count() * picSize.Width * picSize.Height * sizeof(float)
                + (links_in.Count() * sizeof(int))
                + (links_out.Count() * sizeof(int))
                + (ids.Count() * sizeof(int))
                + (layers.Count() * sizeof(int))
                + (e.Count() * sizeof(int))
                + (t.Count() * sizeof(int))
                + (a.Count() * sizeof(int)) + 4 * 5 //w, h, neurons, speed, links
                ; // 4 константы используются

            fixed (int* pp_links_in = links_in)
            {
                this.p_links_in = pp_links_in;
            }

            fixed (int* pp_links_out = links_out)
            {
                this.p_links_out = pp_links_out;
            }

            fixed (int* pp_ids = ids)
            {
                this.p_ids = pp_ids;
            }

            fixed (int* pp_layers = layers)
            {
                this.p_layers = pp_layers;
            }

            fixed (float* pp_a = a)
            {
                this.p_a = pp_a;
            }

            fixed (float* pp_e = e)
            {
                this.p_e = pp_e;
            }

            fixed (float* pp_t = t)
            {
                this.p_t = pp_t;
            }
        }

        int[] IDS(ref Network net, ref List<Link> L, int layer)
        {//для нулевого
            List<int> list = new List<int>();
            List<int> l_in = new List<int>();
            List<int> l_out = new List<int>();
            List<float> a_values = new List<float>();
            List<float> e_values = new List<float>();
            List<float> t_values = new List<float>();
            List<float> l_ers = new List<float>();
            List<int> lrs = new List<int>();

           current = net.Layers[layer].LayerNumber;

            foreach(Neuron outNeuron in net.Layers[0].Neurons)
            {
                if(1 - outNeuron.a>0.01)
                {
                    foreach(Neuron hidNeuron in net.Layers[current].Neurons)
                    {
                        if(IsLinkedGlobal(hidNeuron.id, outNeuron.id, ref L))
                        {
                            foreach(Neuron prevNeuron in net.Layers[current+1].Neurons)
                            {
                                if(IsLinkedLocal(prevNeuron.id,hidNeuron.id, ref L))
                                {
                                    l_out.Add(prevNeuron.id);
                                    l_in.Add(hidNeuron.id);

                                     if (!list.Contains(hidNeuron.id))
                                     {
                                         list.Add(hidNeuron.id);
                                         w.Add(hidNeuron.weight);
                                         l_ers.Add(hidNeuron.error);
                                         lrs.Add(net.Layers[current].LayerNumber);
                                         a_values.Add(hidNeuron.a);
                                         e_values.Add(hidNeuron.error);
                                         t_values.Add(hidNeuron.threshold);
                                     }

                                     list.Add(prevNeuron.id);
                                     w.Add(prevNeuron.weight);
                                     l_ers.Add(prevNeuron.error);
                                     lrs.Add(net.Layers[current+1].LayerNumber);
                                     a_values.Add(prevNeuron.a);
                                     e_values.Add(prevNeuron.error);
                                     t_values.Add(prevNeuron.threshold);
                                }
                            }
                        }
                    }
                }
            }
           //foreach (var neuron in net.Layers[layer].Neurons)
           //{
           //    if (1 - neuron.a > 0.01)
           //    {
           //        foreach (var neuron2 in net.Layers[layer+1].Neurons)
           //        {
           //            if (IsLinkedLocal(neuron2.id, neuron.id, ref L))
           //            {
           //                list.Add(neuron2.id);
           //                w.Add(neuron2.weight);
           //                l_ers.Add(neuron2.error);
           //                lrs.Add(net.Layers[1].LayerNumber);
           //                a_values.Add(neuron2.a);
           //                e_values.Add(neuron2.error);
           //                t_values.Add(neuron2.threshold);

           //                if (!list.Contains(neuron2.id))
           //                {
           //                    list.Add(neuron.id);
           //                    w.Add(neuron.weight);
           //                    l_ers.Add(neuron.error);
           //                    //l_in.Add(neuron2.id);
           //                    lrs.Add(net.Layers[0].LayerNumber);
           //                    a_values.Add(neuron.a);
           //                    e_values.Add(neuron.error);
           //                    t_values.Add(neuron.threshold);
           //                }

           //                l_out.Add(neuron2.id);
           //                l_in.Add(neuron.id);
           //                // l_in.Add(neuron2.id);
           //            }
           //        }
           //    }
           //}

           links_out = l_out.ToArray();
           links_in = l_in.ToArray();
           layers = lrs.ToArray();
           a = a_values.ToArray();
           e = e_values.ToArray();
           t = t_values.ToArray();
           

            return list.ToArray();
        }

        private bool IsLinkedGlobal(int firstNeuron, int lastNeuron, ref List<Link> links)
        {
            int first = firstNeuron;
            bool linked = false;
            bool flag = false;
            while (!linked && !flag)
            {
                foreach (var link in links.Where(link => link.id_out == first))
                {
                    if (link.id_in == lastNeuron)
                    {
                        linked = true;
                    }
                    else
                    {
                        first = link.id_in;
                    }

                }
                if (links.Where(link => link.id_out == first).ToList().Count < 1)
                    flag = true;

            }
            return linked;

        }

        private bool IsLinkedLocal(int firstNeuron, int lastNeuron, ref List<Link> links)
        {
            int first = firstNeuron;
            bool linked = false;

            foreach (var link in links.Where(link => link.id_out == first).Where(link => link.id_in == lastNeuron))
            {
                linked = true;
            }


            return linked;
        }
    }
}

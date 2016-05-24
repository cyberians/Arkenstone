using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arkenstone.Classes;

namespace Arkenstone.Classes.Cuda
{
    unsafe class Pack1
    {//run_network_new
        public int[] links_in;
        public int* p_links_in;


        public int[] links_out;
        public int* p_links_out;


        public int[] ids;
        public int* p_ids;


        public int[] layers;
        public int* p_layers;

        public int[] facts;
        public int* p_facts;

        public float** weights;


        public int dev_mem;
        public Pack1(ref Network N, ref List<Link> L, ref Size picSize, int n)
        {
            //n = neuron number in last layer
            ids = IDS(ref N, ref L, ref n);
            dev_mem = ids.Count() * picSize.Width * picSize.Height * sizeof(float)
                + (links_in.Count() * sizeof(int))
                + (links_out.Count() * sizeof(int))
                + (ids.Count() * sizeof(int))
                + (layers.Count() * sizeof(int))
                ;

            //    float[,] A = new float[,]{
            //{5, 10},
            //{20, 30},};
            //    float[,] B = new float[,]{
            //{0, 11},
            //{22, 33},};

            //    float*[] X = new float*[2];
            //    fixed (float* p = A)
            //    {
            //        X[0] = p;
            //    }
            //    fixed (float* p = B)
            //    {
            //        X[1] = p;
            //    }

            //    fixed (float **weights = X)
            //    {
            //        this.weights = weights;
            //    }



            fixed (int* p_links_in = links_in)
            {
                this.p_links_in = p_links_in;
            }

            fixed (int* p_links_out = links_out)
            {
                this.p_links_out = p_links_out;
            }

            fixed (int* p_ids = ids)
            {
                this.p_ids = p_ids;
            }

            fixed (int* p_layers = layers)
            {
                this.p_layers = p_layers;
            }

            fixed (int* p_facts = facts)
            {
                this.p_facts = p_facts;
            }
        }


        int[] IDS(ref Network net, ref List<Link> L, ref int number)
        {
            List<int> list = new List<int>();
            List<int> l_in = new List<int>();
            List<int> l_out = new List<int>();
            List<int> lrs = new List<int>();
            List<float[,]> w = new List<float[,]>();
            List<int> acts = new List<int>();


            list.Add(net.Layers[0].Neurons[number].id);
            lrs.Add(net.Layers[0].LayerNumber);
            w.Add(net.Layers[0].Neurons[number].weight);
            acts.Add(net.Layers[0].Neurons[number].func_idx);


            foreach (var layer in net.Layers.Where(l => l.Name != "Output"))
            {
                foreach (var neuron in layer.Neurons)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (IsLinkedLocal(neuron.id, list[i], ref L))
                        {
                            list.Add(neuron.id);
                            l_out.Add(neuron.id);
                            l_in.Add(list[i]);

                            lrs.Add(layer.LayerNumber);

                            w.Add(neuron.weight);

                            acts.Add(neuron.func_idx);
                        }
                    }
                }
            }

            links_out = l_out.ToArray();
            links_in = l_in.ToArray();
            layers = lrs.ToArray();
            facts = acts.ToArray();
            

            int neurons = w.Count;
            float*[] X = new float*[neurons];
            for (int i = 0; i < neurons; i++)
            {
                fixed (float* p = w[i])
                {
                    X[i] = p;
                }
            }

            fixed (float** weights = X)
            {
                this.weights = weights;
            }

            return list.ToArray();
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arkenstone.Classes;

namespace Arkenstone.Classes.Cuda
{
    unsafe public class Pack1
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

        public float[] a;
        public float* p_a;

        public float[] t;
        public float* p_t;

        public float **weights;
        public List<float[,]> w = new List<float[,]>();

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
                + (facts.Count() * sizeof(int))
                + (a.Count() * sizeof(int))
                + (t.Count() * sizeof(int)) + 4*3
                ;



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

            fixed (float* pp_t = t)
            {
                this.p_t = pp_t;
            }

            fixed (int* pp_facts = facts)
            {
                this.p_facts = pp_facts;
            }

            
        }


        public int[] IDS(ref Network net, ref List<Link> L, ref int number)
        {
            List<int> list = new List<int>();
            List<int> l_in = new List<int>();
            List<int> l_out = new List<int>();
            List<int> lrs = new List<int>();
            //List<float[,]> w = new List<float[,]>();
            List<int> acts = new List<int>();
            List<float> a_values = new List<float>();
            List<float> t_values = new List<float>();


            list.Add(net.Layers[0].Neurons[number].id);
            lrs.Add(net.Layers[0].LayerNumber);
            w.Add(net.Layers[0].Neurons[number].weight);
            acts.Add(net.Layers[0].Neurons[number].func_idx);
            a_values.Add(net.Layers[0].Neurons[number].a);
            t_values.Add(net.Layers[0].Neurons[number].threshold);

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
                            a_values.Add(neuron.a);
                            t_values.Add(neuron.threshold);
                        }
                    }
                }
            }

            links_out = l_out.ToArray();
            links_in = l_in.ToArray();
            layers = lrs.ToArray();
            facts = acts.ToArray();
            a = a_values.ToArray();
            t = t_values.ToArray();
            

         

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

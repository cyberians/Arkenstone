using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkenstone.Classes.Cuda
{
    unsafe class Pack2
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


        public float** weights;
        public List<float[,]> w = new List<float[,]>();


        public int dev_mem;

        public int current; //номер текущего слоя
        public Pack2(ref Network N, ref List<Link> L, ref Size picSize, int n)
        {
            //n = layer number without output layer (from right to left)
            ids = IDS(ref N, ref L, ref n);
            dev_mem = ids.Count() * picSize.Width * picSize.Height * sizeof(float)
                + (links_in.Count() * sizeof(int))
                + (links_out.Count() * sizeof(int))
                + (ids.Count() * sizeof(int))
                + (layers.Count() * sizeof(int))
                + (a.Count() * sizeof(int)) + 4 * 4
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
        }

        int[] IDS(ref Network net, ref List<Link> L, ref int number)
        {//number>0
            List<int> list = new List<int>();
            List<int> l_in = new List<int>();
            List<int> l_out = new List<int>();
            List<float> a_values = new List<float>();
            List<float> e_values = new List<float>();
            List<float> l_ers = new List<float>();
            List<int> lrs = new List<int>();

           current = net.Layers[number].LayerNumber;
           foreach(var neuron in net.Layers[number].Neurons)
           {
               foreach (var neuron2 in net.Layers[number-1].Neurons)
               {
                   if(IsLinkedLocal(neuron.id,neuron2.id,ref L))
                   {
                       list.Add(neuron.id);
                       w.Add(neuron.weight);
                       l_ers.Add(neuron.error);
                       lrs.Add(net.Layers[number].LayerNumber);
                       a_values.Add(neuron.a);
                       e_values.Add(neuron.error);

                       if (!list.Contains(neuron2.id))
                       {
                           list.Add(neuron2.id);
                           w.Add(neuron2.weight);
                           l_ers.Add(neuron2.error);
                           //l_in.Add(neuron2.id);
                           lrs.Add(net.Layers[number-1].LayerNumber);
                           a_values.Add(neuron2.a);
                           e_values.Add(neuron2.error);
                       }

                       l_out.Add(neuron.id);
                       l_in.Add(neuron2.id);
                      // l_in.Add(neuron2.id);
                   }
               }
           }

           links_out = l_out.ToArray();
           links_in = l_in.ToArray();
           layers = lrs.ToArray();
           a = a_values.ToArray();
           e = e_values.ToArray();

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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkenstone.Classes.Cuda
{
    class Pack2
    {
        int[] links_in;
        int[] links_out;
        float[] a;
        float[] errors;
        int[] ids; //left layer
        int[] ids2; //right layer
        IntPtr[] weights;
        int dev_mem;
        public Pack2(ref Network N, ref List<Link> L, ref Size picSize, int n)
        {
            //n = layer number without output layer (from right to left)
            ids = IDS(ref N, ref L, ref n);
            dev_mem = ids.Count() * picSize.Width * picSize.Height * sizeof(float);
        }

        int[] IDS(ref Network net, ref List<Link> L, ref int number)
        {//number>0
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();//ids2
            List<int> l_in = new List<int>();
            List<int> l_out = new List<int>();
            List<float> l_a = new List<float>();
            List<float> l_ers = new List<float>();

           foreach(var neuron in net.Layers[number].Neurons)
           {
               foreach (var neuron2 in net.Layers[number-1].Neurons)
               {
                   if(IsLinkedLocal(neuron.id,neuron2.id,ref L))
                   {
                       list.Add(neuron.id);

                       if (!list2.Contains(neuron2.id))
                       {
                           list2.Add(neuron2.id);
                           l_ers.Add((float)neuron2.error);
                       }

                       l_out.Add(neuron.id);
                       l_in.Add(neuron2.id);

                       l_a.Add((float)neuron.a);
                       //ранее подсчитаны в оутпут методе (вне куды)
                   }
               }
           }

            links_out = l_out.ToArray();
            links_in = l_in.ToArray();

            ids2 = list2.ToArray();

            a = l_a.ToArray();
            errors = l_ers.ToArray();

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

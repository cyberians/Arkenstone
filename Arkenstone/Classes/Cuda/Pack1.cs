using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arkenstone.Classes;

namespace Arkenstone.Classes.Cuda
{
    class Pack1
    {//run_network_new
        int[] links_in;
        int[] links_out;
        int[] ids;
        IntPtr[] weights;
        int dev_mem;
        public Pack1(ref Network N, ref List<Link> L, ref Size picSize, int n)
        {
            //n = neuron number in last layer
            ids = IDS(ref N, ref L, ref n);
            dev_mem = ids.Count() * picSize.Width * picSize.Height * sizeof(float);
        }


        int [] IDS (ref Network net, ref List<Link> L, ref int number)
        {
            List<int> list = new List<int>();
            List<int> l_in = new List<int>();
            List<int> l_out = new List<int>();

            list.Add(net.Layers[0].Neurons[number].id);
              
            foreach(var layer in net.Layers.Where(l => l.Name != "Output"))
            {
                foreach(var neuron in layer.Neurons)
                {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (IsLinkedLocal(neuron.id, list[i], ref L))
                            {
                                list.Add(neuron.id);
                                l_out.Add(neuron.id);
                                l_in.Add(list[i]);
                            }
                        }
                }
            }

            links_out = l_out.ToArray();
            links_in = l_in.ToArray();
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

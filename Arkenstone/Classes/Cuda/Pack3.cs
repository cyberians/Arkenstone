using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkenstone.Classes.Cuda
{
    class Pack3
    {
        int[] links_in;
        int[] links_out;
        float[] errors;//текущий
        float[] threshold;//текущий
        float[] a;//левый

        int[] ids; //right layer
        int[] ids2; //left layer

        float[] errors2;//последний
        float[] threshold2;//последний

        IntPtr[] weights;//для обоих
        int dev_mem;
        public Pack3(ref Network N, ref List<Link> L, ref Size picSize, int n, int last)
        {
            List<int> l_in = new List<int>();
            List<int> l_out = new List<int>();

            List<int> list = new List<int>();
            List<int> list2 = new List<int>();//ids2
            List<float> l_ers = new List<float>();
            List<float> l_thr = new List<float>();
            List<float> l_a = new List<float>();


            List<float> l_ers2 = new List<float>();//last
            List<float> l_thr2 = new List<float>();//last

            //n начиная с нулевого (номер слоя) нельзя подавать на вход последний
            foreach (var neuron in N.Layers[n].Neurons)
            {
                    foreach (var leftneuron in N.Layers[n + 1].Neurons)
                    {
                        if (IsLinkedLocal(leftneuron.id, neuron.id, ref L) && 1 - neuron.a > 0.01)
                        {
                            if (!list.Contains(neuron.id))
                            {
                                list.Add(neuron.id);
                                l_ers.Add((float)neuron.error);
                                l_thr.Add((float)neuron.threshold);
                            }

                            list2.Add(leftneuron.id);
                            l_a.Add((float)leftneuron.a);

                            if (n == last - 1)
                            {
                                l_ers2.Add((float)leftneuron.error);
                                l_ers2.Add((float)leftneuron.threshold);
                            }

                            l_out.Add(leftneuron.id);
                            l_in.Add(neuron.id);
                        }
                    }
            }

            links_in = l_in.ToArray();
            links_out = l_out.ToArray();

            errors = l_ers.ToArray();//текущий
            threshold = l_thr.ToArray();//текущий
            a = l_a.ToArray();//левый

            ids = list.ToArray(); //right layer
            ids2 = list2.ToArray(); //left layer

            errors2 = l_ers2.ToArray();//последний
            threshold2 = l_thr2.ToArray();//последний

            dev_mem = ids.Count() * picSize.Width * picSize.Height * sizeof(float);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkenstone.Classes
{
    public class NetLayer
    {
        public List<Neuron> Neurons;
        public string Name;
        public static int ID = 0;
        public int LayerNumber;

        public List<double[,]> RecognizedList;

        public NetLayer(string name, List<Neuron> neurons)
        {
            Neurons = neurons;
            Name = name;
            LayerNumber = ID++;
        }

        public NetLayer()
        {
            Neurons = new List<Neuron>();
            LayerNumber = ID++;
        }
    }
}
 
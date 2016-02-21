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

        public NetLayer(string name, List<Neuron> neurons)
        {
            Neurons = neurons;
            Name = name;
        }
    }
}

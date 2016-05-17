using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkenstone.Classes
{
    class Class1
    {
        public void update_output_weights()
        {
            for (int index = 0; index < network.Layers[0].Neurons.Count; index++)
            {
                var outNeuron = network.Layers[0].Neurons[index];
                if (limit_out - outNeuron.a > 0.01)
                {
                    for (int i = 0; i < network.Layers[1].Neurons.Count; i++)
                    {
                        var hidNeuron = network.Layers[1].Neurons[i];
                        if (IsLinkedLocal(hidNeuron.id, outNeuron.id))
                        {
                            for (int x = 0; x < 64; x++)
                            {
                                for (int y = 0; y < 64; y++)
                                {
                                    if (outNeuron.weight[x, y] > 0)
                                        outNeuron.weight[x, y] += hidNeuron.weight[x, y] +
                                                                  speed * outNeuron.error * hidNeuron.a;
                                }
                            }
                        }
                    }
                    outNeuron.threshold = outNeuron.threshold - speed * outNeuron.error;
                }
            }
        }

        public void update_hidden_weights()
        {
            
            for (int index = 0; index < network.Layers[0].Neurons.Count; index++)
            {
                var outNeuron = network.Layers[0].Neurons[index];
                if (limit_out - outNeuron.a > 0.01)
                {
                    

                    for (int i = 0; i < network.Layers[1].Neurons.Count; i++)
                    {
                        var neuron = network.Layers[1].Neurons[i];
                        if (IsLinkedLocal(neuron.id, outNeuron.id))
                        {
                            
                            for (int index1 = 0; index1 < network.Layers[2].Neurons.Count; index1++)
                            {
                                var prevNeuron = network.Layers[2].Neurons[index1];
                                if (IsLinkedLocal(prevNeuron.id, neuron.id))
                                {
                                    for (var x = 0; x < 64; x++)
                                    {
                                        for (var y = 0; y < 64; y++)
                                        {
                                            if (neuron.weight[x, y] > 0)
                                                neuron.weight[x, y] += prevNeuron.weight[x, y] +
                                                                       speed * neuron.error * prevNeuron.a;
                                        }
                                    }
                                }
                            }
                            
                            neuron.threshold = neuron.threshold - speed * neuron.error;
                        }
                    }

                   
                }
            }
            
        }

        public void update_FIRST_hidden_layer_weights()
        {
           
            for (int index = 0; index < network.Layers[0].Neurons.Count; index++)
            {
                var outNeuron = network.Layers[0].Neurons[index];
                if (limit_out - outNeuron.a > 0.01)
                {
                    
                    for (int i = 0; i < network.Layers[2].Neurons.Count; i++)
                    {
                        var inputNeuron = network.Layers[2].Neurons[i];
                        if (IsLinkedGlobal(inputNeuron.id, outNeuron.id))
                        {
                            for (var x = 0; x < 64; x++)
                            {
                                for (var y = 0; y < 64; y++)
                                {
                                    if (inputNeuron.weight[x, y] > 0)
                                        inputNeuron.weight[x, y] = inputNeuron.weight[x, y] + speed * inputNeuron.error;
                                }
                            }
                            inputNeuron.threshold = inputNeuron.threshold - speed * inputNeuron.error;
                        }
                    }
                    
                }
            }
            
        }
    }
}

/* 
public void update_hidden1_weights()
        {
            for (int o = 0; o < output_layer.Count<Neuron>(); o++)
            {
                if (limit_out - output_layer[o].a > 0.01)
                {
                    for (int h = 0; h < hid2_layer.Count<Neuron>(); h++)
                    {
                        if (connectOut[o].Contains(Convert.ToInt32(h + 1)))
                        {
                            for (int i = 0; i < hid1_layer.Count<Neuron>(); i++)
                            {
                                if (connect[h].Contains(Convert.ToInt32(i + 1)))
                                {
                                    for (int j = 0; j < input_signal.Count<double[,]>(); j++)
                                    {
                                        if (connectInp[j].Contains(Convert.ToInt32(i + 1)))
                                        {
                                            for (int x = 0; x < 64; x++)
                                            {
                                                for (int y = 0; y < 64; y++)
                                                {
                                                    if (hid1_layer[i].weight[x, y] != 0.0)
                                                    {
                                                        hid1_layer[i].weight[x, y] = hid1_layer[i].weight[x, y] +
                                                                                     speed*hid1_layer[i].error*
                                                                                     input_signal[j][x, y];
                                                    }
                                                }
                                            }
                                            hid1_layer[i].threshold = hid1_layer[i].threshold -
                                                                      speed*hid1_layer[i].error;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void update_hidden2_weights2()
        {
            Random r = new Random();
            for (int o = 0; o < output_layer.Count<Neuron>(); o++)
            {
                if (limit_out - output_layer[o].a > 0.01)
                {
                    for (int i = 0; i < hid2_layer.Count<Neuron>(); i++)
                    {
                        if (connectOut[o].Contains(Convert.ToInt32(i + 1)))
                        {
                            for (int j = 0; j < hid1_layer.Count<Neuron>(); j++)
                            {
                                if (connect[i].Contains(Convert.ToInt32(j + 1)))
                                {
                                    for (int x = 0; x < 64; x++)
                                    {
                                        for (int y = 0; y < 64; y++)
                                        {
                                            if (hid2_layer[i].weight[x, y] != 0.0)
                                            {
                                                hid2_layer[i].weight[x, y] += hid1_layer[j].weight[x, y] +
                                                                              speed*hid2_layer[i].error*hid1_layer[j].a;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        hid2_layer[i].threshold = hid2_layer[i].threshold - speed*hid2_layer[i].error;
                    }
                }
            }
        }

        public void update_output_weights2()
        {
            Random r = new Random();
            for (int i = 0; i < output_layer.Count<Neuron>(); i++)
            {
                if (limit_out - output_layer[i].a > 0.01)
                {
                    for (int j = 0; j < hid2_layer.Count<Neuron>(); j++)
                    {
                        if (connectOut[i].Contains(Convert.ToInt32(j + 1)))
                        {
                            for (int x = 0; x < 64; x++)
                            {
                                for (int y = 0; y < 64; y++)
                                {
                                    if (output_layer[i].weight[x, y] != 0.0)
                                    {
                                        output_layer[i].weight[x, y] += hid2_layer[j].weight[x, y] +
                                                                        speed*output_layer[i].error*hid2_layer[j].a;
                                    }
                                }
                            }
                        }
                    }
                    output_layer[i].threshold = output_layer[i].threshold - speed*output_layer[i].error;
                }
            }
        }

 

 * 
 * 
 * 
 * 
            foreach (var neuron in network.Layers[network.Layers.Count-1].Neurons)
            {
                foreach (var outNeuron in network.Layers[0].Neurons)
                {
                    if (IsLinkedGlobal(neuron.id, outNeuron.id))
                    {
                        for (int x = 0; x < neuron.weight.GetLength(0); x++)
                        {
                            for (int y = 0; y < neuron.weight.GetLength(1); y++)
                            {
                                neuron.weight[x, y] = neuron.weight[x, y] + speed * neuron.error;
                            }
                        }
                        neuron.threshold = neuron.threshold - speed * neuron.error;
                    }
                }
            }

            foreach (var layer in network.Layers.OrderByDescending(x => x.LayerNumber).Where(layer => layer.Name != "Enter"))
            {
                foreach (var neuron in layer.Neurons)
                {
                    foreach (var prevNeuron in network.Layers.First(x => x.LayerNumber - 1 == layer.LayerNumber).Neurons)
                    {
                        if (IsLinkedGlobal(prevNeuron.id, neuron.id))
                        {
                            for (int x = 0; x < neuron.weight.GetLength(0); x++)
                            {
                                for (int y = 0; y < neuron.weight.GetLength(1); y++)
                                {
                                    neuron.weight[x, y] = prevNeuron.weight[x, y] + speed*neuron.error*prevNeuron.a;
                                }
                            }
                            neuron.threshold = neuron.threshold - speed*neuron.error;
                        }
                    }
                }
               
            }
*/




/*



 public void calculate_output_layer_errors()
        {
            for (int i = 0; i < output_layer.Count<Neuron>(); i++)
            {
                output_layer[i].error = (limit_out - output_layer[i].a)*output_layer[i].a*(1.0 - output_layer[i].a);
            }
        }

        public void calculate_hidden_layer2_errors()
        {
            for (int i = 0; i < hid2_layer.Count<Neuron>(); i++)
            {
                double sum = 0.0;
                for (int j = 0; j < output_layer.Count<Neuron>(); j++)
                {
                    if (connectOut[j].Contains(Convert.ToInt32(i + 1)))
                    {
                        for (int x = 0; x < 64; x++)
                        {
                            for (int y = 0; y < 64; y++)
                            {
                                sum += output_layer[j].error*hid2_layer[i].weight[x, y];
                            }
                        }
                    }
                }
                hid2_layer[i].error = hid2_layer[i].a*(1.0 - hid2_layer[i].a)*sum;
            }
        }

        public void calculate_hidden_layer1_errors()
        {
            for (int i = 0; i < hid1_layer.Count<Neuron>(); i++)
            {
                double sum = 0.0;
                for (int j = 0; j < hid2_layer.Count<Neuron>(); j++)
                {
                    if (connect[j].Contains(Convert.ToInt32(i + 1)))
                    {
                        for (int x = 0; x < 64; x++)
                        {
                            for (int y = 0; y < 64; y++)
                            {
                                sum += hid2_layer[j].error*hid1_layer[i].weight[x, y];
                            }
                        }
                    }
                }
                hid1_layer[i].error = hid1_layer[i].a*(1.0 - hid1_layer[i].a)*sum;
            }
        }


*/
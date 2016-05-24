using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dataweb.NShape;
using Dataweb.NShape.GeneralShapes;
using Dataweb.NShape.WinFormsUI;
using Arkenstone.Classes;
using Dataweb.NShape.Advanced;
using System.Runtime.InteropServices;
using Arkenstone.Classes.Cuda;

namespace Arkenstone
{
    public partial class Form1 : Form
    {
        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)] //cuda
        public static extern bool check_connection();//cuda

        public bool enable_CUDA;

        public int dev_index = -1; // card index for Cuda
        public float cl_mem; //memory Cuda limit
        public Point cl_txt; //texture Cuda limit
        public Point cl_grd; //grid(X,Y) Cuda limit

        public Cuda.Cuda cu;

        public Form1()
        {
            InitializeComponent();
            enable_CUDA = false;
            cu = new Cuda.Cuda(this);
            
            cu.Hide();
        }

        Size picSize = new Size(64, 64);

        Diagram diagram;

        Bitmap bm1;
        Bitmap bm2;
        Bitmap bm3;

        Bitmap bm_test = new Bitmap(64, 64);

        List<char> alphabet = new List<char>();

        List<double> recognize_sigm_out = new List<double>();

        List<double[,]> input_signal = new List<double[,]>();
        List<Link> links = new List<Link>();

        double[,] input = new double[64, 64];

        double[,] enter = new double[64, 64];



        List<int> inputList = new List<int>();

        

        List<int[]> connectOut = new List<int[]>()
        {
            new int[] {1,2},
            new int[] {3,4,5},
            new int[] {6,7,8},
            new int[] {9,10},
            new int[] {11,12},
            new int[] {13,14,15},
            new int[] {16,17,18},
            new int[] {19,20,21},
            new int[] {22,23},
            new int[] {24,25,26},
            new int[] {27,28},
            new int[] {29,30},
            new int[] {31,32},
            new int[] {33,34},
            new int[] {35,36},
            new int[] {37,38},
            new int[] {39,40,41},
            new int[] {42,43,44},
            new int[] {45,46},
            new int[] {47,48},
            new int[] {49,50},
            new int[] {51,52},
            new int[] {53,54},
            new int[] {55,56},
            new int[] {57,58,59},
            new int[] {60,61,62},
            new int[] {63,64},
            new int[] {65,66,67},
            new int[] {68,69},
            new int[] {70,71,72},
            new int[] {73,74,75},
            new int[] {76,77,78},
            new int[] {79,80},
            new int[] {81,82,83},
            new int[] {84,85,86},
            new int[] {87,88},
            new int[] {89,90},
            new int[] {91,92},
            new int[] {93,94,95},
            new int[] {96},
            new int[] {97,98},
            new int[] {99,100,101},
            new int[] {102,103,104},
            new int[] {105,106},
            new int[] {107,108},
            new int[] {109},
            new int[] {110,111},
            new int[] {112,113},
            new int[] {114,115},
            new int[] {116,117},
            new int[] {118},
            new int[] {119,120},
            new int[] {121,122},
            new int[] {123,124,125},
            new int[] {126,127},
            new int[] {128},
            new int[] {129,130},
            new int[] {131,132},
            new int[] {133,134},
            new int[] {135,136},
            new int[] {137,138},
            new int[] {139},
            new int[] {140,141},
            new int[] {142,143}
        };
        List<int[]> connect = new List<int[]>()
        {
            new int[] {1,2,3},
            new int[] {4,5},
            new int[] {6,7},
            new int[] {8,9},
            new int[] {10,11},
            new int[] {12,13},
            new int[] {14,15},
            new int[] {16,17},
            new int[] {18,19},
            new int[] {20},
            new int[] {21,22},
            new int[] {23,24},
            new int[] {25,26},
            new int[] {27,28},
            new int[] {29,30},
            new int[] {31,32},
            new int[] {33,34},
            new int[] {35},
            new int[] {36,37},
            new int[] {38},
            new int[] {39,40},
            new int[] {41,42},
            new int[] {43,44},
            new int[] {45},
            new int[] {46,47},
            new int[] {48,49},
            new int[] {50,51},
            new int[] {52,53,54},
            new int[] {55,56},
            new int[] {57,58},
            new int[] {59,60},
            new int[] {61,62,63},
            new int[] {64,65,66},
            new int[] {67,68,69},
            new int[] {70,71},
            new int[] {72,73},
            new int[] {74,75},
            new int[] {76,77},
            new int[] {78,79},
            new int[] {80,81},
            new int[] {82},
            new int[] {83,84},
            new int[] {85,86},
            new int[] {87,88},
            new int[] {89,90,91},
            new int[] {92},
            new int[] {93,94},
            new int[] {95,96},
            new int[] {97,98,99},
            new int[] {100,101,102},
            new int[] {103,104,105},
            new int[] {106,107},
            new int[] {108,109},
            new int[] {110,111},
            new int[] {112,113},
            new int[] {114,115,116},
            new int[] {117,118},
            new int[] {119,120},
            new int[] {121,122},
            new int[] {123,124},
            new int[] {125,126},
            new int[] {127,128},
            new int[] {129,130,131},
            new int[] {132,133},
            new int[] {134,135,136},
            new int[] {137,138},
            new int[] {139,140},
            new int[] {141,142,143},
            new int[] {144,145},
            new int[] {146,147},
            new int[] {148},
            new int[] {149,150},
            new int[] {151,152,153},
            new int[] {154,155},
            new int[] {156,157},
            new int[] {158,159},
            new int[] {160,161},
            new int[] {162,163},
            new int[] {164,165},
            new int[] {166,167,168},
            new int[] {169},
            new int[] {170,171},
            new int[] {172,173},
            new int[] {174,175},
            new int[] {176,177},
            new int[] {178,179},
            new int[] {180,181},
            new int[] {182},
            new int[] {183,184},
            new int[] {185,186},
            new int[] {187,188},
            new int[] {189,190},
            new int[] {191},
            new int[] {192,193},
            new int[] {194,195},
            new int[] {196,197,198},
            new int[] {199,200},
            new int[] {201,202},
            new int[] {203,204},
            new int[] {205,206},
            new int[] {207},
            new int[] {208,209},
            new int[] {210,211},
            new int[] {212},
            new int[] {213,214},
            new int[] {215,216},
            new int[] {217,218,219},
            new int[] {220,221},
            new int[] {222,223},
            new int[] {224,225},
            new int[] {226,227},
            new int[] {228,229},
            new int[] {230,231},
            new int[] {232,233},
            new int[] {234,235},
            new int[] {236,237},
            new int[] {238,239},
            new int[] {240,241},
            new int[] {242,243},
            new int[] {244,245},
            new int[] {246,247},
            new int[] {248,249},
            new int[] {250,251},
            new int[] {252},
            new int[] {253,254},
            new int[] {255,256},
            new int[] {257,258},
            new int[] {259,260},
            new int[] {261,262,263},
            new int[] {264,265,266},
            new int[] {267,268,269},
            new int[] {270,271,272},
            new int[] {273,274},
            new int[] {275,276},
            new int[] {277,278},
            new int[] {279,280},
            new int[] {281,282},
            new int[] {283},
            new int[] {284,285,286},
            new int[] {287,288},
            new int[] {289,290,291},
            new int[] {292},
            new int[] {293,294}

        };

        List<int[]> connectInp = new List<int[]>()
        {
            new int[] { 1,2,3,4,5 },
            new int[] {6,7,8,9,10,11},
            new int[] {12,13,14,15,16,17},
            new int[] {18,19,20},
            new int[] {21,22,23,24},
            new int[] {25,26,27,28,29,30},
            new int[] {31,32,33,34,35},
            new int[] {36,37,38,39,40},
            new int[] {41,42,43,44},
            new int[] {45,46,47,48,49},
            new int[] {50,51,52,53,54},
            new int[] {55,56,57,58},
            new int[] {59,60,61,62,63},
            new int[] {64,65,66,67,68,69},
            new int[] {70,71,72,73},
            new int[] {74,75,76,77},
            new int[] {78,79,80,81,82},
            new int[] {83,84,85,86,87,88},
            new int[] {89,90,91,92},
            new int[] {93,94,95,96},
            new int[] {97,98,99,100,101,102},
            new int[] {103,104,105,106,107},
            new int[] {108,109,110,111},
            new int[] {112,113,114,115,116},
            new int[] {117,118,119,120,121,122},
            new int[] {123,124,125,126,127,128},
            new int[] {129,130,131,132,133},
            new int[] {134,135,136,137,138,139,140},
            new int[] {141,142,143,144,145},
            new int[] {146,147,148,149,150},
            new int[] {151,152,153,154,155,156,157},
            new int[] {158,159,160,161,162,163},
            new int[] {164,165,166,167,168},
            new int[] {169,170,171,172,173},
            new int[] {174,175,176,177,178,179},
            new int[] {180,181,182},
            new int[] {183,184,185,186},
            new int[] {187,188,189,190},
            new int[] {191,192,193,194,195},
            new int[] {196,197,198},
            new int[] {199,200,201,202},
            new int[] {203,204,205,206,207},
            new int[] {208,209,210,211,212},
            new int[] {213,214,215,216},
            new int[] {217,218,219,220,221},
            new int[] {222,223},
            new int[] {224,225,226,227},
            new int[] {228,229,230,231},
            new int[] {232,233,234,235},
            new int[] {236,237,238,239},
            new int[] {240,241},
            new int[] {242,243,244,245},
            new int[] {246,247,248,249},
            new int[] {250,251,252,253,254},
            new int[] {255,256,257,258},
            new int[] {259,260},
            new int[] {261,262,263,264,265,266},
            new int[] {267,268,269,270,271,272},
            new int[] {273,274,275,276},
            new int[] {277,278,279,280},
            new int[] {281,282,283},
            new int[] {284,285,286},
            new int[] {287,288,289,290,291},
            new int[] {292,293,294}
        };

        private void Wait(int value)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < value)
                Application.DoEvents();
        }

        List<Point> coordinate = new List<Point>();
        List<Shape> firstLayerNeurons = new List<Shape>();
        List<Shape> hiddenLayerNeurons = new List<Shape>(); 

        int countgr2 = 0;
        int count = 1;
        int outGr = 0;

        double limit_out = 1.0;
        double speed = 2.0;
        double[,] submit;
        double sigma;

        Shape first_vertex;
        Shape last_vertex;

        Network network = new Network();
        Network recognizeNetwork;

        /////////////---вывод на форму
        public static int alpha_count = 1;

        public static void to_notepad(double [,] massive, int alphacount)
        {
            string app_path = Application.StartupPath;
            string path = "words";
            string word_file = Path.Combine(Application.StartupPath, path, "word-" + alphacount) + ".txt";
            string test = "";
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    
                    
                    test += massive[i, j].ToString() + Environment.NewLine;

                }
            }
            File.WriteAllText(word_file, test + Environment.NewLine);
        }
        public void to_form(double [,] massive)
        {
            string test = "";
            for (var x = 0; x < 64; x++)
            {
                for (var y = 0; y < 64; y++)
                {
                    if (massive[x, y] == 0)
                    {
                        test += massive[x, y];
                    }
                    else
                    {
                        test += 1;
                    }

                }
                test += "\n";
            }

            testForm f = new testForm
            {
                richTextBox1 =
                {
                    Text = test
                }
            };

            f.ShowDialog();
        }

        /////////////


        /////////////--------НЕЙРОСЕТЕВЫЕ АЛГОРИТМЫ



        public unsafe void run_network_new()
        {
             bool allow_cuda = true;
            if (enable_CUDA)
            {
                List<Pack1> queue = new List<Pack1>();
                for (int i = 0; i < network.Layers[0].Neurons.Count; i++)
                {
                    queue.Add(new Pack1(ref network, ref links, ref picSize, i));
                    if (queue[i].dev_mem > cl_mem &&
                        cl_txt.X < queue[i].ids.Count() && cl_txt.Y < picSize.Width * picSize.Height
                        )
                        allow_cuda = false;
                }
                if (allow_cuda)
                {
                    //dll working
                }
            }

            
            if(!enable_CUDA && !enable_CUDA)
            {
                //первый скрытый слой
                foreach (var outNeuron in network.Layers[0].Neurons)
                {
                    if (limit_out - outNeuron.a > 0.01)
                    {
                        foreach (var input_neuron in network.Layers[network.Layers.Count - 1].Neurons)
                        {
                            //Shape Line = null;
                            //var currentLine = diagram.Shapes.Where(s => s.Type.Name == "Polyline");
                            //foreach (var line in currentLine.Where(line => line.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data ==
                            //                                               input_neuron.id.ToString()))
                            //{
                            //    Line = line;
                            //}

                            //if (Line != null)
                            //{
                            //    Line.Rotate(90, 500, 200);

                            ////    for (int i = 0; i < 1000; i++)
                            ////    {
                            ////        //var arrow = (Polyline)project1.ShapeTypes["Polyline"].CreateInstance();
                            ////        //arrow.LineStyle = project1.Design.LineStyles.HighlightDashed;
                            ////        //diagram.Shapes.Add(arrow);
                            ////        //cachedRepository1.Insert((Shape)arrow, diagram);
                            ////        //arrow.Connect(ControlPointId.FirstVertex, Line.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape, ControlPointId.Reference);
                            ////        //arrow.Connect(ControlPointId.LastVertex, Line.GetConnectionInfo(ControlPointId.LastVertex, null).OtherShape, ControlPointId.Reference);
                            ////    }



                            ////    //Line.
                            //    Wait(1000);
                            //}



                            if (IsLinkedGlobal(input_neuron.id, outNeuron.id))
                            {
                                double sum = 0;
                                for (var x = 0; x < 64; x++)
                                {
                                    for (var y = 0; y < 64; y++)
                                    {
                                        sum += input_neuron.weight[x, y];
                                    }
                                }
                                //input_neuron.a = sum > input_neuron.threshold ? 1 : 0;
                                //input_neuron.a = Neuron.sigmoida(sum - input_neuron.threshold);

                                input_neuron.a = (float)(Neuron.ActivationFunction(input_neuron.func_name, sum - input_neuron.threshold, input_neuron.threshold));
                            }
                        }
                    }
                }


                //все средние слои
                foreach (var outNeuron in network.Layers[0].Neurons)
                {
                    if (limit_out - outNeuron.a > 0.01)
                    {
                        foreach (var hidLayer in network.Layers.OrderByDescending(layer => layer.LayerNumber).Where(layer => layer.Name != "Enter"))
                        {
                            //MessageBox.Show(hidLayer.Name);
                            foreach (var hidNeuron in hidLayer.Neurons.Where(hidNeuron => IsLinkedLocal(hidNeuron.id, outNeuron.id)))
                            {
                                hidNeuron.weight = new float[64, 64];
                                double sum = 0;

                                foreach (var input_neuron in from prevLayer in network.Layers.Where(layer => layer.LayerNumber == hidLayer.LayerNumber + 1) from input_neuron in prevLayer.Neurons where IsLinkedLocal(input_neuron.id, hidNeuron.id) select input_neuron)
                                {
                                    for (var x = 0; x < 64; x++)
                                    {
                                        for (var y = 0; y < 64; y++)
                                        {
                                            sum += input_neuron.weight[x, y] * input_neuron.a;
                                            hidNeuron.weight[x, y] += input_neuron.weight[x, y] * input_neuron.a;
                                        }
                                    }
                                    //to_form(hidNeuron.weight);
                                }
                                //hidNeuron.a = sum > hidNeuron.threshold ? 1 : 0;
                                //hidNeuron.a = Neuron.sigmoida(sum - hidNeuron.threshold);

                                hidNeuron.a = (float)(Neuron.ActivationFunction(hidNeuron.func_name, sum - hidNeuron.threshold, hidNeuron.threshold));
                            }
                        }
                    }

                }

                //выходной слой
                foreach (var outNeuron in network.Layers[0].Neurons)
                {
                    if (limit_out - outNeuron.a > 0.01)
                    {
                        double sum = 0;
                        outNeuron.weight = new float[64, 64];
                        foreach (var hidNeuron in network.Layers[1].Neurons.Where(hidNeuron => IsLinkedLocal(hidNeuron.id, outNeuron.id)))
                        {
                            for (int x = 0; x < 64; x++)
                            {
                                for (int y = 0; y < 64; y++)
                                {
                                    sum += hidNeuron.weight[x, y] * hidNeuron.a;
                                    outNeuron.weight[x, y] += hidNeuron.weight[x, y] * hidNeuron.a;
                                }

                            }
                            //to_form(outNeuron.weight);
                        }
                        //outNeuron.a = sum > outNeuron.threshold ? 1 : 0;
                        //outNeuron.a = Neuron.sigmoida(sum - outNeuron.threshold);

                        outNeuron.a = (float)(Neuron.ActivationFunction(outNeuron.func_name, sum - outNeuron.threshold, outNeuron.threshold));
                    }
                }
            }
            else
            {
                //Pack1 p1 = new Pack1(ref network, ref links, ref picSize, 1);
                //int* links_in;
                //int* links_out;
            }
        }

        public void calculate_output_layer_errors_new()
        {
            foreach (var neuron in network.Layers[0].Neurons)
                neuron.error = (float)((limit_out - neuron.a) * neuron.a * (1 - neuron.a));
        }


        public void calculate_hidden_layers_errors()
        {
            if (!enable_CUDA)
            {
                foreach (var layer in network.Layers.Where(l => l.Name != "Output"))
                {
                    foreach (var neuron in layer.Neurons)
                    {
                        double sum = 0;
                        foreach (var outNeuron in from outputLayer in network.Layers.Where(l => l.LayerNumber == layer.LayerNumber - 1) from outNeuron in outputLayer.Neurons where IsLinkedLocal(neuron.id, outNeuron.id) select outNeuron)
                        {
                            for (var x = 0; x < 64; x++)
                            {
                                for (var y = 0; y < 64; y++)
                                {
                                    sum += outNeuron.error * neuron.weight[x, y];
                                }
                            }
                        }
                        neuron.error = (float)(neuron.a * (1 - neuron.a) * sum);
                    }
                }
            }
            else
            {
                Pack2 p2 = new Pack2(ref network, ref links, ref picSize, 1);
                //
            }
        }


        public void update_output_weights()
        {
            Pack3 p3 = new Pack3(ref network, ref links, ref picSize, 0,2);//не подавать последний

            foreach (var outNeuron in network.Layers[0].Neurons.Where(outNeuron => limit_out - outNeuron.a > 0.01))
            {
                foreach (var hidNeuron in network.Layers[1].Neurons.Where(hidNeuron => IsLinkedLocal(hidNeuron.id, outNeuron.id)))
                {
                    for (int x = 0; x < 64; x++)
                    {
                        for (int y = 0; y < 64; y++)
                        {
                            if (outNeuron.weight[x, y] > 0)
                                outNeuron.weight[x, y] += (float)(hidNeuron.weight[x, y] + speed * outNeuron.error * hidNeuron.a);
                        }
                    }
                }
                outNeuron.threshold = (float)(outNeuron.threshold - speed * outNeuron.error);
            }
        }

        public void update_hidden_weights()
        {
            
            foreach (var outNeuron in network.Layers[0].Neurons)
            {
                if (limit_out - outNeuron.a > 0.01)
                {
                    foreach (var layer in network.Layers.Where(layer => layer.Name != "Output"))
                    { 
                        foreach (var neuron in layer.Neurons.Where(neuron => IsLinkedLocal(neuron.id, outNeuron.id)))
                        {
                            foreach (var prevNeuron in from prevLayer in network.Layers.Where(x => x.LayerNumber - 1 == layer.LayerNumber) from prevNeuron in prevLayer.Neurons where IsLinkedLocal(prevNeuron.id, neuron.id) select prevNeuron)
                            {
                                for (var x = 0; x < 64; x++)
                                {
                                    for (var y = 0; y < 64; y++)
                                    {
                                        if (neuron.weight[x, y] > 0)
                                            neuron.weight[x, y] += (float)(prevNeuron.weight[x, y] + speed * neuron.error * prevNeuron.a);
                                    }
                                }
                            }
                            neuron.threshold = (float)(neuron.threshold - speed * neuron.error);
                        }
                    }
                }

            }
           
        }

        public void update_FIRST_hidden_layer_weights()
        {
            foreach (var inputNeuron in from outNeuron in network.Layers[0].Neurons where limit_out - outNeuron.a > 0.01 from firstLayer in network.Layers.Where(l => l.Name == "Enter") from inputNeuron in firstLayer.Neurons where IsLinkedGlobal(inputNeuron.id, outNeuron.id) select inputNeuron)
            {
                for (var x = 0; x < 64; x++)
                {
                    for (var y = 0; y < 64; y++)
                    {
                        if (inputNeuron.weight[x, y] > 0)
                            inputNeuron.weight[x, y] = (float)(inputNeuron.weight[x, y] + speed * inputNeuron.error);
                    }
                }
                inputNeuron.threshold = (float)(inputNeuron.threshold - speed * inputNeuron.error);
            }
        }

        public bool IsLinkedGlobal(int firstNeuron, int lastNeuron)
        {
            int first = firstNeuron;
            bool linked = false;
            bool flag = false;
            while (!linked && !flag)
            {
                foreach (var link in links.Where(link => link.id_out == first))
                {
                    if (link.id_in == lastNeuron)
                    {
                        linked = true;
                    }
                    else
                    {
                        first = link.id_in;
                    }
                    
                }
                if (links.Where(link => link.id_out == first).ToList().Count < 1)
                    flag = true;

            }
            return linked;

        }


        public bool IsLinkedLocal(int firstNeuron, int lastNeuron)
        {
            int first = firstNeuron;
            bool linked = false;
            
            foreach (var link in links.Where(link => link.id_out == first).Where(link => link.id_in == lastNeuron))
            {
                linked = true;
            }

            
            return linked;
        }
        public void RecognizeLetter()
        {
            //to_form(enter);
            
            recognizeNetwork = new Network();

            double sum = 0;
            recognizeNetwork.Layers.Add(new NetLayer());

            //обход первого слоя
            foreach (var inputNeuron in network.Layers[network.Layers.Count - 1].Neurons)
            {
                submit = new double[64, 64];

                sigma = 0;
                sum = 0;

                for (int x = 0; x < 64; x++)
                {
                    for (int y = 0; y < 64; y++)
                    {
                        sum += inputNeuron.weight[x, y] * enter[x, y];
                        submit[x, y] = inputNeuron.weight[x, y] * enter[x, y];
                    }
                }

                sigma = Neuron.sigmoida(sum - inputNeuron.threshold);
                //sigma = sum > inputNeuron.threshold ? 1 : 0;

                
                recognizeNetwork.Layers[0].Neurons.Add(new Neuron(sigma, submit, inputNeuron.id));
               // to_form(recognizeNetwork.Layers[0].Neurons.Last().weight);
            }


            //обход всех остальных
            foreach (var layer in network.Layers.OrderByDescending(l => l.LayerNumber).Where(l => l.Name != "Enter"))
            {
                recognizeNetwork.Layers.Add(new NetLayer());
                foreach (var neuron in layer.Neurons)
                {
                    submit = new double[64, 64];
                    sum = 0;
                    sigma = 0;
                    foreach (var recognizeLayer in recognizeNetwork.Layers)
                    {
                        foreach (var recognizeNeuron in recognizeLayer.Neurons)
                        {
                            if (IsLinkedLocal(recognizeNeuron.id, neuron.id))
                            {
                                for (int x = 0; x < 64; x++)
                                {
                                    for (int y = 0; y < 64; y++)
                                    {
                                        submit[x, y] += recognizeNeuron.weight[x, y] * recognizeNeuron.a;
                                        sum += recognizeNeuron.weight[x, y] * recognizeNeuron.a;
                                    }
                                }
                            }

                        }

                    }
                    sigma = Neuron.sigmoida(sum - neuron.threshold);
                    //sigma = sum > neuron.threshold ? 1 : 0;
                    recognizeNetwork.Layers.Last().Neurons.Add(new Neuron(sigma, submit, neuron.id));
                }
            }
                
        }
        

        ///////////////--------------------------------------


        private void CreateTemplateAndTool(string name, string category, Shape shape)
        {
            Template template = new Template(name, shape);
            toolSetListViewPresenter1.ToolSetController.CreateTemplateTool(template, category);
            project1.Repository.InsertAll(template);
        }

        private void add_tools()
        {
            toolSetListViewPresenter1.ToolSetController.Clear();
            toolSetListViewPresenter1.ToolSetController.AddTool(new SelectionTool(), true);

            string category = "Функции активации";
            RectangleBase roundedBoxShape = (RectangleBase) project1.ShapeTypes["Box"].CreateInstance();
            roundedBoxShape.FillStyle = project1.Design.FillStyles.Black;
            roundedBoxShape.LineStyle = project1.Design.LineStyles.Thick;
            roundedBoxShape.Width = 64;
            roundedBoxShape.Height = 64;
            roundedBoxShape.Tag = "sigmoida";
            CreateTemplateAndTool("Сигмоида", category, roundedBoxShape);

            RectangleBase roundedBoxShape2 = (RectangleBase)project1.ShapeTypes["Box"].CreateInstance();
            roundedBoxShape2.FillStyle = project1.Design.FillStyles.Black;
            roundedBoxShape2.LineStyle = project1.Design.LineStyles.Thick;
            roundedBoxShape2.Width = 64;
            roundedBoxShape2.Height = 64;
            roundedBoxShape2.Tag = "heavyside";
            CreateTemplateAndTool("Хэвисайда", category, roundedBoxShape2);

            category = "Связи";
            Polyline roundedBoxline = (Polyline) project1.ShapeTypes["Polyline"].CreateInstance();
            roundedBoxline.EndCapStyle = project1.Design.CapStyles.ClosedArrow;
            CreateTemplateAndTool("Связь", category, roundedBoxline);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;
            char[] Arr = Enumerable.Range(0, 32).Select((int x, int i) => (char) (1040 + i)).ToArray<char>();
            char[] arr = Enumerable.Range(0, 32).Select((int x, int i) => (char) (1072 + i)).ToArray<char>();
            for (int j = 0; j < Arr.Length; j++)
            {
                alphabet.Add(Arr[j]);
            }
            for (int j = 0; j < Arr.Length; j++)
            {
                alphabet.Add(arr[j]);
            }

            var coord = new Point();

            var coord1 = System.IO.File.ReadAllLines(@"coordinateBig.txt");
            for (int i = 0; i < coord1.Length; i += 2)
            {
                coord.X = Convert.ToInt32(coord1[i]);
                coord.Y = Convert.ToInt32(coord1[i + 1]);
                coordinate.Add(coord);
            }

            var coord2 = System.IO.File.ReadAllLines(@"coordinateSmall.txt");
            
            for (int i = 0; i < coord2.Length; i += 2)
            {
                coord.X = Convert.ToInt32(coord2[i]);
                coord.Y = Convert.ToInt32(coord2[i + 1]);
                coordinate.Add(coord);
            }
            
            


            project1.AutoLoadLibraries = true;
            project1.LibrarySearchPaths.Add(Application.StartupPath);
            project1.AddLibraryByName("Dataweb.NShape.GeneralShapes", false);

            xmlStore1.DirectoryName = (xmlStore1.FileExtension = string.Empty);

            project1.Name = "Arkenstone";
            project1.Create();

            add_tools();

            diagram = new Diagram("d1") {Size = new Size(570, 420)};

            cachedRepository1.InsertAll(diagram);

            display1.Diagram = diagram;




            //cuda
            try
            {
                if (check_connection())
                    button11.Enabled = true;
            }
         catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputList.Count > 0)
            {
                var inputArray = inputList.ToArray();
                connectInp.Add(inputArray);
            }

            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            bm1 = (pictureBox1.Image as Bitmap);
            bm1 = new Bitmap(bm1, new Size(64, 64));
            //enter = new double[64, 64];
            enter = Operations.GetBinaryPic(bm1, enter);

            inputList.Clear();
            input_signal.Add(enter);

            //to_notepad(enter, Form1.alpha_count);
            //alpha_count++;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                pictureBox1.Image = bm1;
                pictureBox2.Image = null;
                bm_test = bm1.Clone(new Rectangle(0, 0, 64, 64), bm1.PixelFormat);
                bm3 = new Bitmap(64, 64);
                Point p = pictureBox1.PointToClient(Cursor.Position);
                bm2 = bm1.Clone(new RectangleF((float) (p.X - 10), (float) (p.Y - 8), 20f, 16f), bm1.PixelFormat);
                Graphics g = Graphics.FromImage(bm3);
                g.Clear(Color.White);
                g.DrawImage(bm2, p.X - 10, p.Y - 8);
                Graphics g2 = Graphics.FromImage(bm_test);
                Pen p2 = new Pen(Color.Black);
                g2.DrawRectangle(p2, p.X - 10, p.Y - 8, 20, 16);
                pictureBox1.Image = bm_test;
                pictureBox2.Image = bm3;
                bm2 = null;
                bm_test = null;
            }

            catch
            {
                // ignored
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Operations.GetBinaryPic(bm3, input);
            
            Picture box = (Picture) project1.ShapeTypes["Picture"].CreateInstance();
            box.Image = new NamedImage{ Image = bm3 };


            box.FillStyle = project1.Design.FillStyles.Transparent;
            box.Data = count.ToString();
            box.Text = box.Data;
            box.X = StartPoint(box).X;
            box.Y = StartPoint(box).Y;
            box.Tag = comboBox1.SelectedItem;


            diagram.Shapes.Add(box);
            cachedRepository1.Insert((Shape) box, diagram);

            count++;

            //inputList.Add(Convert.ToInt32(box.Data));
        }

        private Point StartPoint(Shape boxShape)
        {
            var point  = new Point();

            if (diagram.Shapes.Count == 0)
            {
                point.X = 40;
                point.Y = 40;
            }
            else
            {
                point.X = diagram.Shapes.First().X;
                point.Y = diagram.Shapes.First().Y + 60;
            }


            return point;
        }

        private void cachedRepository1_ConnectionInserted(object sender, RepositoryShapeConnectionEventArgs e)
        {
            
            if (e.ConnectorShape.GetConnectionInfos(ControlPointId.Any, null).Count<ShapeConnectionInfo>() == 2)
            {

                first_vertex = e.ConnectorShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape;
                last_vertex = e.ConnectorShape.GetConnectionInfo(ControlPointId.LastVertex, null).OtherShape;
                if (first_vertex.Type.Name == "Picture")
                {
                    Operations.Connect_shapes_picture(display1, first_vertex, last_vertex, project1, diagram,
                        cachedRepository1, e, links);

                    links.Add(new Link(Convert.ToInt32(first_vertex.Data), Convert.ToInt32(last_vertex.Data)));

                    listBox1.Items.Clear();
                    foreach(var link in links)
                        listBox1.Items.Add(link.id_out + " --> " + link.id_in);
                }
                if (first_vertex.Type.Name == "Box")
                {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            backgroundWorker1.RunWorkerAsync();

            

        }

        Stopwatch myStopwatch = new Stopwatch();
        int iteration_count = 0;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            
            myStopwatch.Start();

            bool ready = false;
            

            int good_count = 0;

            while (!ready)
            {
                good_count = 0;
                for (int j = 0; j < network.Layers[0].Neurons.Count(); j++)
                {
                    if (limit_out - network.Layers[0].Neurons[j].a <= 0.01)
                        good_count++;
                }
                if (good_count == network.Layers[0].Neurons.Count)
                    ready = true;

                if (!ready)
                {
                    run_network_new();

                    calculate_output_layer_errors_new();
                    calculate_hidden_layers_errors();

                    update_output_weights();
                    update_hidden_weights();
                    update_FIRST_hidden_layer_weights();

                    iteration_count++;
                    
                    backgroundWorker1.ReportProgress(iteration_count/2);
                    
                    
                    
                }
            }

            


            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > progressBar1.Maximum)
            {
                progressBar1.Maximum += 10;
            }
            else
            {
                progressBar1.Value = e.ProgressPercentage;
            }
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = progressBar1.Maximum;
            myStopwatch.Stop();
            double time = myStopwatch.ElapsedMilliseconds / 1000;
            MessageBox.Show("Время: " + time + " секунд");

            MessageBox.Show(iteration_count.ToString() + " итераций");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecognizeLetter();

            recognize_sigm_out = new List<double>();
         

            recognizeNetwork.Layers[recognizeNetwork.Layers.Count - 1].Neurons =
                recognizeNetwork.Layers[recognizeNetwork.Layers.Count - 1].Neurons.OrderBy(o => o.id).ToList();


            for (int index = 0; index < recognizeNetwork.Layers.Last().Neurons.Count; index++)
            {
                var neuron = recognizeNetwork.Layers.Last().Neurons[index];
                recognize_sigm_out.Add(neuron.a);
            }

            double max = recognize_sigm_out.Max();


            int RECOGNIZED = 0;

            for (int i = 0; i < recognizeNetwork.Layers.Last().Neurons.Count(); i++)
            {

                if (recognize_sigm_out[i] == max)
                {
                    //to_form(recognizeNetwork.Layers.Last().Neurons[RECOGNIZED].weight);
                    RECOGNIZED = i;
                }
                   
            }

            MessageBox.Show("Программа думает, что на изображении буква " + alphabet[RECOGNIZED]);
        }

        private void display1_ShapesInserted(object sender, Dataweb.NShape.Controllers.DiagramPresenterShapesEventArgs e)
        {
            foreach (Shape box in e.Shapes)
            {
                if (box.Type.Name == "Box" && box.Data == null)
                {
                    box.Data = count.ToString();
                    count++;
                }
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            network.Layers.Add(new NetLayer("Output", OutputLayer(diagram, display1)));

            DetectHiddenLayers(diagram, network);
            
            foreach (var t in network.Layers)
            {
                listBox1.Items.Add(t.Name);
                foreach (var n in t.Neurons)
                {
                    listBox1.Items.Add(n.id);
                }
                listBox1.Items.Add("");

            }


        }


        public List<Neuron> OutputLayer(Diagram pDiagram, Display pDisplay)
        {
            var list = new List<Neuron>();
            bool containFirst = false;
            foreach (var s in display1.SelectedShapes)
            {
                input = new double[64,64];
                if (s.Type.Name != "Polyline")
                {
                    var shi = s.GetConnectionInfos(ControlPointId.Any, null).ToList<ShapeConnectionInfo>();

                    if (shi.Any(t => t.OtherPointId == ControlPointId.FirstVertex))
                        containFirst = true;

                    if (!containFirst)
                    {
                        list.Add(new Neuron(Operations.GetBinaryPic((Bitmap)Operations.newDraw(s), input), Convert.ToInt32(s.Data), s.Tag.ToString()));
                    }
                        
                }
            }
            return list;
        }

        public void DetectHiddenLayers(Diagram pDiagram, Network pNetwork)
        {
            var outputLayer = pNetwork.Layers.First(layer => layer.Name == "Output");

            var hiddenList = new List<Neuron>();
            foreach (Shape s in pDiagram.Shapes)
                foreach (var n in outputLayer.Neurons)
                {
                    if (n.id == Convert.ToInt32(s.Data))
                        foreach (var t in s.GetConnectionInfos(ControlPointId.Any, null))
                            hiddenList.Add(new Neuron(Operations.GetBinaryPic((Bitmap)Operations.newDraw(pDiagram.Shapes.First(shape => shape.Data == t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data)), input), Convert.ToInt32(t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data), t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Tag.ToString()));
                }

            pNetwork.Layers.Add(new NetLayer("Hidden", hiddenList));

            var hiddenLayer = pNetwork.Layers.First(layer => layer.Name == "Hidden");

            int lay_count = 1;

            while (!IsFirstLayer(pDiagram, hiddenLayer))
            {
                hiddenList = new List<Neuron>();
                foreach (Shape s in pDiagram.Shapes)
                    foreach (var n in hiddenLayer.Neurons)
                    {
                        if (n.id == Convert.ToInt32(s.Data))
                        {
                            IEnumerable<ShapeConnectionInfo> shi = s.GetConnectionInfos(ControlPointId.Any, null);
                            foreach (var t in shi)
                            {
                                if (t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data != s.Data) hiddenList.Add(new Neuron(Operations.GetBinaryPic((Bitmap) Operations.newDraw(pDiagram.Shapes.First(shape => shape.Data == t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data)), input), Convert.ToInt32(t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data), t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Tag.ToString()));
                            }
                        }
                    }

                pNetwork.Layers.Add(new NetLayer(lay_count + "-Hidden", hiddenList));

                hiddenLayer = pNetwork.Layers.First(l => l.Name == lay_count + "-Hidden");

                lay_count++;
                
                
            }
            if (IsFirstLayer(pDiagram, hiddenLayer))
            {
                var enterLayer = pNetwork.Layers.First(l => l.Name == Convert.ToInt32(lay_count-1) + "-Hidden");
                enterLayer.Name = "Enter";
            }

        }

        public bool IsFirstLayer(Diagram pDiagram, NetLayer list)
        {
            var containEnd = false;
            foreach (var shi in (from s in pDiagram.Shapes
                from n in list.Neurons
                where n.id == Convert.ToInt32(s.Data)
                select s).Select(s => s.GetConnectionInfos(ControlPointId.Any, null)))
            {
                if (shi.Any(t => t.OtherPointId == ControlPointId.LastVertex))
                    containEnd = true;

                if (!containEnd)
                    return true;
            }
            return false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateFirstHiddenLayer(loadedImages);
            CreateLinksBeetwenNeurons(firstLayerNeurons, hiddenLayerNeurons);
        }

        

        List<Image> loadedImages = new List<Image>();
        private void button7_Click(object sender, EventArgs e)
        {
            loadedImages.Clear();

            var dr = openFileDialog2.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (var file in openFileDialog2.FileNames)
                {
                    loadedImages.Add(Image.FromFile(file));
                    
                }
            }

            
            
            
        }

        private void InsertNeuron()
        {
            
        }

        private Point HiddenPoint(Shape boxShape)
        {
            var point = new Point();

            if (diagram.Shapes.Count == 0)
            {
                point.X = 250;
                point.Y = 250;
            }
            else
            {
                point.X = diagram.Shapes.First().X;
                point.Y = diagram.Shapes.First().Y + 60;
            }


            return point;
        }

        private void CreateLinksBeetwenNeurons(List<Shape> shapes, List<Shape> hidden_shapes)
        {
            int y = 100;
            
            Shape box = (Shape)project1.ShapeTypes["Box"].CreateInstance();
            for (int i = shapes.Count - 1; i < (connect.Count + shapes.Count) - 1; i++)
            {
                foreach (var shape in shapes)
                {
                    if (connect[i - (shapes.Count - 1)].Contains(Convert.ToInt32(shape.Data)))
                    {
                        links.Add(new Link(Convert.ToInt32(shape.Data), (i+2)));
                        
                        if (connect[i - (shapes.Count - 1)][0] == Convert.ToInt32(shape.Data))
                        {

                            y = shape.Y + 45;
                            box = (Shape)project1.ShapeTypes["Box"].CreateInstance();
                            box.Data = count.ToString();
                            box.X = 250;
                            box.Y = y;
                            box.Tag = "sigmoida";
                            diagram.Shapes.Add(box);
                            cachedRepository1.Insert((Shape)box, diagram);

                            

                            count++;
                            

                            
                            var arrow = (Polyline)project1.ShapeTypes["Polyline"].CreateInstance();
                            
                            diagram.Shapes.Add(arrow);
                            cachedRepository1.Insert((Shape)arrow, diagram);

                            
                            arrow.Connect(ControlPointId.FirstVertex, shape, ControlPointId.Reference);
                            arrow.Connect(ControlPointId.LastVertex, box, ControlPointId.Reference);

                            

                            Operations.ConnectShapesAutomatically(display1, shape, ref box, project1, diagram, cachedRepository1, arrow);
                            hiddenLayerNeurons.Add(box);
                        }

                        else
                        {
                            var arrow = (Polyline)project1.ShapeTypes["Polyline"].CreateInstance();

                            diagram.Shapes.Add(arrow);
                            cachedRepository1.Insert((Shape)arrow, diagram);

                            arrow.Connect(ControlPointId.FirstVertex, shape, ControlPointId.Reference);
                            arrow.Connect(ControlPointId.LastVertex, box, ControlPointId.Reference);

                            Operations.ConnectShapesAutomatically(display1, shape, ref box, project1, diagram, cachedRepository1, arrow);
                        }
                        
                    }
                }
            }

            int y2 = 200;


            Shape box2 = (Shape)project1.ShapeTypes["Box"].CreateInstance();
            for (int i = (shapes.Count - 1)+(hidden_shapes.Count - 1); i < (hidden_shapes.Count + shapes.Count + connectOut.Count) - 2; i++)
            {
                foreach(var shape in hidden_shapes)
                {
                    if (connectOut[i - ((shapes.Count - 1) + (hidden_shapes.Count - 1))].Contains(Convert.ToInt32(shape.Data) - Convert.ToInt32(shapes.Count)))
                    {
                        links.Add(new Link(Convert.ToInt32(shape.Data), (i + 3)));

                        if (connectOut[i - ((shapes.Count - 1) + (hidden_shapes.Count - 1))][0] == (Convert.ToInt32(shape.Data) - Convert.ToInt32(shapes.Count)))
                        {
                            y2 = shape.Y + 90;
                            box2 = (Shape)project1.ShapeTypes["Box"].CreateInstance();
                            box2.Data = count.ToString();
                            box2.X = 450;
                            box2.Y = y2;
                            box2.Tag = "sigmoida";
                            diagram.Shapes.Add(box2);
                            cachedRepository1.Insert((Shape)box2, diagram);


                            count++;
                            


                            var arrow = (Polyline)project1.ShapeTypes["Polyline"].CreateInstance();

                            diagram.Shapes.Add(arrow);
                            cachedRepository1.Insert((Shape)arrow, diagram);


                            arrow.Connect(ControlPointId.FirstVertex, shape, ControlPointId.Reference);
                            arrow.Connect(ControlPointId.LastVertex, box2, ControlPointId.Reference);



                            Operations.ConnectShapesAutomatically(display1, shape, ref box2, project1, diagram, cachedRepository1, arrow);

                            
                        }

                        else
                        {
                            var arrow = (Polyline)project1.ShapeTypes["Polyline"].CreateInstance();

                            diagram.Shapes.Add(arrow);
                            cachedRepository1.Insert((Shape)arrow, diagram);

                            arrow.Connect(ControlPointId.FirstVertex, shape, ControlPointId.Reference);
                            arrow.Connect(ControlPointId.LastVertex, box2, ControlPointId.Reference);

                            Operations.ConnectShapesAutomatically(display1, shape, ref box2, project1, diagram, cachedRepository1, arrow);
                        }
                    }
                    
                    
                }
            }






        }

        private void CreateSecondHiddenLayer(List<Shape> shapes)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                for (int j = 0; j < connect.Count; j++)
                {
                    if (connect[j].Contains(Convert.ToInt32(shapes[i].Data)))
                    {
                        
                    }
                }
                
            }
            
            //foreach (var shape in shapes.Where(s => s.Type.Name == "Box"))
            //{

            //}
        }
        private void CreateFirstHiddenLayer(List<Image> images)
        {
            
            var countCoor = 0;
            for (int i = 0; i < images.Count; i++)
            {
                Bitmap autobm = new Bitmap(images[i], new Size(64, 64));

                for (int j = 0; j < connectInp[i].Length; j++)
                {
                    Bitmap sign = new Bitmap(64, 64);
                    Bitmap neuron = new Bitmap(64, 64);

                    Point p = coordinate[countCoor];
                    countCoor++;

                    sign = autobm.Clone(new RectangleF(p.X - 10, p.Y - 8, 20, 16), autobm.PixelFormat);
                    Graphics g = Graphics.FromImage(neuron);
                    g.Clear(Color.White);
                    g.DrawImage(sign, p.X - 10, p.Y - 8);

                    

                    Picture box = (Picture)project1.ShapeTypes["Picture"].CreateInstance();
                    box.Image = new NamedImage { Image = neuron };

                    box.FillStyle = project1.Design.FillStyles.Transparent;
                    box.Data = count.ToString();
                    box.Text = box.Data;
                    box.X = StartPoint(box).X;
                    box.Y = StartPoint(box).Y;
                    box.Tag = "sigmoida";

                    diagram.Shapes.Add(box);
                    cachedRepository1.Insert((Shape)box, diagram);


                    firstLayerNeurons.Add((Shape)box);
                    count++;

                    //for (int k = 0; k < connect.Count; k++)
                    //{
                    //    if (connect[k][connect[k].Length - 1] == connectInp[i][j])
                    //    {




                    //    }

                    //}
                }

                
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (var i = 0; i < loadedImages.Count; i++)
            {
                enter = Operations.GetBinaryPic((Bitmap)loadedImages[i], enter);
                RecognizeLetter();


                recognize_sigm_out = new List<double>();
         

                recognizeNetwork.Layers[recognizeNetwork.Layers.Count - 1].Neurons =
                    recognizeNetwork.Layers[recognizeNetwork.Layers.Count - 1].Neurons.OrderBy(o => o.id).ToList();


                foreach (var neuron in recognizeNetwork.Layers.Last().Neurons)
                {
                    recognize_sigm_out.Add(neuron.a);
                }

                double max = recognize_sigm_out.Max();


                int RECOGNIZED = 0;

                for (int j = 0; j < recognizeNetwork.Layers.Last().Neurons.Count(); j++)
                {

                    if (recognize_sigm_out[j] == max)
                    {
                        
                        RECOGNIZED = j;
                    }
                   
                }



                listBox1.Items.Add(alphabet[i] + " => " + alphabet[RECOGNIZED]);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cu.Show();
        }
    }
}
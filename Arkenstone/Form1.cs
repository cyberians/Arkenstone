using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dataweb.NShape;
using Dataweb.NShape.GeneralShapes;
using Dataweb.NShape.WinFormsUI;
using Arkenstone.Classes;
using Dataweb.NShape.Advanced;

namespace Arkenstone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Diagram diagram;

        Bitmap bm1;
        Bitmap bm2;
        Bitmap bm3;

        Bitmap bm_test = new Bitmap(64, 64);

        List<Neuron> hid1_layer = new List<Neuron>();
        List<Neuron> hid2_layer = new List<Neuron>();
        List<Neuron> output_layer = new List<Neuron>();

        List<char> alphabet = new List<char>();

        List<double[,]> recognize_hid1 = new List<double[,]>();
        List<double[,]> recognize_hid2 = new List<double[,]>();
        List<double[,]> recognize_output = new List<double[,]>();

        List<double> recognize_sigm_hid1 = new List<double>();
        List<double> recognize_sigm_hid2 = new List<double>();
        List<double> recognize_sigm_out = new List<double>();

        List<double[,]> input_signal = new List<double[,]>();
        List<Link> links = new List<Link>();

        double[,] input = new double[64, 64];

        double[,] enter = new double[64, 64];

        List<Bitmap> visPriznak = new List<Bitmap>();
        List<Bitmap> visGrPriznak = new List<Bitmap>();
        List<Bitmap> visOut = new List<Bitmap>();

        List<int[]> connect = new List<int[]>();
        List<int[]> connectOut = new List<int[]>();
        List<int[]> connectInp = new List<int[]>();
        List<int> inputList = new List<int>();

        List<Link> layer1_connect = new List<Link>();
        List<Link> layer2_connect = new List<Link>();
        List<Link> layer3_connect = new List<Link>();

        int countgr2 = 0;
        int count = 1;
        int outGr = 0;

        double limit_out = 1.0;
        double speed = 3.0;
        double[,] submit;
        double sigma;

        Shape first_vertex;
        Shape last_vertex;

        Network network = new Network();
        Network recognizeNetwork;

        /////////////---вывод на форму


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



        public void run_network_new()
        {
            //первый скрытый слой
            foreach (var outNeuron in network.Layers[0].Neurons)
            {
                if (limit_out - outNeuron.a > 0.01)
                {
                    foreach (var input_neuron in network.Layers[network.Layers.Count - 1].Neurons)
                    {
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
                            input_neuron.a = Neuron.sigmoida(sum - input_neuron.threshold);
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
                        foreach (var hidNeuron in hidLayer.Neurons)
                        {
                            if (IsLinkedLocal(hidNeuron.id, outNeuron.id))
                            {
                                hidNeuron.weight = new double[64, 64];
                                double sum = 0;

                                foreach (var prevLayer in network.Layers.Where(layer => layer.LayerNumber == hidLayer.LayerNumber + 1))
                                {
                                    foreach (var input_neuron in prevLayer.Neurons)
                                    {

                                        if (IsLinkedLocal(input_neuron.id, hidNeuron.id))
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
                                    }
                                }
                                hidNeuron.a = Neuron.sigmoida(sum - hidNeuron.threshold);
                            }
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
                    outNeuron.weight = new double[64, 64];
                    foreach (var hidNeuron in network.Layers[1].Neurons)
                    {
                        if (IsLinkedLocal(hidNeuron.id, outNeuron.id))
                        {
                            for (int x = 0; x < 64; x++)
                            {
                                for (int y = 0; y < 64; y++)
                                {
                                    sum += hidNeuron.weight[x, y]*hidNeuron.a;
                                    outNeuron.weight[x, y] += hidNeuron.weight[x, y]*hidNeuron.a;
                                }

                            }
                            //to_form(outNeuron.weight);
                        }
                    }
                    outNeuron.a = Neuron.sigmoida(sum - outNeuron.threshold);
                }
            }
                

        }

        public void calculate_output_layer_errors_new()
        {
            foreach (var neuron in network.Layers[0].Neurons)
                neuron.error = (limit_out - neuron.a)*neuron.a*(1 - neuron.a);
        }


        public void calculate_hidden_layers_errors()
        {
            foreach (var layer in network.Layers.Where(l => l.Name != "Output"))
            {
                foreach (var neuron in layer.Neurons)
                {
                    double sum = 0;
                    foreach (var outputLayer in network.Layers.Where(l => l.LayerNumber == layer.LayerNumber - 1))
                    {
                        foreach (var outNeuron in outputLayer.Neurons)
                        {
                            if (IsLinkedLocal(neuron.id, outNeuron.id))
                            {
                                for (var x = 0; x < 64; x++)
                                {
                                    for (var y = 0; y < 64; y++)
                                    {
                                        sum += outNeuron.error*neuron.weight[x, y];
                                    }
                                }
                            }
                        }
                    }
                    neuron.error = neuron.a*(1 - neuron.a)*sum;
                }
            }

            //foreach (var t in network.Layers)
            //{
            //    foreach (var neuron in t.Neurons)
            //    {
            //        double sum = 0.0;
            //        foreach (var link in links.Where(link => link.id_out == neuron.id))
            //        {
            //            foreach (var layer in network.Layers.Where(layer => layer.LayerNumber == t.LayerNumber - 1))
            //            {
            //                for (var x = 0; x < neuron.weight.GetLength(0); x++)
            //                {
            //                    for (var y = 0; y < neuron.weight.GetLength(1); y++)
            //                    {
            //                        sum += layer.Neurons.Where(output_neuron => link.id_in == output_neuron.id).Sum(output_neuron => output_neuron.error*neuron.weight[x, y]);
            //                    }
            //                }
            //                //MessageBox.Show("Сейчас обрабатываются слои:\n\n" + t.Name + " и " + layer.Name);
            //            }
            //            //MessageBox.Show("Текущий линк: " + link.id_out + " - " + link.id_in);
            //        }
            //        if(sum > 0)
            //            neuron.error = neuron.a*(1.0 - neuron.a)*sum;
            //        //MessageBox.Show("НЕейроны");
            //    }
            //    //MessageBox.Show("Дошел до сюда. слой - "+t.Name);
            //}
        }


        public void update_output_weights()
        {
            foreach (var outNeuron in network.Layers[0].Neurons)
            {
                if (limit_out - outNeuron.a > 0.01)
                {
                    foreach (var hidNeuron in network.Layers[1].Neurons)
                    {
                        if (IsLinkedLocal(hidNeuron.id, outNeuron.id))
                        {
                            for (int x = 0; x < 64; x++)
                            {
                                for (int y = 0; y < 64; y++)
                                {
                                    if (outNeuron.weight[x, y] > 0)
                                        outNeuron.weight[x, y] += hidNeuron.weight[x, y] + speed * outNeuron.error * hidNeuron.a;
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
            //foreach (var lay in network.Layers.Where(l => l.Name == "Output"))
            //{
                foreach (var outNeuron in network.Layers[0].Neurons)//lay.Neurons)
                {
                    if (limit_out - outNeuron.a > 0.01)
                    {
                        //foreach (var layer in network.Layers.Where(layer => layer.Name != "Output"))
                        //{
                            
                            foreach (var neuron in network.Layers[1].Neurons)//layer.Neurons)
                            {
                                if (IsLinkedLocal(neuron.id, outNeuron.id))
                                {
                                    //foreach (var prevLayer in network.Layers.Where(x => x.LayerNumber - 1 == layer.LayerNumber))
                                    //{
                                    foreach (var prevNeuron in network.Layers[2].Neurons)//prevLayer.Neurons)
                                    {
                                        if (IsLinkedLocal(prevNeuron.id, neuron.id))
                                        {
                                            for (var x = 0; x < 64; x++)
                                            {
                                                for (var y = 0; y < 64; y++)
                                                {
                                                    if (neuron.weight[x, y] > 0)
                                                        neuron.weight[x, y] += prevNeuron.weight[x, y] + speed * neuron.error * prevNeuron.a;
                                                }
                                            }

                                        }
                                    }
                                    //}
                                    neuron.threshold = neuron.threshold - speed * neuron.error;

                                }

                            }

                        //}
                    }

                }
           // }
        }

        public void update_FIRST_hidden_layer_weights()
        {
            //foreach (var outputLayer in network.Layers.Where(l => l.Name == "Output"))
            //{
                foreach (var outNeuron in network.Layers[0].Neurons)//outputLayer.Neurons)
                {
                    if (limit_out - outNeuron.a > 0.01)
                    {
                        //foreach (var firstLayer in network.Layers.Where(l => l.Name == "Enter"))
                        //{
                            foreach (var inputNeuron in network.Layers[2].Neurons)//firstLayer.Neurons)
                            {
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
                        //}
                    }
                    
                }
           // }
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
            CreateTemplateAndTool("Сигмоида", category, roundedBoxShape);

            category = "Связи";
            Polyline roundedBoxline = (Polyline) project1.ShapeTypes["Polyline"].CreateInstance();
            roundedBoxline.EndCapStyle = project1.Design.CapStyles.ClosedArrow;
            CreateTemplateAndTool("Связь", category, roundedBoxline);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            //hid1_layer.Add(new Neuron(input, count));
            //visPriznak.Add(bm3);
            Picture box = (Picture) project1.ShapeTypes["Picture"].CreateInstance();
            box.Image = new NamedImage{ Image = bm3 };


            box.FillStyle = project1.Design.FillStyles.Transparent;
            box.Data = count.ToString();
            box.Text = box.Data;
            box.X = StartPoint(box).X;
            box.Y = StartPoint(box).Y;
            diagram.Shapes.Add(box);
            cachedRepository1.Insert((Shape) box, diagram);

            count++;

            //inputList.Add(Convert.ToInt32(box.Data));
        }

        public Point StartPoint(Shape boxShape)
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
            bool ready = false;
            int iteration_count = 0;

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
                }
                
                //to_form();
                //if (iteration_count == 10) MessageBox.Show("Стоп");
            }


            MessageBox.Show(iteration_count.ToString() + " итераций");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecognizeLetter();

            recognize_sigm_out = new List<double>();
            //teachers.Sort(delegate(Teacher teacher1, Teacher teacher2)
            //{ return teacher1.Name.CompareTo(teacher2.Name); });  
            //recognizeNetwork.Layers[recognizeNetwork.Layers.Count-1].Neurons.Sort(
            //    (neuron1, neuron2) => neuron1.id.CompareTo(neuron2.id));

            foreach (var neuron in recognizeNetwork.Layers.Last().Neurons)
            {
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
                        list.Add(new Neuron(Operations.GetBinaryPic((Bitmap) Operations.newDraw(s), input), Convert.ToInt32(s.Data)));
                    
                        
                }
            }
            return list;
        }

        public void DetectHiddenLayers(Diagram pDiagram, Network pNetwork)
        {
            var outputLayer = pNetwork.Layers.First(layer => layer.Name == "Output");

            var hiddenList = (
                from s in pDiagram.Shapes 
                from n in outputLayer.Neurons 
                where n.id == Convert.ToInt32(s.Data) 
                from t in s.GetConnectionInfos(ControlPointId.Any, null)
                select new Neuron(Operations.GetBinaryPic((Bitmap)Operations.newDraw(pDiagram.Shapes.First(shape => shape.Data == t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data)), input), 
                                    Convert.ToInt32(t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data))).ToList();

            pNetwork.Layers.Add(new NetLayer("Hidden", hiddenList));

            var hiddenLayer = pNetwork.Layers.First(layer => layer.Name == "Hidden");

            int lay_count = 1;

            while (!IsFirstLayer(pDiagram, hiddenLayer))
            {
                
                hiddenList = (
                    from s in pDiagram.Shapes 
                    from n in hiddenLayer.Neurons 
                    where n.id == Convert.ToInt32(s.Data) 
                    let shi = s.GetConnectionInfos(ControlPointId.Any, null) 
                    from t in shi 
                    where t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data != s.Data
                    select new Neuron(Operations.GetBinaryPic((Bitmap)Operations.newDraw(pDiagram.Shapes.First(shape => shape.Data == t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data)), input), 
                                        Convert.ToInt32(t.OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data))).ToList();
               
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
            //to_form();
            //run_network_new();
            //calculate_output_layer_errors_new();
            //calculate_hidden_layers_errors();
            //testForm tf = new testForm();

            //string test = "";

            //foreach (var layer in network.Layers)
            //{
            //    foreach (var neuron in layer.Neurons)
            //    {
            //        test = "";
            //        for (int i = 0; i < neuron.weight.GetLength(0); i++)
            //        {
            //            for (int j = 0; j < neuron.weight.GetLength(1); j++)
            //            {
            //                test += neuron.weight[i, j] + " ";
            //            }
            //            test += "\n";
            //        }
            //        tf.richTextBox1.Text = test;
            //        MessageBox.Show(neuron.id.ToString());
            //        tf.ShowDialog();
            //    }
            //}
            //update_hidden_weights();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(IsLinkedLocal(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)) ? "Да" : "Нет");
        }
    }
}
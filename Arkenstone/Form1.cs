using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

         double[,] input = new double[64, 64];

         double[,] enter = new double[64, 64];

        List<Bitmap> visPriznak = new List<Bitmap>();
        List<Bitmap> visGrPriznak = new List<Bitmap>();
        List<Bitmap> visOut = new List<Bitmap>();

        List<int[]> connect = new List<int[]>();
        List<int[]> connectOut = new List<int[]>();
        List<int[]> connectInp = new List<int[]>();

        List<Link> layer1_connect = new List<Link>();
        List<Link> layer2_coonect = new List<Link>();
        List<Link> layer3_connect = new List<Link>();

         int countInp = 0;
         int countgr2 = 0;
         int count = 1;
         int outGr = 0;

         double limit_out = 1.0;
         double speed = 3.0;
         double[,] submit;
         double sigma;

         Shape first_vertex;
         Shape last_vertex;

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
             RectangleBase roundedBoxShape = (RectangleBase)project1.ShapeTypes["Box"].CreateInstance();
             roundedBoxShape.FillStyle = project1.Design.FillStyles.Black;
             roundedBoxShape.LineStyle = project1.Design.LineStyles.Thick;
             CreateTemplateAndTool("Сигмоида", category, roundedBoxShape);

             category = "Связи";
             Polyline roundedBoxline = (Polyline)project1.ShapeTypes["Polyline"].CreateInstance();
             roundedBoxline.EndCapStyle = project1.Design.CapStyles.ClosedArrow;
             CreateTemplateAndTool("Связь", category, roundedBoxline);
         }
        private void Form1_Load(object sender, EventArgs e)
        {
            char[] Arr = Enumerable.Range(0, 32).Select((int x, int i) => (char)(1040 + i)).ToArray<char>();
            char[] arr = Enumerable.Range(0, 32).Select((int x, int i) => (char)(1072 + i)).ToArray<char>();
            for (int j = 0; j < Arr.Length; j++)
            {
                alphabet.Add(Arr[j]);
            }
            for (int j = 0; j < Arr.Length; j++)
            {
                alphabet.Add(arr[j]);
            }
            project1.AutoLoadLibraries = true;
            project1.LibrarySearchPaths.Add(System.Windows.Forms.Application.StartupPath);
            project1.AddLibraryByName("Dataweb.NShape.GeneralShapes", false);

            xmlStore1.DirectoryName = (xmlStore1.FileExtension = string.Empty);

            project1.Name = "Arkenstone";
            project1.Create();

            add_tools();

            diagram = new Diagram("d1");
            diagram.Size = new Size(570, 420);

            cachedRepository1.InsertAll(diagram);

            display1.Diagram = diagram;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            bm1 = (pictureBox1.Image as Bitmap);
            bm1 = new Bitmap(bm1, new Size(64, 64));
            enter = new double[64, 64];
            Operations.GetBinaryPic(bm1, enter);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                pictureBox1.Image = bm1;
                pictureBox2.Image = null;
                bm_test = bm1.Clone(new Rectangle(0, 0, 64, 64), bm1.PixelFormat);
                bm3 = new Bitmap(64, 64);
                Point p = pictureBox1.PointToClient(System.Windows.Forms.Cursor.Position);
                bm2 = bm1.Clone(new RectangleF((float)(p.X - 10), (float)(p.Y - 8), 20f, 16f), bm1.PixelFormat);
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

            catch { }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Operations.GetBinaryPic(bm3, input);
            hid1_layer.Add(new Neuron(input, count));
            visPriznak.Add(bm3);
            Picture box = (Picture)project1.ShapeTypes["Picture"].CreateInstance();
            box.Image = new NamedImage
            {
                Image = bm3
            };


            box.FillStyle = project1.Design.FillStyles.Transparent;
            box.Data = count.ToString();
            box.Text = box.Data;
            diagram.Shapes.Add(box);
            cachedRepository1.Insert(box as Shape, diagram);
            count++;
            countInp++;
        }
    }
}

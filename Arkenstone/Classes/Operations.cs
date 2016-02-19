using Dataweb.NShape;
using Dataweb.NShape.Advanced;
using Dataweb.NShape.GeneralShapes;
using Dataweb.NShape.WinFormsUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkenstone.Classes
{
    class Operations
    {
        public static int ClearInt(string data)
        {
            int submit = 0;

            string[] new_s = data.Split('b');

            submit = Convert.ToInt32(new_s[0]);

            return submit;
        }
        public static Bitmap Draw(List<Bitmap> images, int[] numb)
        {
            Bitmap bm = new Bitmap(64, 64);
            using (var g = Graphics.FromImage(bm))
                g.Clear(Color.White);

            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    for (int i = 0; i < numb.Length; i++)
                    {
                        Color mypixel = images[numb[i] - 1].GetPixel(x, y);
                        int col = 200;
                        if (!(mypixel.R > col && mypixel.G > col && mypixel.B > col))
                        {
                            bm.SetPixel(x, y, mypixel);
                        }
                    }
                }
            }
            return bm;
        }

        public static Bitmap shapeDraw(Display display, int[] numb)
        {
            Bitmap bm = new Bitmap(64, 64);
            using (var g = Graphics.FromImage(bm))
                g.Clear(Color.White);

            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    foreach (Shape s in display.SelectedShapes)
                    {
                        List<ShapeConnectionInfo> shi = new List<ShapeConnectionInfo>();
                        shi = s.GetConnectionInfos(ControlPointId.Any, null).ToList();
                        for (int j = 0; j < shi.Count; j++)
                        {
                            for (int i = 0; i < numb.Length; i++)
                            {
                                if (shi[j].OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape.Data == numb[i].ToString())
                                {
                                    Picture picture = shi[j].OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape as Picture;
                                    NamedImage img = new NamedImage();
                                    img = picture.Image;

                                    Bitmap bitmap = (Bitmap)img.Image;

                                    Color mypixel = bitmap.GetPixel(x, y);
                                    int col = 200;

                                    if (!(mypixel.R > col && mypixel.G > col && mypixel.B > col))
                                    {
                                        bm.SetPixel(x, y, mypixel);
                                    }
                                }
                            }
                        }

                    }
                }
            }
            return bm;

        }

        public static Image newDraw(Shape shape)
        {
            Bitmap bm = new Bitmap(64, 64);

            List<ShapeConnectionInfo> shi = new List<ShapeConnectionInfo>();

            shi = shape.GetConnectionInfos(ControlPointId.Any, null).ToList();

            using (var g = Graphics.FromImage(bm))
                g.Clear(Color.White);

            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    for (int i = 0; i < shi.Count; i++)
                    {
                        Picture picture = shi[i].OtherShape.GetConnectionInfo(ControlPointId.FirstVertex, null).OtherShape as Picture;
                        NamedImage img = new NamedImage();
                        img = picture.Image;

                        Bitmap bitmap = (Bitmap)img.Image;

                        Color mypixel = bitmap.GetPixel(x, y);
                        int col = 200;
                        if (!(mypixel.R > col && mypixel.G > col && mypixel.B > col))
                        {
                            bm.SetPixel(x, y, mypixel);
                        }
                    }
                }
            }

            return (Image)bm;
        }

        public static void GetBinaryPic(Bitmap bm, double[,] input)
        {
            for (int x = 0; x < 64; x++)
            {
                for (int y = 0; y < 64; y++)
                {

                    int n = (bm.GetPixel(y, x).R);
                    if (n >= 250) n = 0;
                    else n = 1;

                    input[x, y] = n;
                }
            }
        }



        public static void Connect_shapes_picture(Display display1, Shape first_vertex, Shape last_vertex, Project project1, Diagram diagram, CachedRepository cachedRepository1, RepositoryShapeConnectionEventArgs e)
        {
            Picture new_p = (Picture)project1.ShapeTypes["Picture"].CreateInstance();

            Box b = last_vertex as Box;

            if (b != null)
            {
                NamedImage img = new NamedImage();
                img.Image = newDraw(last_vertex);
                new_p.Image = img;
                new_p.FillStyle = project1.Design.FillStyles.Transparent;

                new_p.Data = b.Data;
                new_p.Text = new_p.Data;

                new_p.Height = b.Height;
                new_p.Width = b.Width;

                new_p.X = b.X;
                new_p.Y = b.Y;

                diagram.Shapes.Add(new_p);
                cachedRepository1.Insert(new_p as Shape, diagram);

                diagram.Shapes.Remove(b);

                e.ConnectorShape.Disconnect(ControlPointId.FirstVertex);
                e.ConnectorShape.Disconnect(ControlPointId.LastVertex);

                e.ConnectorShape.Connect(ControlPointId.FirstVertex, first_vertex, ControlPointId.Reference);
                e.ConnectorShape.Connect(ControlPointId.LastVertex, new_p, ControlPointId.Reference);
            }

            if (b == null && last_vertex.Type.Name == "Picture")
            {
                NamedImage img = new NamedImage();
                img.Image = newDraw(last_vertex);

                Picture picture = last_vertex as Picture;

                picture.Image = img;
                picture.FillStyle = project1.Design.FillStyles.Transparent;
            }


        }

        public static void Connect_shapes_box(Display display1, Shape first_vertex, Shape last_vertex, Project project1, Diagram diagram, CachedRepository cachedRepository1, RepositoryShapeConnectionEventArgs e)
        {
            Picture new_p = (Picture)project1.ShapeTypes["Picture"].CreateInstance();

            Box b = first_vertex as Box;

            if (b != null)
            {
                NamedImage img = new NamedImage();
                //img.Image = pictureBox2.Image;  //ИЗМЕНИТЬ
                //new_p.Image = img;
                new_p.FillStyle = project1.Design.FillStyles.Transparent;

                new_p.Data = b.Data;

                new_p.Height = b.Height;
                new_p.Width = b.Width;

                new_p.X = b.X;
                new_p.Y = b.Y;

                diagram.Shapes.Add(new_p);
                cachedRepository1.Insert(new_p as Shape, diagram);

                diagram.Shapes.Remove(b);

                e.ConnectorShape.Disconnect(ControlPointId.FirstVertex);
                e.ConnectorShape.Disconnect(ControlPointId.LastVertex);

                e.ConnectorShape.Connect(ControlPointId.FirstVertex, last_vertex, ControlPointId.Reference);
                e.ConnectorShape.Connect(ControlPointId.LastVertex, new_p, ControlPointId.Reference);
            }


        }


    }
}

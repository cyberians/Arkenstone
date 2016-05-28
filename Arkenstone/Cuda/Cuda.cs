using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Arkenstone.Cuda
{
    public unsafe partial class Cuda : Form
    {
        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool check_connection();

        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int check_driver();

        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int check_capability();

        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int check_memory();

        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int dev_count();

        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern char* dev_name(int index);

        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float mem_total(int dev);

        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int txt(int dev, int dim);

        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int grd(int dev, int dim);


        [DllImport("cudArk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void testmethod(float* f);



        Form1 parentForm;
        public Cuda(Form1 _parentForm)
        {
            InitializeComponent();
            parentForm = _parentForm;
        }

        private void Cuda_Load(object sender, EventArgs e)
        {
            load_devs();
            if (parentForm.dev_index > -1)
            {
                comboBox1.SelectedIndex = parentForm.dev_index;
            }
            //check();

        }

        public unsafe void load_devs()
        {
            int devs = dev_count();
            if (devs < 1)
            {
                MessageBox.Show("Не найдено ни одного устройства, поддерживающего CUDA.", "Ошибка!");
                Close();
            }
            else
            {
                for (int i = 0; i < devs; i++)
                {
                    char* k = dev_name(i);

                    comboBox1.Items.Add(Marshal.PtrToStringAnsi((IntPtr)k));

                }
                comboBox1.SelectedIndex = 0;
            }
        }
        public unsafe void check()
        {
            richTextBox1.Clear();
            try
            {
                parentForm.cl_mem = mem_total(comboBox1.SelectedIndex) * 1048576.0f;
                richTextBox1.Text += "Память устройства: " + (parentForm.cl_mem / 1048576.0f).ToString() + " Мбайт" + '\n';

                parentForm.cl_txt.X = txt(comboBox1.SelectedIndex, 0);
                parentForm.cl_txt.Y = txt(comboBox1.SelectedIndex, 1);
                richTextBox1.Text += "Текстурная память (x, y): " + parentForm.cl_txt.X + ", " + parentForm.cl_txt.Y + '\n';

                parentForm.cl_grd.X = grd(comboBox1.SelectedIndex, 0);
                parentForm.cl_grd.Y = grd(comboBox1.SelectedIndex, 1);
                richTextBox1.Text += "Размер сети блоков (x, y): " + parentForm.cl_grd.X + ", " + parentForm.cl_grd.Y;
            }
            catch { }

            try
            {
                checkedListBox1.SetItemChecked(0, check_connection());
                checkedListBox1.SetItemChecked(1, check_driver() >= 7050);
                checkedListBox1.SetItemChecked(2, check_capability() >= 30);
                //checkedListBox1.SetItemChecked(3, check_memory() >= 1000); Наличие минимального объема памяти
            }
            catch { }


            if (!parentForm.enable_CUDA)
            {
                button1.Text = "Включить";
                checkBox1.Text = "Отключено";
                checkBox1.Checked = false;

                if (checkedListBox1.GetItemChecked(0) &&
                   checkedListBox1.GetItemChecked(1) &&
                   checkedListBox1.GetItemChecked(2) &&
                    // checkedListBox1.GetItemChecked(3))
                    checkedListBox1.GetItemChecked(2))
                {
                    button1.Enabled = true;
                }
                else
                    button1.Enabled = false;
            }
            else
            {
                button1.Text = "Отключить";
                checkBox1.Text = "Включено (устройство " + parentForm.dev_index + ")";
                checkBox1.Checked = true;
                comboBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (parentForm.enable_CUDA)
            {
                parentForm.enable_CUDA = false;
                parentForm.dev_index = -1;
                comboBox1.Enabled = true;
            }
            else
            {
                parentForm.enable_CUDA = true;
                parentForm.dev_index = comboBox1.SelectedIndex;
            }
            check();


            //float[] x = new float[2];
            //x[0] = 1;
            //x[1] = 2;
            //fixed(float* f = x)
            //{
            //    testmethod(f);
            //}

            //MessageBox.Show(x[0].ToString()+'\n'+x[1].ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            check();
        }

        private void Cuda_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}

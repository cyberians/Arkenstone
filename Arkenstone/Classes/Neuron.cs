using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Arkenstone.Classes
{
    public class Neuron
    {
        public float[,] weight; //весовые коэффициенты
        public float threshold; //Порог
        public float a; //сигнал на выходе нейрона
        public float error; //значение ошибки
        public int id; // id нейрона
        public string func_name; //имя функции активации


        public Neuron(double[,] input, int count, string func)
        {
            weight = new float[64, 64];
            Random rnd = new Random();
            threshold = (float)rnd.NextDouble(); //1

            
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    weight[i, j] = (float)(input[i, j]*(rnd.NextDouble()* (0.004 - 0.001) + 0.001));
                }
            }

            func_name = func;

            id = count;
            //Form1.to_notepad(weight, Form1.alpha_count);
            //Form1.alpha_count++;
        }

        public Neuron(int count)
        {
            id = count;
        }

        public Neuron(double sigma, double [,] submit, int ID)
        {
            a = (float)sigma;
            weight = new float[submit.GetLength(0), submit.GetLength(1)];
            for (int i = 0; i < submit.GetLength(0); i++)
                for (int j = 0; j < submit.GetLength(1); j++)
                    weight[i, j] = (float)submit[i, j];
            id = ID;
        }


        public static double ActivationFunction(string f_name, params double[] x)
        {
            switch (f_name.ToLower())
            {
                case "sigmoida":
                {
                    return sigmoida(x);
                }
                   
                case "heavyside":
                {
                    return heavyside(x);
                }
                   
            }
            return 0;
        }

        public static double sigmoida(params double [] arg)
        {
            return 1.00 / (1.00 + Math.Exp(-(arg[0])));
        }

        public static double heavyside(params double [] arg)
        {
            return arg[0] > arg[1] ? 1 : 0;
        }

    }
}

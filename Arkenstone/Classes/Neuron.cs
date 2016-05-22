using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkenstone.Classes
{
    public class Neuron
    {
        public double[,] weight; //весовые коэффициенты
        public double threshold; //Порог
        public double a; //сигнал на выходе нейрона
        public double error; //значение ошибки
        public int id;


        public Neuron(double[,] input, int count)
        {
            weight = new double[64, 64];
            Random rnd = new Random();
            threshold = rnd.NextDouble(); //1

            
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    weight[i, j] = input[i, j]*(rnd.NextDouble()*0.02); //* (0.004 - 0.001) + 0.001);
                }
            }

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
            a = sigma;
            weight = submit;
            id = ID;
        }

        public static double sigmoida(double x)
        {
            return 1.00 / (1.00 + Math.Exp(-(x)));
        }

    }
}

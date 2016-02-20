using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkenstone.Classes
{
    internal class Neuron
    {
        public double[,] weight; //весовые коэффициенты
        public double threshold; //Порог
        public double a; //сигнал на выходе нейрона
        public double error; //значение ошибки
        //public double activate;
        public int id;
        public Neuron(double[,] input, int count)
        {
            weight = new double[64, 64];
            Random rnd = new Random();
            threshold = rnd.NextDouble();

            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    weight[i, j] = input[i, j] * (rnd.NextDouble() * (0.004 - 0.001) + 0.001);
                }
            }

            id = count;

        }

        public static double sigmoida(double x)
        {
            return 1.00 / (1.00 + Math.Exp(-(x)));
        }

    }
}

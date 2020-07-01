using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public static class Distance
    {

        static double CalculateTheDistance(int[] images, double[,] standards, int indexStandards)
        {
            double result = 0;
            for (int i = 0; i < images.Length; i++)
                result += Math.Pow(images[i] - standards[indexStandards, i], 2);
            return Math.Sqrt(result);
        }

        public static int MinimumDistance(int[] image, double[,] standards)
        {
            double min = int.MaxValue;
            int minIndex = -1;
            double temp = 0;
            for (int i = 0; i < standards.GetLength(0); i++)
            {
                temp = CalculateTheDistance(image, standards,i);
                if (temp < min)
                {
                    min = temp;
                    minIndex = i;
                }
            }
            return minIndex;
        }

    }
}

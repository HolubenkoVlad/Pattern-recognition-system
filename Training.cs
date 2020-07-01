using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Training
    {
        int[,] images;

        double[,] standards;

        int[] w;

        int numberOfClusters;

        public Training(int[,] _images, int _numberOfClusters)
        {
            images = _images;
            numberOfClusters = _numberOfClusters;
            w = new int[numberOfClusters];
            standards = InitializationStandardsAndWeight();
        }

        double[,] InitializationStandardsAndWeight()
        {
            for (int i = 0; i < numberOfClusters; i++)
                w[i] = 1;
            double[,] temp = new double[numberOfClusters, images.GetLength(1)];
            for (int i = 0; i < numberOfClusters; i++)
            {
                for (int j = 0; j < images.GetLength(1); j++)
                {
                    temp[i, j] = images[i, j];
                }
            }
            return temp;
        }

        double Subtraction(double[] standardsE1, double[,] E2, int indexE2)
        {
            double result = 0;
            for (int i = 0; i < E2.GetLength(1); i++)
                result += Math.Pow(E2[indexE2, i] - standardsE1[i], 2);
            return Math.Sqrt(result);
        }

        int[] GetImage(int indexImage)
        {
            int[] temp = new int[images.GetLength(1)];
            for (int i = 0; i < images.GetLength(1); i++)
                temp[i] = images[indexImage, i];
            return temp;
        }


        public double[,] Start()
        {
            double[] tempStandard=new double[images.GetLength(1)];
            int indexStandardAndWeight;
            int counter = numberOfClusters;
            while (true)
            {
                indexStandardAndWeight = Distance.MinimumDistance(GetImage(counter),standards);
                for (int i = 0; i < images.GetLength(1); i++)
                {
                    tempStandard[i] = standards[indexStandardAndWeight, i];
                    standards[indexStandardAndWeight, i] = (w[indexStandardAndWeight] * standards[indexStandardAndWeight, i] + images[counter, i]) / (w[indexStandardAndWeight] + 1);
                }                    
                w[indexStandardAndWeight] = w[indexStandardAndWeight] + 1;
                if (Subtraction(tempStandard, standards,indexStandardAndWeight) <= 0.01)
                    break;
                else
                {
                    if (counter < images.GetLength(0) - 1)
                        counter++;
                    else
                        counter = 0;
                }                    
            }
            Console.WriteLine("Clustering complete");
            Console.WriteLine("Weights");
            for(int i = 0; i < w.Length; i++)
            {
                Console.Write(w[i] + " ");
            }
            Console.WriteLine();
            return standards;
        }
    }
}

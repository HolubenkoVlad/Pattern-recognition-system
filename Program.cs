using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] images = new int[,]
            //{
            //    {2,2}, {4,3}, {3,2}, {2,3}, {4,2},
            //    {5,2}, {4,4}, {4,5}, {5,4}, {3,3},
            //};
            int[,] images = new int[,]
            {
                {2,2,2,2},{3,4,4,4},{5,5,5,5},  {3,4,4,3}, {5,5,4,5},
                {3,5,4,2}, {5,4,4,5}, {3,2,4,2}, {5,5,2,5}, {4,4,4,4},{2,2,5,3}, {2,2,2,3},{5,4,2,3},{2,3,3,3},{5,4,5,5}
            };
            Training training = new Training(images, 3);
            double[,] standards = training.Start();
            Console.WriteLine("Standards:");
            for (int i = 0; i < standards.GetLength(0); i++)
            {
                Console.Write("E " + i+":  ");
                for (int j = 0; j < standards.GetLength(1); j++)
                    Console.Write(standards[i, j]+" ");
                Console.WriteLine();
            }
            char flag = 'y';
            int result;
            int[] ratings;
            while (flag == 'y')
            {
                try
                {
                    Console.Write("Enter ratings: ");
                    ratings = Console.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray();
                    result = Distance.MinimumDistance(ratings, standards);
                    if (result == 0)
                        Console.WriteLine("This is untrained!");
                    if (result == 1)
                        Console.WriteLine("It is doing well!");
                    if (result == 2)
                        Console.WriteLine("Nice one!");
                    Console.WriteLine("Press y to continue");
                    flag = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("You have same trouble! Try again");
                }
            }
        }
    }
}

using System;
using System.IO;

namespace al_project
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "in.txt";

            StreamReader reader = new StreamReader(path);

            int count = Convert.ToInt32(reader.ReadLine());
            
            reader.Close();
            
            count = count * count;
            
            int[,] sudoku = new int[count , count];

            readFromFile(path , ref sudoku);

            print(sudoku);

        }

        static void print(int [,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();

            }
        }

        static void readFromFile(string path ,ref int[,] arr)
        {
            StreamReader reader = new StreamReader(path);

            int count = Convert.ToInt32(reader.ReadLine());

            string line;

            int i = 0;

            while (!reader.EndOfStream)
            {

                line = reader.ReadLine();

                string[] tmp = new string[count];

                tmp = line.Split(' ');

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = Convert.ToInt32(tmp[j]);
                }

                i++;

            }

            reader.Close();
        }
    }
}

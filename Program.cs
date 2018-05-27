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
            
            count = count * count;
            
            int[,] sudoku = new int[count , count];
            
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }

            Console.WriteLine(sudoku.Length);
            
            reader.Close();
        
        }
    }
}

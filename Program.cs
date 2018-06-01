using System;
using System.IO;
using System.Collections.Generic;

namespace al_project
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "in.txt";

            StreamReader reader = new StreamReader(path);

            int count = Convert.ToInt32(reader.ReadLine());
            int tmpCount = count;
            
            reader.Close();
            
            count = count * count;
            
            CustomNode[,] sudoku = new CustomNode[count , count];

            readFromFile(path , ref sudoku);

            print(sudoku);

            addValues(ref sudoku , (tmpCount));


        }


        static void readFromFile(string path, ref CustomNode[,] arr)
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
                    arr[i, j] = new CustomNode(Convert.ToInt32(tmp[j]));
                }

                i++;

            }

            reader.Close();
        }

        static void print(CustomNode [,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j].data + " ");
                }

                Console.WriteLine();

            }
        }

        
        static void addValues(ref CustomNode [,] arr , int count)
        {
            //this ExtraNode is tmp for check values in rows and columns
            List<int> tmp = new List<int>();
            //ExtraNode tmp = new ExtraNode();
            // ExtraNode ptr = tmp;
            for (int i = 1; i <= arr.GetLength(0); i++)
            {
                tmp.Add(i);
            }
            

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    
                    if (Convert.ToInt32(arr[i, j].data) == 0)
                    {
                        //ExtraNode Newptr;
                        //for top
                        for (int k = i-1; k >= 0; k--)
                        {
                            if (tmp.Contains(Convert.ToInt32(arr[k, j].data)))
                            {
                                tmp.Remove(Convert.ToInt32(arr[k, j].data));
                            }
                        }

                        //for right
                        for (int k = j + 1; k <= arr.GetLength(0) - 1 ; k++)
                        {
                            if (tmp.Contains(Convert.ToInt32(arr[i, k].data)))
                            {
                                tmp.Remove(Convert.ToInt32(arr[i, k].data));
                            }
                        }


                        //for bottom
                        for (int k = i + 1; k <= arr.GetLength(0) - 1; k++)
                        {
                            if (tmp.Contains(Convert.ToInt32(arr[k, j].data)))
                            {
                                tmp.Remove(Convert.ToInt32(arr[k, j].data));
                            }
                        }


                        //for left
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (tmp.Contains(Convert.ToInt32(arr[i, k].data)))
                            {
                                tmp.Remove(Convert.ToInt32(arr[i, k].data));
                            }
                        }

                        // for environment of a block

                        int x = (int)(i / count) * count;
                        int y = (int)(j / count) * count;
                        for (int k = x; k < x+count; k++)
                        {
                            for (int p = y; p < y+count; p++)
                            {
                                if (tmp.Contains(Convert.ToInt32(arr[k, p].data)))
                                {
                                    tmp.Remove(Convert.ToInt32(arr[k, p].data));
                                }
                            }
                        }


                        //for insert values
                        foreach (int item in tmp)
                        {
                            arr[i,j].values.Add(item);
                        }

                        //for reset ExtraNode tmp for check values in rows and columns
                        tmp.Clear();
                        for (int z = 1; z <= arr.GetLength(0); z++)
                        {
                            tmp.Add(z);
                        }

                    }//end if block

                    
                    

                }

            }
            
        }
        
    }
}

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
            
            CustomNode[,] sudoku = new CustomNode[count , count];

            readFromFile(path , ref sudoku);

            print(sudoku);

            addValues(ref sudoku);

            Console.ReadLine();

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

        
        static void addValues(ref CustomNode [,] arr)
        {
            //this ExtraNode is tmp for check values in rows and columns
            ExtraNode tmp = new ExtraNode();
            ExtraNode ptr = tmp;
            for (int i = 1; i <= arr.GetLength(0); i++)
            {
                ptr.data = i;
                ptr.next = new ExtraNode();
                ptr = ptr.next;
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    
                    if (Convert.ToInt32(arr[i, j].data) == 0)
                    {
                        ExtraNode Newptr;
                        //for top
                        for (int k = i-1; k >= 0; k--)
                        {
                            Newptr = tmp;
                            while (Newptr.next != null)
                            {
                                if (Convert.ToInt32(Newptr.data) == Convert.ToInt32(arr[k, j].data))
                                {
                                    Newptr.check = true;
                                    break;
                                }
                                Newptr = Newptr.next;
                            }
                        }

                        //for right
                        for (int k = j + 1; k <= arr.GetLength(0) - 1 ; k++)
                        {
                            Newptr = tmp;
                            while (Newptr.next != null)
                            {
                                if (Convert.ToInt32(Newptr.data) == Convert.ToInt32(arr[i, k].data))
                                {
                                    Newptr.check = true;
                                    break;
                                }
                                Newptr = Newptr.next;
                            }
                        }


                        //for bottom
                        for (int k = i + 1; k <= arr.GetLength(0) - 1; k++)
                        {
                            Newptr = tmp;
                            while (Newptr.next != null)
                            {
                                if (Convert.ToInt32(Newptr.data) == Convert.ToInt32(arr[k, j].data))
                                {
                                    Newptr.check = true;
                                    break;
                                }
                                Newptr = Newptr.next;
                            }
                        }


                        //for left
                        for (int k = j - 1; k >= 0; k--)
                        {
                            Newptr = tmp;
                            while (Newptr.next != null)
                            {
                                if (Convert.ToInt32(Newptr.data) == Convert.ToInt32(arr[i, k].data))
                                {
                                    Newptr.check = true;
                                    break;
                                }
                                Newptr = Newptr.next;
                            }
                        }

                        //for insert values
                        ExtraNode tmpPtr = tmp;
                        arr[i, j].values = new Node();
                        Node valuesPtr = arr[i, j].values;
                        while (tmpPtr.next != null)
                        {
                            if (tmpPtr.check == false)
                            {
                                valuesPtr.data = tmpPtr.data;
                                valuesPtr.next = new Node();
                                valuesPtr = valuesPtr.next;
                            }
                            tmpPtr = tmpPtr.next;
                        }

                        //for reset ExtraNode tmp for check values in rows and columns
                        ptr = tmp;
                        for (int p = 1; p <= arr.GetLength(0); p++)
                        {
                            ptr.check = false;
                            ptr = ptr.next;
                        }

                    }//end if block

                    
                    

                }

            }
            
        }
        
    }
}

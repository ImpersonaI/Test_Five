using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq.Expressions;
using System.Xml;

namespace Test_four
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0, m = 0;
            int im = 0;

            Console.WriteLine("Input n");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input m");
            m = Convert.ToInt32(Console.ReadLine());

            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;

            var new_out1 = new StreamWriter(@"input.txt");
            Console.SetOut(new_out1);

            int[,] array = new int[n,m];
            int[] arrrayM = new int[m];
            int[] arrayim = new int[m];
            Console.WriteLine("n = " + n);
            Console.WriteLine("m = " + m);


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    //Создание объекта для генерации чисел
                    Random rnd = new Random();

                    array[i, j] = rnd.Next(-25, 35);
                    if (array[i,j] % 2 != 0)
                    {

                        arrrayM[j] += array[i,j];
                        arrayim[j]++;
                    }
                    

                    Console.Write(array[i, j] + " \t");

                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.SetOut(save_out); new_out1.Close();


            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);
                       

            try
            {

                Console.WriteLine("Исходный массив");
                //Вывод исходного массива
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {

                        Console.Write(array[i, j] + " \t");

                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                //Среднее по столбцам
                Console.WriteLine("Среднее ариф. по столбцам");

                for (int i = 0; i < m; i++)
                {


                    Console.Write(arrrayM[i] / arrayim[i] + " ");
                }

                Console.WriteLine();
                Console.WriteLine("Модиф. массив");
                //Вывод мод. массива
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (array[i, j] % 3 == 0)
                        {

                            Console.Write("3" + " \t");
                        }

                        if (array[i, j] % 7 == 0)
                        {

                            Console.Write("7" + " \t");
                        }

                        if (array[i, j] % 3 != 0 && array[i, j] % 7 != 0)
                        {

                            Console.Write("0" + " \t");
                        }


                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
            Console.ReadKey();
        }
    }
}

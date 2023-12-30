using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Prog1()
        {
            Console.Write("Введите длину массива: ");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            Console.WriteLine($"Введите {length} чисел для массива через пробел:");
            //for (int i = 0; i < length; i++)
            //{
            //    Console.Write($"Введите элемент с индексом {i}: ");
            //    arr[i] = int.Parse(Console.ReadLine());
            //}

            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            Console.Write("Введенный массив:\n[");

            for (int i = 0; i < length - 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write(arr[length - 1] + "]\n");
            // Переменные для хранения количества отрицательных элементов и элементов, принадлежащих отрезку [1, 2]
            int countNegative = 0;
            int countInRange = 0;
            // Проходим по всем элементам массива
            for (int i = 0; i < arr.Length; i++)
            {
                // Проверяем, является ли элемент отрицательным
                if (arr[i] < 0)
                {
                    countNegative++;
                }
                // Проверяем, принадлежит ли элемент отрезку [1, 2]
                if (arr[i] >= 1 && arr[i] <= 2)
                {
                    countInRange++;
                }
            }
            // Выводим результаты
            Console.WriteLine("Количество отрицательных элементов: " + countNegative);
            Console.WriteLine("Количество элементов, принадлежащих отрезку [1, 2]: " + countInRange);
            // Ожидаем нажатия клавиши, чтобы консоль не закрылась сразу
            //Console.ReadKey();
        }
        static void Prog2()
        {
            Console.Write("Введите количество строк (n): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов (m): ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            int count = 0;
            Console.WriteLine("Введите элементы матрицы:");
            // Считываем элементы в матрицу
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите элементы через пробел для {i + 1} строки: ");
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                    // Проверка чисел на положительные
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"Количество положительных элементов в матрице равно: {count}");

            //Console.ReadKey(); типо ожидает нажатия клавиши, чтобы консоль не закрывалась
        }
        static void Main()
        {

            Console.Title = "The standard program for C#";
            string choice;
            bool flag = true;
            do
            {
                Console.Write("\n1 - Запускает функцию Prog1()\n2 - Запускает функцию Prog2()\n3 - Выход из программы.\nВведите число: ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Prog1();
                }
                else if (choice == "2")
                {
                    Prog2();
                }
                else if (choice == "3")
                {
                    flag = false;
                }
                else
                {
                    //Console.WriteLine("Ошибка ввода!\n");
                    Console.Error.WriteLine("Ошибка ввода!!!");
                }
            } while (flag);
        }
    }
}

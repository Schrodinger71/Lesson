namespace ConsoleBanApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Generation Ban List";
            List<string> nicknames = new List<string>();
            string nickname;

            Console.WriteLine("Введите никнеймы. Когда закончите, введите 'Ex':");

            while (true)
            {
                nickname = Console.ReadLine();
                if (nickname == "Ex")
                {
                    break;
                }
                nicknames.Add(nickname);
            }

            foreach (var name in nicknames)
            {
                Console.WriteLine("ban " + name + " Набегатор 0");
            }

            Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
            Console.ReadKey(); // Для остановки консоли после вывода сообщений
        }
    }
}


//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        List<string> nicknames = new List<string>();
//        string nickname;

//        Console.WriteLine("Введите никнеймы. Когда закончите, введите 'Ex':");

//        while (true)
//        {
//            nickname = Console.ReadLine();
//            if (nickname == "Ex")
//            {
//                break;
//            }
//            nicknames.Add(nickname);
//        }

//        foreach (var name in nicknames)
//        {
//            Console.WriteLine("ban " + name + " Набегатор 0");
//        }

//        Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
//        Console.ReadKey(); // Для остановки консоли после вывода сообщений
//    }
//}
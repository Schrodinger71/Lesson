using System.ComponentModel;

namespace ConsoleRedactionChangLogTextApp
{
    internal class Program
    {

        static void F()
        {
            Console.Write("Введите ваш никнейм: ");
            var Name = Console.ReadLine();
            Console.WriteLine("Введите ваши изменения: ");
            Console.WriteLine("Введите ваши изменения (для завершения ввода нажмите Enter дважды): ");
            List<string> lines = new List<string>(); // Используем List<string> для динамического добавления строк

            while (true)
            {
                string line = Console.ReadLine(); // Считываем введенную строку
                if (string.IsNullOrEmpty(line)) // Если строка пустая, завершаем ввод
                    break;
                lines.Add(line); // Добавляем строку в список
            }

            string[] arr_str = lines.ToArray(); // Преобразуем список в массив

            // Получаем текущее время в UTC
            DateTime timeUtc = DateTime.UtcNow;

            // Преобразуем время в часовой пояс UTC+3
            DateTime timeUtc3 = timeUtc.AddHours(3);


            while (true)
            {
                Console.WriteLine($"- author: {Name}\n  changes:");
                foreach( string line in arr_str )
                {
                    Console.WriteLine($"  - {{ message: \"{line}\", type: Add}}");
                }
                Console.WriteLine($"  id: 55710");
                Console.WriteLine($"  time: '{timeUtc3.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK")}'");
                break;
            }

        }

        static void Main(string[] args)
        {
            Console.Title = "Changelog";
            var fl = true;

            do
            {
                Console.Write("Введите 1 для начала программы или 0, чтобы выйти из неё: ");
                var number = Console.ReadLine();

                switch (number)
                {
                    case "1":
                        F();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine("case 3");
                        break;
                    case "3":
                        Console.WriteLine("case 5");
                        break;
                    case "0":
                        fl = false;
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }

            } while (fl);



            Console.ReadKey();
        }
    }
}

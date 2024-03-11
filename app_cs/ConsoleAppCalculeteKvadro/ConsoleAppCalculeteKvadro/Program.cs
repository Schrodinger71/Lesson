using System.Runtime.InteropServices;
using System.Text;
namespace ConsoleAppCalculeteKvadro;
internal class Program
{
    private static void Main(string[] args)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
        }

        Console.Title = "Решаем квадратное уравнение";
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Clear();
        Console.Beep();

        double a, b, c, d, x1, x2;
        try
        {
            Console.Write("Введите a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите c: ");
            c = Convert.ToDouble(Console.ReadLine());
            d = b * b - 4 * a * c;
            if (d > 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                if (double.IsNaN(x1) || double.IsInfinity(x1) || double.IsNaN(x2) || double.IsInfinity(x2))
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Корней нет");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("x1 = {0:0.00}, x2 = {1:0.00}", x1, x2);
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Нет решения!");
            }
        }
        catch (Exception)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Ошибка в данных!");
        }
        Console.ResetColor();
        Console.ReadLine();
    }
}
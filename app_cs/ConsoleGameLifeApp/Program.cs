using System.Data;
using System.Data.Common;

namespace ConsoleGameLifeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();

            var gameEngine = new GameLifeEngine
            (
                rows: 50,
                cols: 50,
                density: 2
            );

            while(true)
            {
                Console.Title = gameEngine.currentGeneration.ToString();
                Console.CursorVisible = false;

                var field = gameEngine.GetCurrentGeneration();

                for (int i = 0; i < field.GetLength(1); i++)
                {
                    var str = new char[field.GetLength(0)];
                    for(int x = 0; x < field.GetLength(0); x++)
                    {
                        if (field[x, i])
                            str[x] = '#';
                        else
                            str[x] = ' ';
                    }
                    Console.WriteLine(str);
                }

                Console.SetCursorPosition(0, 0);

                gameEngine.NextGeneration();
            }


            //GameLifeEngine 
        }
    }
}

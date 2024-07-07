using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameLifeApp
{
    internal class GameLifeEngine
    {

        public uint currentGeneration { get; private set; }
        //private int currentGeneration = 0;
        private bool[,] field;
        private readonly int rows;
        private readonly int cols;



        public GameLifeEngine(int rows, int cols, int density)
        {

            this.rows = rows;
            this.cols = cols;
            field = new bool[cols, rows];

            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next(density) == 0;
                }
            }

        }

        public void NextGeneration()
        {
            //graphics.Clear(Color.Black);

            var newField = new bool[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var neighboursCount = CountNeigbours(x, y);
                    var hasLife = field[x, y];

                    if (!hasLife && neighboursCount == 3)
                        newField[x, y] = true;
                    else if (hasLife && (neighboursCount < 2 || neighboursCount > 3))
                        newField[x, y] = false;
                    else
                        newField[x, y] = field[x, y];


                    //if (hasLife)
                    //graphics.FillRectangle(Brushes.Crimson, x * resolution, y * resolution, resolution - 1, resolution - 1);

                }
            }
            field = newField;
            currentGeneration++;
            //pictureBox1.Refresh();
            //textBoxGeneration.Text = $"{++currentGeneration}";
        }

        public bool[,] GetCurrentGeneration()
        {
            var result = new bool[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    result[x, y] = field[x, y];
                }
            }
            return field;
        }

        private int CountNeigbours(int x, int y)
        {

            int count = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var col = (x + i + cols) % cols;
                    var row = (y + j + rows) % rows;


                    bool isSelfChecking = col == x && row == y;
                    var hasLife = field[col, row];


                    if (hasLife && !isSelfChecking)
                        count++;
                }
            }

            return count;
        }

        private bool ValidateCellPosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < cols && y < rows;
        }

        private void UpdateCell(int x, int y, bool state)
        {
            if (ValidateCellPosition(x, y))
                field[x, y] = state;

        }

        public void AddCell(int x, int y)
        {
            UpdateCell(x, y, true);
        }

        public void RemoveCell(int x, int y)
        {
            UpdateCell(x, y, false);
        }
    }
}

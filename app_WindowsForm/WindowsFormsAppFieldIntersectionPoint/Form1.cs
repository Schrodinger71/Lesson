using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using TextBox = System.Windows.Forms.TextBox;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TextBox[] textBoxes;
        public Form1()
        {
            InitializeComponent();
            textBoxes = new TextBox[] { onePointX1, onePointX2, onePointY1, onePointY2, 
                secondPointX1, secondPointX2, secondPointY1, secondPointY2 };

            this.ActiveControl = onePointX1; //курсор в первом тектовом поле при инициализации

            CheckIfTextAndLockButton();

            foreach (TextBox textBox in textBoxes)
            {
                textBox.TextChanged += TextBox_TextChanged;
            }
        }


        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            CheckIfTextAndLockButton();
        }
        private void CheckIfTextAndLockButton()
        {
            startCalculateButton.Enabled = !textBoxes.Any(textBox => IsTextBoxEmpty(textBox));
        }
        private bool IsTextBoxEmpty(TextBox textBox)
        {
            return string.IsNullOrEmpty(textBox.Text);
        }


        /// <summary>
        /// Просто тупо очищает все поля <c>TextBox</c> циклом foreach
        /// </summary>
        private void ClearTextBoxes()
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        /// <summary>
        /// Проверяет, что все текстовые поля содержат целочисленные значения. <para></para> 
        /// Если хотя бы одно поле не содержит целочисленный тип, выводит сообщение об ошибке и прерывает выполнения вычислений в startCalculateButton_Click().
        /// </summary>
        private bool CheckIfAllTextFieldsAreNumbers()
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (!double.TryParse(textBox.Text, out _) && !int.TryParse(textBox.Text, out _))
                {
                    MessageBox.Show("Пожалуйста, введите числовое значение во все поля!", "Error!!!");
                    return false;
                    
                }
            }

            return true;
        }


        public void FieldIntersectionPoint(double x1, double x2, double x3, double x4,
            double y1, double y2, double y3, double y4)
        {
            //Уравнение прямой в общем виде имеет вид y = mx + b, где m - это коэффициент наклона прямой, а b - это коэффициент сдвига по оси y.
            //Для каждой из прямых мы можем найти значения коэффициентов m и b по формулам:
            //  Для первой прямой: 
            //  m1 = (y2 - y1) / (x2 - x1)
            //  b1 = y1 - m1 * x1
            //  Для второй прямой: 
            //  m2 = (y4 - y3) / (x4 - x3)
            //  b2 = y3 - m2 * x3

            //Теперь у нас есть уравнения двух прямых в виде y = m1 * x + b1 и y = m2 * x + b2.
            //Для нахождения точки пересечения этих прямых, нужно решить систему уравнений:
            //  m1 * x + b1 = m2 * x + b2
            //  m1 * x + b1 = m2 * x + b2

            double m1 = (y2 - y1) / (x2 - x1);
            if (x2 == x1) m1 = 1100000000000000;
            double b1 = y1 - m1 * x1;

            double m2 = (y4 - y3) / (x4 - x3);
            if (x4 == x3) m2 = 1100000000000000;
            double b2 = y3 - m2 * x3;

            if (m1 == m2)
            {
                MessageBox.Show("Прямые параллельны, нет точки пересечения.");
            }
            else
            {
                double x = (b2 - b1) / (m1 - m2);
                double y = m1 * x + b1;

                MessageBox.Show($"Точка пересечения: ({x} | {y})");
            }
        }

        //public void FieldIntersectionPoint(double x1, double x2, double x3, double x4, double y1, double y2, double y3, double y4)
        //{
        //    double[,] A = { { (y2 - y1), -(x2 - x1) }, { (y4 - y3), -(x4 - x3) } };
        //    double[] b = { y1 * (x2 - x1) - x1 * (y2 - y1), y3 * (x4 - x3) - x3 * (y4 - y3) };

        //    double detA = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
        //    if (detA == 0)
        //    {
        //        MessageBox.Show("Прямые параллельны, нет точки пересечения.");
        //    }
        //    else
        //    {
        //        double[] intersection = { (b[0] * A[1, 1] - b[1] * A[0, 1]) / detA, (A[0, 0] * b[1] - A[1, 0] * b[0]) / detA };
        //        MessageBox.Show($"Точка пересечения: ({intersection[0]} | {intersection[1]})");
        //    }
        //}

        private void startCalculateButton_Click(object sender, EventArgs e)
        {
            if (CheckIfAllTextFieldsAreNumbers())
            {
                double x1 = Double.Parse(onePointX1.Text);
                double x2 = Double.Parse(onePointX2.Text);
                double y1 = Double.Parse(onePointY1.Text);
                double y2 = Double.Parse(onePointY2.Text);

                double x3 = Double.Parse(secondPointX1.Text);
                double x4 = Double.Parse(secondPointX2.Text);
                double y3 = Double.Parse(secondPointY1.Text);
                double y4 = Double.Parse(secondPointY2.Text);

                FieldIntersectionPoint(x1, x2, x3, x4, y1, y2, y3, y4);
            }
        }
    }
}

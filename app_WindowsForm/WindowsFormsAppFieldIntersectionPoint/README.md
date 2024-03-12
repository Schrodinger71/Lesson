-----------------------------
# Код с интерфейсом Windows Forms для нахождения точки пересечения двух отрезков

Этот код представляет собой простое приложение Windows Forms, которое позволяет пользователю вводить координаты четырех точек и находить точку их пересечения. Вот краткое описание каждого элемента кода:

## Поля и методы

1. textBoxes - массив, содержащий все текстовые поля для ввода координат.

2. Form1() - конструктор формы, инициализирует компоненты формы, устанавливает курсор в первом текстовом поле и привязывает обработчики событий для изменения текста в полях.

3. TextBox_TextChanged - обработчик события изменения текста в текстовом поле, вызывает метод CheckIfTextAndLockButton.

4. CheckIfTextAndLockButton - проверяет, все ли текстовые поля заполнены, и блокирует или разблокирует кнопку для запуска расчетов.

5. IsTextBoxEmpty - проверяет, пусто ли указанное текстовое поле.

6. ClearTextBoxes - очищает все текстовые поля.

7. ClearButton_Click - обработчик события нажатия на кнопку очистки полей, вызывает метод ClearTextBoxes.

8. CheckIfAllTextFieldsAreNumbers - проверяет, содержат ли все текстовые поля числовые значения.

9. FieldIntersectionPoint - метод для расчета точки пересечения двух отрезков по их координатам.

10. startCalculateButton_Click - обработчик события нажатия на кнопку расчета, вызывает методы проверки числовых значений и нахождения точки пересечения.

<details>
<summary>Код в файле Form.cs</summary>

```cs
﻿using System;
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

            this.ActiveControl = onePointX1; //курсор в первом тектовом поле при инизиализации

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
        /// Если хотя бы одно поле не содержит целочисленный тип, выводит сообщение об ошибке и прерывает выполнение метода.
        /// </summary>
        private void CheckIfAllTextFieldsAreNumbers()
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (!double.TryParse(textBox.Text, out _) && !int.TryParse(textBox.Text, out _))
                {
                    MessageBox.Show("Пожалуйста, введите числовое значение во все поля!", "Error!!!");
                    return;
                }
            }
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

                MessageBox.Show($"Точка пересечения: ({x}, {y})");
            }
        }

        private void startCalculateButton_Click(object sender, EventArgs e)
        {
            CheckIfAllTextFieldsAreNumbers();

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
```
</details>

## Документация

### Описание приложения
Данное приложение позволяет пользователю вводить координаты четырех точек и находить точку пересечения отрезков, соединяющих эти точки.

### Интерфейс
Пользователь видит четыре группы текстовых полей, предназначенных для ввода координат x и y для каждой из четырех точек. После заполнения всех полей, он может нажать кнопку "Рассчитать", чтобы найти точку пересечения отрезков.
![image](https://github.com/Schrodinger71/Lesson/assets/132720404/aeeaf5d8-eb00-4f5b-8aa9-ac9e2b76bb14)

### Методика работы
1. Пользователь вводит координаты четырех точек в соответствующие текстовые поля.
2. При вводе каждого символа в любое из полей происходит проверка на наличие пустых полей. Если все поля заполнены, кнопка "Рассчитать" становится активной.
3. При нажатии на кнопку "Рассчитать" происходит следующее:
   - Проверяется, что все введенные значения являются числами.
   - Вычисляется точка пересечения двух отрезков по заданным координатам.
   - Если отрезки параллельны, выводится сообщение об этом.
   - В противном случае выводится координата точки пересечения.

### Обработка ошибок
Если одно или несколько полей содержат нечисловые значения, пользователю выводится сообщение об ошибке, и выполнение расчетов прерывается.

### Завершение работы
Пользователь может очистить все поля, нажав кнопку "Очистить". Это позволяет ему начать новый расчет с другими значениями.

Этот код предоставляет простой способ для пользователей визуализировать и вычислять точку пересечения двух отрезков на плоскости.

-------------------------------




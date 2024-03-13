using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WindowsFormsAppCalculateLab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вводимых чисел и результата
            double x, y, z = 0;
            //Преобразуем текст из числовых полей в переменные Double
            x = Convert.ToDouble(firsTextBox.Text);
            y = Convert.ToDouble(secondTextBox.Text);
            //Выполняем операцию, тип которой определяется
            //на основе проверки значений св-ва Checked переключателей
            if (radioButton_Summ.Checked) z = x + y;
            if (radioButton_Vechsty.Checked) z = x - y;
            if (radioButton_umnojity.Checked) z = x * y;
            //В случае деления надо убедиться, что 2-е число 
            //не равно нулю.
            if (radioButton_Razdelit.Checked)
                if (y != 0)
                    z = x / y;
                else
                    MessageBox.Show("На нуль делить нельзя!", "Ошибка");
            //Преобразуем значение переменной z из типа Double 
            //в строку и выводим ее в текстовое поле результата
            thistTextBoxResult.Text = Convert.ToString(z);

            //Проверяем флажок и, если он выбран, формируем строку 
            //в текстовом поле результата. 
            //Иначе выводим только одно число z
            if (checkBox1.Checked)
            {
                string str_x = Convert.ToString(x);
                string str_y = Convert.ToString(y);
                string str_z = Convert.ToString(z);
                if (radioButton_Summ.Checked) thistTextBoxResult.Text = str_x + "+" + str_y + "=" + str_z;
                if (radioButton_Vechsty.Checked) thistTextBoxResult.Text = str_x + "-" + str_y + "=" + str_z;
                if (radioButton_umnojity.Checked) thistTextBoxResult.Text = str_x + "*" + str_y + "=" + str_z;
                if (radioButton_Razdelit.Checked && y != 0) thistTextBoxResult.Text = str_x + "/" + str_y + "="
               + str_z;
            }
            else
                thistTextBoxResult.Text = Convert.ToString(z);

        }
    }
}

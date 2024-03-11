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

namespace WindowsFormsAppLab7_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBoxLeft.SelectionMode = SelectionMode.MultiExtended;
            listBoxRight.SelectionMode = SelectionMode.MultiExtended;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBoxLeft.Items.Add(textBoxHead.Text);
            textBoxHead.Clear();

        }
        //private void buttonDelete_Click(object sender, EventArgs e)
        //{
        //    // Создаем список для хранения выбранных элементов
        //    List<string> selectedItems = new List<string>();
        //    // Добавляем выбранные элементы из listBoxLeft в список selectedItems
        //    foreach (var selectedItem in listBoxLeft.SelectedItems)
        //    {
        //        selectedItems.Add(selectedItem.ToString());
        //    }
        //    foreach (var selectedItem in listBoxRight.SelectedItems)
        //    {
        //        selectedItems.Add(selectedItem.ToString());
        //    }
        //    // Удаляем выбранные элементы из listBoxLeft
        //    foreach (string item in selectedItems)
        //    {
        //        listBoxLeft.Items.Remove(item);
        //        listBoxRight.Items.Remove(item);
        //    }
        //}

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Создаем список для хранения выбранных элементов
            List<string> selectedItems = new List<string>();
            // Добавляем выбранные элементы из listBoxLeft в список selectedItems
            foreach (var selectedItem in listBoxLeft.SelectedItems)
            {
                selectedItems.Add(selectedItem.ToString());
            }
            // Удаляем выбранные элементы из listBoxLeft
            foreach (string item in selectedItems)
            {
                listBoxLeft.Items.Remove(item);
            }

            // Очищаем список выбранных элементов
            selectedItems.Clear();

            // Добавляем выбранные элементы из listBoxRight в список selectedItems
            foreach (var selectedItem in listBoxRight.SelectedItems)
            {
                selectedItems.Add(selectedItem.ToString());
            }
            // Удаляем выбранные элементы из listBoxRight
            foreach (string item in selectedItems)
            {
                listBoxRight.Items.Remove(item);
            }
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (listBoxLeft.SelectedItems.Count > 0)
            {
                List<string> selectedItems = new List<string>();
                foreach (var item in listBoxLeft.SelectedItems)
                {
                    selectedItems.Add(item.ToString());
                }

                foreach (var item in selectedItems)
                {
                    listBoxLeft.Items.Remove(item);
                    listBoxRight.Items.Add(item);
                }
            }
            else if (listBoxRight.SelectedItems.Count > 0)
            {
                List<string> selectedItems = new List<string>();
                foreach (var item in listBoxRight.SelectedItems)
                {
                    selectedItems.Add(item.ToString());
                }

                foreach (var item in selectedItems)
                {
                    listBoxRight.Items.Remove(item);
                    listBoxLeft.Items.Add(item);
                }
            }
        }
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int sum = 0;

            if (listBoxLeft.SelectedItems.Count > 0) // Проверяем, выбраны ли элементы в listBoxLeft
            {
                foreach (var item in listBoxLeft.SelectedItems)
                {
                    if (!int.TryParse(item.ToString(), out _))
                    {
                        MessageBox.Show("Пожалуйста, выберите целочисленное значение во всех полях!", "Error!!!");
                        return;
                    }
                    sum += Convert.ToInt32(item);
                }
            }
            else if (listBoxRight.SelectedItems.Count > 0) // Проверяем, выбраны ли элементы в listBoxRight
            {
                foreach (var item in listBoxRight.SelectedItems)
                {
                    if (!int.TryParse(item.ToString(), out _))
                    {
                        MessageBox.Show("Пожалуйста, выберите целочисленное значение во всех полях!", "Error!!!");
                        return;
                    }
                    sum += Convert.ToInt32(item);
                }
            }
            else
            {
                MessageBox.Show("Выберите элементы для подсчёта суммы.", "Предупреждение");
                return;
            }

            MessageBox.Show($"Сумма выбранных элементов равна: {sum}", "Подсчёт.");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!listBoxLeft.ClientRectangle.Contains(listBoxLeft.PointToClient(Cursor.Position)) &&
                !listBoxRight.ClientRectangle.Contains(listBoxRight.PointToClient(Cursor.Position)))
            {
                listBoxLeft.ClearSelected();
                listBoxRight.ClearSelected();
            }
        }

        private void listBoxRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxLeft.ClearSelected();
        }

        private void listBoxLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxRight.ClearSelected();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseDown += Form1_MouseDown;
        }
    }
}

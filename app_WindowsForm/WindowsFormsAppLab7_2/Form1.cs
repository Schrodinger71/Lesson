using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Создаем список для хранения выбранных элементов
            List<string> selectedItems = new List<string>();

            // Добавляем выбранные элементы из listBoxLeft в список selectedItems
            foreach (var selectedItem in listBoxLeft.SelectedItems)
            {
                selectedItems.Add(selectedItem.ToString());
            }

            foreach (var selectedItem in listBoxRight.SelectedItems)
            {
                selectedItems.Add(selectedItem.ToString());
            }

            // Удаляем выбранные элементы из listBoxLeft
            foreach (string item in selectedItems)
            {
                listBoxLeft.Items.Remove(item);
                listBoxRight.Items.Remove(item);
            }
        }


        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (listBoxLeft.SelectedItem != null)
            {
                string selectedItem = listBoxLeft.SelectedItem.ToString();
                listBoxLeft.Items.Remove(selectedItem);
                listBoxRight.Items.Add(selectedItem);
            }
            else if (listBoxRight.SelectedItem != null)
            {
                string selectedItem = listBoxRight.SelectedItem.ToString();
                listBoxRight.Items.Remove(selectedItem);
                listBoxLeft.Items.Add(selectedItem);
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int sum = 0;

            foreach (var item in listBoxLeft.Items)
            {
                sum += Convert.ToInt32(item);
            }

            MessageBox.Show($"Сумма равна: {sum}", "Подсчёт.");
        }
    }
}

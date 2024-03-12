# Код для переноса элементов между двумя ListBox'ами и подсчёта суммы выбранных элементов

## Описание
Этот код представляет собой простое приложение Windows Forms, которое позволяет пользователю добавлять элементы в два ListBox'a, удалять выбранные элементы, перемещать элементы между ListBox'ами и вычислять сумму выбранных элементов.

## Использование
- При нажатии на кнопку "Add" элемент, введённый в текстовое поле `textBoxHead`, добавляется в левый ListBox.
- При нажатии на кнопку "Delete" удаляются выбранные элементы из обоих ListBox'ов.
- При нажатии на кнопку "Move" выбранные элементы перемещаются из одного ListBox'a в другой.
- При нажатии на кнопку "Calculate" вычисляется сумма выбранных элементов в одном из ListBox'ов.

## Методы и обработчики событий
- `buttonAdd_Click`: Добавляет элемент в левый ListBox.
- `buttonDelete_Click`: Удаляет выбранные элементы из ListBox'ов.
- `buttonMove_Click`: Перемещает выбранные элементы между ListBox'ами.
- `buttonCalculate_Click`: Вычисляет сумму выбранных элементов и выводит её в MessageBox.
- `Form1_MouseDown`: Очищает выбранные элементы в ListBox'ах при клике вне них.
- `listBoxRight_SelectedIndexChanged` и `listBoxLeft_SelectedIndexChanged`: Очищают выбранные элементы в противоположном ListBox'e.
- `Form1_Load`: Подключает обработчик `Form1_MouseDown` к событию `MouseDown`.

## Другие методы
- В методе `buttonDelete_Click` используется список `List<string> selectedItems`, чтобы хранить выбранные элементы для удаления.
- В методе `buttonCalculate_Click` проверяется, выбраны ли элементы в ListBox'ах, и вычисляется сумма выбранных элементов.

## Дополнительная информация
- Левый и правый ListBox'ы поддерживают выделение нескольких элементов.
- Приложение предупреждает пользователя, если он выбирает элементы, не являющиеся целыми числами, при попытке вычислить сумму.

Этот пример демонстрирует простое использование ListBox'ов и работу с элементами в них в приложении Windows Forms.

<details>
<summary>Сам код в файле Form.cs</summary>

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
```
</details>

### Сама визуализация пользовательского интерфейса:
![image](https://github.com/Schrodinger71/Lesson/assets/132720404/50f5cb05-8249-4b8d-95c8-0aa474b73c64)

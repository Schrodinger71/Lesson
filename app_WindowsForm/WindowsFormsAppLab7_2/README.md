# Код для переноса элементов между двумя ListBox'ами и подсчёта суммы выбранных элементов

# Общее описание
Код в Form.cs представляет собой простое приложение Windows Forms, которое позволяет пользователю добавлять элементы в два ListBox'a, удалять выбранные элементы, перемещать элементы между ListBox'ами и вычислять сумму выбранных элементов.

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

# Описание кода

## Общая информация
Класс `Form1` представляет главную форму приложения Windows Forms\. В этом коде реализовано управление двумя списками элементов, их добавление, удаление, перемещение, а также вычисление суммы выбранных элементов\.

## Конструктор
```csharp
public Form1(){
    InitializeComponent();
    listBoxLeft.SelectionMode = SelectionMode.MultiExtended;
    listBoxRight.SelectionMode = SelectionMode.MultiExtended;
}
```
\- Конструктор класса `Form1` инициализирует компоненты формы и устанавливает режим выбора элементов для listBoxLeft и listBoxRight как `SelectionMode.MultiExtended`\.

## Методы

### buttonAdd\_Click
```csharp
private void buttonAdd_Click(object sender, EventArgs e){
    listBoxLeft.Items.Add(textBoxHead.Text);
    textBoxHead.Clear();
}
```
\- Метод `buttonAdd_Click` добавляет текст из `textBoxHead` в `listBoxLeft` и очищает `textBoxHead`\.

### buttonDelete\_Click
```csharp
private void buttonDelete_Click(object sender, EventArgs e){
    List<string> selectedItems = new List<string>();
    foreach (var selectedItem in listBoxLeft.SelectedItems){
        selectedItems.Add(selectedItem.ToString());
    }
    foreach (string item in selectedItems){
        listBoxLeft.Items.Remove(item);
    }
    selectedItems.Clear();
    
    foreach (var selectedItem in listBoxRight.SelectedItems){
        selectedItems.Add(selectedItem.ToString());
    }
    foreach (string item in selectedItems){
        listBoxRight.Items.Remove(item);
    }
}
```
\- Метод `buttonDelete_Click` удаляет выбранные элементы из `listBoxLeft` и `listBoxRight`\.

### buttonMove\_Click
```csharp
private void buttonMove_Click(object sender, EventArgs e){
    if (listBoxLeft.SelectedItems.Count > 0){
        List<string> selectedItems = new List<string>();
        foreach (var item in listBoxLeft.SelectedItems){
            selectedItems.Add(item.ToString());
        }
        foreach (var item in selectedItems){
            listBoxLeft.Items.Remove(item);
            listBoxRight.Items.Add(item);
        }
    } else if (listBoxRight.SelectedItems.Count > 0) {
        List<string> selectedItems = new List<string>();
        foreach (var item in listBoxRight.SelectedItems){
            selectedItems.Add(item.ToString());
        }
        foreach (var item in selectedItems) {
            listBoxRight.Items.Remove(item);
            listBoxLeft.Items.Add(item);
        }
    }
}
```
\- Метод `buttonMove_Click` перемещает выбранные элементы между `listBoxLeft` и `listBoxRight`\.

### buttonCalculate\_Click
```csharp
private void buttonCalculate_Click(object sender, EventArgs e){
    int sum = 0;
    if (listBoxLeft.SelectedItems.Count > 0) {
        foreach (var item in listBoxLeft.SelectedItems){
            if (!int.TryParse(item.ToString(), out _)) {
                MessageBox.Show("Пожалуйста, выберите целочисленное значение во всех полях!", "Error!!!");
                return;
            }
            sum += Convert.ToInt32(item);
        }
    } else if (listBoxRight.SelectedItems.Count > 0) {
        foreach (var item in listBoxRight.SelectedItems){
            if (!int.TryParse(item.ToString(), out _)){
                MessageBox.Show("Пожалуйста, выберите целочисленное значение во всех полях!", "Error!!!");
                return;
            }
            sum += Convert.ToInt32(item);
        }
    } else {
        MessageBox.Show("Выберите элементы для подсчёта суммы.", "Предупреждение");
        return;
    }
    MessageBox.Show($"Сумма выбранных элементов равна: {sum}", "Подсчёт.");
}
```
\- Метод `buttonCalculate_Click` вычисляет сумму выбранных элементов в `listBoxLeft` или `listBoxRight` и выводит результат в MessageBox\. Проверяется корректность ввода целочисленных значений\.

### Form1\_MouseDown
```csharp
private void Form1_MouseDown(object sender, MouseEventArgs e){
    if (!listBoxLeft.ClientRectangle.Contains(listBoxLeft.PointToClient(Cursor.Position)) &&
        !listBoxRight.ClientRectangle.Contains(listBoxRight.Point
ToClient(Cursor.Position))){
        listBoxLeft.ClearSelected();
        listBoxRight.ClearSelected();
    }
}
```
- Метод `Form1_MouseDown` очищает выбранные элементы в `listBoxLeft` и `listBoxRight`, если произошло нажатие мыши вне области списков\.

### listBoxRight\_SelectedIndexChanged и listBoxLeft\_SelectedIndexChanged
```csharp
private void listBoxRight_SelectedIndexChanged(object sender, EventArgs e){
    listBoxLeft.ClearSelected();
}

private void listBoxLeft_SelectedIndexChanged(object sender, EventArgs e){
    listBoxRight.ClearSelected();
}
```
\- Методы `listBoxRight_SelectedIndexChanged` и `listBoxLeft_SelectedIndexChanged` очищают выбранные элементы в противоположном списке при изменении выбора\.

### Form1\_Load
```csharp
private void Form1_Load(object sender, EventArgs e){
    this.MouseDown += Form1_MouseDown;
}
```
\- Метод `Form1_Load` добавляет обработчик события `MouseDown` для формы\.

## Дополнительная информация

- В коде реализовано управление двумя списками элементов с возможностью добавления, удаления, перемещения и вычисления суммы выбранных элементов.
- При вычислении суммы проверяется корректность ввода целочисленных значений.
- При нажатии мыши вне области списков, выбранные элементы очищаются.
- При изменении выбора элементов в одном списке, выбор в другом списке очищается.

Этот код предоставляет пример использования списков и базовых операций с ними в Windows Forms\.


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

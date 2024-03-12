
\# Описание кода

\#\# Общая информация
Класс `Form1` представляет главную форму приложения Windows Forms\. В этом коде реализовано управление двумя списками элементов, их добавление, удаление, перемещение, а также вычисление суммы выбранных элементов\.

\#\# Конструктор
```csharp
public Form1(){
    InitializeComponent();
    listBoxLeft.SelectionMode = SelectionMode.MultiExtended;
    listBoxRight.SelectionMode = SelectionMode.MultiExtended;
}
```
\- Конструктор класса `Form1` инициализирует компоненты формы и устанавливает режим выбора элементов для listBoxLeft и listBoxRight как `SelectionMode.MultiExtended`\.

\#\# Методы

\#\#\# buttonAdd\_Click
```csharp
private void buttonAdd_Click(object sender, EventArgs e){
    listBoxLeft.Items.Add(textBoxHead.Text);
    textBoxHead.Clear();
}
```
\- Метод `buttonAdd_Click` добавляет текст из `textBoxHead` в `listBoxLeft` и очищает `textBoxHead`\.

\#\#\# buttonDelete\_Click
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

\#\#\# buttonMove\_Click
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

\#\#\# buttonCalculate\_Click
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

\#\#\# Form1\_MouseDown
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
\- Метод `Form1_MouseDown` очищает выбранные элементы в `listBoxLeft` и `listBoxRight`, если произошло нажатие мыши вне области списков\.

\#\#\# listBoxRight\_SelectedIndexChanged и listBoxLeft\_SelectedIndexChanged
```csharp
private void listBoxRight_SelectedIndexChanged(object sender, EventArgs e){
    listBoxLeft.ClearSelected();
}

private void listBoxLeft_SelectedIndexChanged(object sender, EventArgs e){
    listBoxRight.ClearSelected();
}
```
\- Методы `listBoxRight_SelectedIndexChanged` и `listBoxLeft_SelectedIndexChanged` очищают выбранные элементы в противоположном списке при изменении выбора\.

\#\#\# Form1\_Load
```csharp
private void Form1_Load(object sender, EventArgs e){
    this.MouseDown += Form1_MouseDown;
}
```
\- Метод `Form1_Load` добавляет обработчик события `MouseDown` для формы\.

\#\# Дополнительная информация

\- В коде реализовано управление двумя списками элементов с возможностью добавления, удаления, перемещения и вычисления суммы выбранных элементов\.
\- При вычислении суммы проверяется корректность ввода целочисленных значений\.
\- При нажатии мыши вне области списков, выбранные элементы очищаются\.
\- При изменении выбора элементов в одном списке, выбор в другом списке очищается\.

Этот код предоставляет пример использования списков и базовых операций с ними в Windows Forms\.
#include <iostream>
#include <cstring>
#include <string>

using namespace std;

class StringTP {
public:
    static const int MAX_SIZE = 255;
    char data[MAX_SIZE]; // Массив символов для хранения строки
    StringTP() // Конструктор по умолчанию
    {
        data[0] = 0;
    }; 
    // Методы класса
    int length() const; // Возвращает длину строки
    int findSubstring(const char* substring) const; // Ищет подстроку и возвращает её позицию
    void removeSubstring(const char* substring); // Удаляет подстроку из строки
    void insertSubstring(const char* substring, int position); // Вставляет подстроку в указанную позицию
    void concatenate(const StringTP& other); // Объединяет текущую строку с другой
    void display() const; // Выводит строку на экран

    friend istream& operator>>(std::istream& is, StringTP& str); // Перегрузка оператора ввода
    friend ostream& operator<<(std::ostream& os, const StringTP& str); // Перегрузка оператора вывода


    StringTP& operator=(const StringTP& other)
    {
        if (this != &other) // Проверка на самоприсваивание
        {
            int len = other.length(); // Получаем длину строки в другом объекте
            if (len <= MAX_SIZE - 1)
            {
                memcpy(data, other.data, len + 1); // Копируем данные из другой строки в текущую, включая завершающий нулевой символ
            }
            else
            {
                memcpy(data, other.data, MAX_SIZE - 1); // Если строка в другом объекте длиннее, обрезаем её до MAX_SIZE - 1 символов
                data[MAX_SIZE - 1] = '\0'; // Устанавливаем завершающий нулевой символ
            }
        }
        return *this;
    }

    StringTP operator+(const StringTP& other)
    {
        StringTP result = *this; // Создаем копию текущего объекта
        result.concatenate(other); // Вызываем метод concatenate для объединения строк
        return result;
    }

    ~StringTP()
    {
        // Освобождение памяти для массива символов data
    }
    
};

//StringTP::StringTP() {
//    data[0] = 0; // Инициализация длины строки значением 0
//}

int StringTP::length() const {
    return static_cast<int>(data[0]); // Возвращает длину строки (хранится в первом байте)
}

int StringTP::findSubstring(const char* substring) const {
    const char* result = strstr(data + 1, substring); // Поиск подстроки, начиная со второго символа
    if (result == nullptr) {
        return -1; // Подстрока не найдена
    }
    return static_cast<int>(result - data); // Возвращает позицию подстроки
}

void StringTP::removeSubstring(const char* substring) {
    int index = findSubstring(substring); // Находим позицию подстроки
    if (index != -1) {
        int substringLength = static_cast<int>(strlen(substring));
        memmove(data + index, data + index + substringLength, MAX_SIZE - index - substringLength); // Удаляем подстроку
        data[0] -= substringLength; // Корректируем длину строки
    }
}

void StringTP::insertSubstring(const char* substring, int position) {
    int substringLength = static_cast<int>(strlen(substring));
    if (position >= 0 && position <= length() && length() + substringLength <= MAX_SIZE) {
        memmove(data + position + substringLength, data + position, MAX_SIZE - position - substringLength); // Вставляем подстроку
        memcpy(data + position, substring, substringLength);
        data[0] += substringLength; // Корректируем длину строки
    }
}

void StringTP::concatenate(const StringTP& other) {
    int totalLength = length() + other.length();
    if (totalLength <= MAX_SIZE) {
        memcpy(data + length() + 1, other.data + 1, other.length()); // Объединяем строки
        data[0] = totalLength; // Корректируем длину строки
    }
}

void StringTP::display() const {
    for (int i = 1; i <= length(); ++i) {
        cout << data[i]; // Выводим символы строки
    }
    cout << endl;
}

istream& operator>>(std::istream& is, StringTP& str) {
    char buffer[StringTP::MAX_SIZE];
    is.ignore(); // Игнорируем предыдущий символ новой строки или пробела
    is.getline(buffer, StringTP::MAX_SIZE);
    int length = static_cast<int>(strlen(buffer));
    if (length <= StringTP::MAX_SIZE - 1) {
        memcpy(str.data + 1, buffer, length);
        str.data[0] = static_cast<char>(length);
    }
    return is;
}

ostream& operator<<(std::ostream& os, const StringTP& str)
{
    for (int i = 1; i <= str.data[0]; ++i) {
        os << str.data[i]; // Выводим символы строки из объекта StringTP в поток os
    }
    return os;
}


int main() 
{
    setlocale(LC_ALL, "Russian");
    system("Title String Turbo Pascal"); // Устанавливаем заголовок окна консоли

    StringTP myString, str2;
    cout << "myString = ";
    cin >> myString;
    str2 = myString;
    cout << "str2 = " << str2 << endl;
    cout << "myString = " << myString << endl;
    str2.insertSubstring("abc", 2);
    cout << "myString = " << myString << endl;
    cout << "str2 = " << str2 << endl;
    StringTP str3;
    StringTP str4;
    cin >> str3;
    cin >> str4;
    cout << "str3 = " << str3 << endl;
    cout << "str4 = " << str4 << endl;
    StringTP result = str3 + str4;
    cout << "str3 + str4 = " << result << endl;
    result.display();

    int choice;
    //do {
    //    cout << "\n1. Получить длину\n";
    //    cout << "2. Найти подстроку\n";
    //    cout << "3. Удалить подстроку\n";
    //    cout << "4. Вставить подстроку\n";
    //    cout << "5. Объединить строки\n";
    //    cout << "6. Отобразить строку\n";
    //    cout << "7. Ввести строку\n";
    //    cout << "0. Выйти\n";
    //    cout << "Введите ваш выбор: ";
    //    cin >> choice;

    //    switch (choice) {
    //    case 1:
    //        cout << "Длина строки: " << myString.length() << endl;
    //        break;
    //    case 2:
    //    {
    //        char substring[StringTP::MAX_SIZE];
    //        cout << "Введите подстроку для поиска: ";
    //        cin >> substring;
    //        int index = myString.findSubstring(substring);
    //        if (index != -1) {
    //            cout << "Подстрока найдена в позиции: " << index << endl;
    //        }
    //        else {
    //            cout << "Подстрока не найдена\n";
    //        }
    //    }
    //    break;
    //    case 3:
    //    {
    //        char substring[StringTP::MAX_SIZE];
    //        cout << "Введите подстроку для удаления: ";
    //        cin >> substring;
    //        myString.removeSubstring(substring);
    //        cout << "Подстрока удалена\n";
    //    }
    //    break;
    //    case 4:
    //    {
    //        char substring[StringTP::MAX_SIZE];
    //        int position;
    //        cout << "Введите подстроку для вставки: ";
    //        cin >> substring;
    //        cout << "Введите позицию для вставки: ";
    //        cin >> position;
    //        myString.insertSubstring(substring, position);
    //        cout << "Подстрока вставлена\n";
    //    }
    //    break;
    //    case 5:
    //    {
    //        StringTP otherString;
    //        cout << "Введите строку для объединения: ";
    //        cin >> otherString;
    //        myString.concatenate(otherString);
    //        cout << "Строки объединены\n";
    //    }
    //    break;
    //    case 6:
    //        cout << "Текущая строка: ";
    //        myString.display();
    //        break;
    //    case 7:
    //        cout << "Введите строку: ";
    //        cin >> myString;
    //        cout << "Строка введена\n";
    //        break;
    //    case 0:
    //        cout << "Выход...\n";
    //        break;
    //    default:
    //        cout << "Неверный выбор\n";
    //    }

    //} while (choice != 0);

    return 0;
}
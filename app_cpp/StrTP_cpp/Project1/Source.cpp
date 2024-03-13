#include <iostream>
#include <cstring>
#include <string>

using namespace std;

class StringTP {
public:
    static const int MAX_SIZE = 255;
    char data[MAX_SIZE]; // ������ �������� ��� �������� ������
    StringTP() // ����������� �� ���������
    {
        data[0] = 0;
    }; 
    // ������ ������
    int length() const; // ���������� ����� ������
    int findSubstring(const char* substring) const; // ���� ��������� � ���������� � �������
    void removeSubstring(const char* substring); // ������� ��������� �� ������
    void insertSubstring(const char* substring, int position); // ��������� ��������� � ��������� �������
    void concatenate(const StringTP& other); // ���������� ������� ������ � ������
    void display() const; // ������� ������ �� �����

    friend istream& operator>>(std::istream& is, StringTP& str); // ���������� ��������� �����
    friend ostream& operator<<(std::ostream& os, const StringTP& str); // ���������� ��������� ������


    StringTP& operator=(const StringTP& other)
    {
        if (this != &other) // �������� �� ����������������
        {
            int len = other.length(); // �������� ����� ������ � ������ �������
            if (len <= MAX_SIZE - 1)
            {
                memcpy(data, other.data, len + 1); // �������� ������ �� ������ ������ � �������, ������� ����������� ������� ������
            }
            else
            {
                memcpy(data,
};

//StringTP::StringTP() {
//    data[0] = 0; // ������������� ����� ������ ��������� 0
//}

int StringTP::length() const {
    return static_cast<int>(data[0]); // ���������� ����� ������ (�������� � ������ �����)
}

int StringTP::findSubstring(const char* substring) const {
    const char* result = strstr(data + 1, substring); // ����� ���������, ������� �� ������� �������
    if (result == nullptr) {
        return -1; // ��������� �� �������
    }
    return static_cast<int>(result - data); // ���������� ������� ���������
}

void StringTP::removeSubstring(const char* substring) {
    int index = findSubstring(substring); // ������� ������� ���������
    if (index != -1) {
        int substringLength = static_cast<int>(strlen(substring));
        memmove(data + index, data + index + substringLength, MAX_SIZE - index - substringLength); // ������� ���������
        data[0] -= substringLength; // ������������ ����� ������
    }
}

void StringTP::insertSubstring(const char* substring, int position) {
    int substringLength = static_cast<int>(strlen(substring));
    if (position >= 0 && position <= length() && length() + substringLength <= MAX_SIZE) {
        memmove(data + position + substringLength, data + position, MAX_SIZE - position - substringLength); // ��������� ���������
        memcpy(data + position, substring, substringLength);
        data[0] += substringLength; // ������������ ����� ������
    }
}

void StringTP::concatenate(const StringTP& other) {
    int totalLength = lengt ������������ ����� ������
    }
}

void StringTP::display() const {
    for (int i = 1; i <= length(); ++i) {
        cout << data[i]; // ������� ������� ������
    }
    cout << endl;
}

istream& operator>>(std::istream& is, StringTP& str) {
    char buffer[StringTP::MAX_SIZE];
    is.ignore(); // ���������� ���������� ������ ����� ������ ��� �������
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
        os << str.data[i]; // ������� ������� ������ �� ������� StringTP � ����� os
    }
    return os;
}


int main() 
{
    setlocale(LC_ALL, "Russian");
    system("Title String Turbo Pascal"); // ������������� ��������� ���� �������

    StringTP myString, str2;
    cout << "myString = ";
    cin >> myString;
    str2 = myString;
    cout << "str2 = " << str2 << endl;
    cout << "myString = " << myString << endl;
    str2.insertSubstring("abc", 2);
    cout << "myString = " << myString << endl;
    cout << "str2 =
    StringTP result = str3 + str4;
    cout << "str3 + str4 = " << result << endl;
    result.display();

    int choice;
    //do {
    //    cout << "\n1. �������� �����\n";
    //    cout << "2. ����� ���������\n";
    //    cout << "3. ������� ���������\n";
    //    cout << "4. �������� ���������\n";
    //    cout << "5. ���������� ������\n";
    //    cout << "6. ���������� ������\n";
    //    cout << "7. ������ ������\n";
    //    cout << "0. �����\n";
    //    cout << "������� ��� �����: ";
    //    cin >> choice;

    //    switch (choice) {
    //    case 1:
    //        cout << "����� ������: " << myString.length() << endl;
    //        break;
    //    case 2:
    //    {
    //        char substring[StringTP::MAX_SIZE];
    //        cout << "������� ��������� ��� ������: ";
    //        cin >> substring;
    //        int index = myString.findSubstring(substring);
    //        if (index != -1) {
    //            cout << "��������� ������� � �������: " << index << endl;
    //        }
    //        else {
    //            cout << "��������� �� �������\n";
    //        }
    //    }
    //    break;
    //    case 3:
    //    {
    //        char substring[StringTP::MAX_SIZE];
    //        cout << "������� ��������� ��� ��������: ";
    //        cin >> substring;
    //        myString.removeSubstring(substring);
    //        cout << "��������� �������\n";
    //    }
    //    break;
    //    case 4:
    //    {
    //        char substring[StringTP::MAX_SIZE];
    //        int position;
    //        cout << "������� ��������� ��� �������: ";
    //        cin >> substring;
    //        cout << "������� ������� ��� �������: ";
    //        cin >> position;
    //        myString.insertSubstring(substring, position);
    //        cout << "��������� ���������\n";
    //    }
    //    break;
    //    case 5:
    //    {
    //        StringTP otherString;
    //        cout << "������� ������ ��� �����������: ";
    //        cin >> otherString;
    //        myString.concatenate(otherString);
    //        cout << "������ ����������\n";
    //    }
    //    break;
    //    case 6:
    //        cout << "������� ������: ";
    //        myString.display();
    //        break;
    //    case 7:
    //        cout << "������� ������: ";
    //        cin >> myString;
    //        cout << "������ �������\n";
    //        break;
    //    case 0:
    //        cout << "�����...\n";
    //        break;
    //    default:
    //        cout << "�������� �����\n";
    //    }

    //} while (choice != 0);

    return 0;
}
#include <iostream>
using namespace std;

class Arr 
{

private:
    int* arr;
    int size;

public:
    Arr(int s = 0) 
    {
        size = s;
        arr = new int[size];
        for (int i = 0; i < size; i++)
            arr[i] = 0;
    }

    Arr(const Arr& a) 
    {
        size = a.size;
        arr = new int[size];
        for (int i = 0; i < size; i++)
            arr[i] = a.arr[i];
    }

    ~Arr() 
    {
        delete[] arr;
    }

    void Sort() 
    {
        for (int i = 0; i < size - 1; i++) 
        {
            for (int j = i + 1; j < size; j++) 
            {
                if (arr[i] > arr[j]) {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }

    void Add(int value) 
    {
        int* temp = new int[size + 1];
        for (int i = 0; i < size; i++)
            temp[i] = arr[i];
        temp[size] = value;
        delete[] arr;
        arr = temp;
        size++;
    }

    void Del(int index) 
    {
        if (index < 0 || index >= size) return;
        int* temp = new int[size - 1];
        int j = 0;
        for (int i = 0; i < size; i++) 
        {
            if (i != index) {
                temp[j] = arr[i];
                j++;
            }
        }
        delete[] arr;
        arr = temp;
        size--;
    }

    Arr& operator=(const Arr& a) 
    {
        if (this == &a) return *this;
        delete[] arr;
        size = a.size;
        arr = new int[size];
        for (int i = 0; i < size; i++)
            arr[i] = a.arr[i];
        return *this;
    }

    Arr operator+(const Arr& a) 
    {
        Arr temp(size + a.size);
        for (int i = 0; i < size; i++)
            temp.arr[i] = arr[i];
        for (int i = 0; i < a.size; i++)
            temp.arr[i + size] = a.arr[i];
        return temp;
    }

    Arr operator*(int scalar) 
    {
        Arr temp(size);
        for (int i = 0; i < size; i++)
            temp.arr[i] = arr[i] * scalar;
        return temp;
    }

    friend ostream& operator<<(ostream& out, const Arr& a) 
    {
        out << "[";
        for (int i = 0; i < a.size; i++)
            out << a.arr[i] << " ";
        out << "]\n";
        return out;
    }


    friend istream& operator>>(istream& in, Arr& a) 
    {
        for (int i = 0; i < a.size; i++)
            in >> a.arr[i];
        return in;
    }

    Arr operator++()
    {
        for (int i = 0; i < size; i++)
            arr[i] = arr[i] + 1;
        return *this;
    }

    Arr operator++(int d)
    {
        for (int i = 0; i < size; i++)
            arr[i] = arr[i] + 1;
        return *this;
    }
};
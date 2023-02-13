#include <iostream>
using namespace std;

class SetChar {// класс

private://приватные, закрытые поля класса
    int* arr; //указатель на начало массива;
    int maxSize; //максимальный размер массива;
    int size; //текущий размер массива.

public://открытые поля и методы класса
    SetChar() { //конструктор по умолчанию
        maxSize = 0; //присваивание значений полям класса
        size = 0;
        arr = NULL;
    }
    SetChar(int maxSize) {//другой конструктор с параметрами
        this->maxSize = maxSize;
        size = 0;
        arr = new int[maxSize];//создание массива максимальной длины
    }
    SetChar(const SetChar& setchar) {
        maxSize = setchar.maxSize;
        arr = new int[maxSize];
        size = setchar.size;
        for (int i = 0; i < size; i++)
            arr[i] = setchar.arr[i];
    }
    ~SetChar() {//деструктор
        delete[] arr;//освобождение памяти из под массива
    }

    bool in(int item) {
        for (int i = 0; i < size; i++)
            if (arr[i] == item) return true;
        return false;
    }

    SetChar& operator += (int item) {
        if (in(item) == false && size < maxSize) {
            arr[size] = item;
            size++;
        }
        return *this;
    }

    SetChar& operator = (SetChar& setchar) {
        if (this == &setchar) return *this;
        if (arr != NULL) delete[] arr;
        maxSize = setchar.maxSize;
        arr = new int[maxSize];
        size = setchar.size;
        for (int i = 0; i < size; i++)
            arr[i] = setchar.arr[i];
        return *this;
    }

    bool operator == (SetChar& setchar) {
        if (size != setchar.size) return false;
        // предварительно отсортировать arr и setchar.arr
        for (int i = 0; i < size; i++)
            if (arr[i] != setchar.arr[i]) return false;
        return true;
    }

    void input(int size) {
        if (size > maxSize) return;
        this->size = size;
        int i = 0;
        while (i < size) {
            //char item = (33 + rand() % 100);
            int item;
             cin >> item;
            if (!in(item)) {
                arr[i] = item;
                i++;
            }
        }
    }

    void print() {
        for (int i = 0; i < size; i++)
            cout << arr[i] << " ";
        cout << endl;
    }
    friend SetChar operator + (SetChar& s1, SetChar& s2);
    friend SetChar operator * (SetChar& s1, SetChar& s2);
};

SetChar operator + (SetChar& s1, SetChar& s2);

SetChar operator * (SetChar& s1, SetChar& s2);

int main() {
    //srand(5);
    SetChar st(10);
    st.input(5);
    st.print();

    SetChar st2(10);
    st2.input(5);
    st2.print();

    if (st == st2) cout << "set equal" << endl;
    else cout << "set no equal" << endl;

    SetChar st1 = st2;
    if (st1 == st2) cout << "set equal" << endl;
    else cout << "set no equal" << endl;

    SetChar st3;
    // st3 = st + st2;
    st3.print();


    st3 += 't';


    st3.print();

    SetChar st4;
    // st4 = st*st2;
    cout << "--------" << endl;
    st4.print();
    system("pause");
    return 0;
}


SetChar operator + (SetChar& s1, SetChar& s2) {
    int maxTotalSize = s1.maxSize + s2.maxSize;
    SetChar result(maxTotalSize);
    for (int i = 0; i < s1.size; i++) {
        result.arr[i] = s1.arr[i];
    }
    result.size = s1.size;
    for (int i = 0; i < s2.size; i++) {
        result += s2.arr[i];
    }
    return result;
}

SetChar operator * (SetChar& s1, SetChar& s2) {
    int mSize;
    if (s1.maxSize > s2.maxSize) mSize = s1.maxSize; else mSize = s2.maxSize;
    SetChar result(mSize);
    for (int i = 0; i < s1.size; i++) {
        for (int j = 0; j < s2.size; j++)
            if (s1.arr[i] == s2.arr[j])
                result += s1.arr[i];
    }
    return result;
}
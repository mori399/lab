#include <iostream>
#include <Windows.h>

using namespace std;

template<class T>

class Set
{

private:
    int privateScore;
    T* name;
    int maxsize;
    int size;

public:


    Set()
    {
        privateScore = 0;
        maxsize = 0;
        size = 0;
        name = NULL;

    }
    Set(int MaxSize)
    {
        this->maxsize = MaxSize;
        privateScore = 0;
        size = 0;
        name = new T[MaxSize];

    }
    Set(int MaxSize, int privateScore)
    {
        maxsize = MaxSize;
        this->privateScore = privateScore;
        size = 0;
        name = new T[MaxSize];

    }
    Set(const Set& other)
    {
        privateScore = other.privateScore;
        maxsize = other.maxsize;
        size = other.size;
        name = new T[maxsize];
        for (int i = 0; i < size; i++)
        {
            name[i] = other.name[i];
        }

        // cout << "Вызвался конструктор копирования!\n";
    }
    ~Set()
    {
        delete[] name;
    }

    void print()
    {
        cout << "Score: " << privateScore << endl;
        for (int i = 0; i < size; i++)
        {
            cout << name[i] << " ";
        }

    }

    bool in(T item) {
        for (int i = 0; i < size; i++)
            if (name[i] == item) return true;
        return false;
    }

    bool operator == (Set& other)
    {
        if (size != other.size) return false;
        for (int i = 0; i < size; i++)
            if (name[i] != other.name[i]) return false;
        return true;
    }

    Set& operator += (T item)
    {
        if (in(item) == false && size < maxsize)
        {
            name[size] = item;
            size++;
        }
        return *this;
    }
    Set& operator = (const Set& other)
    {
        if (this == &other) return *this;
        if (name != NULL) delete[] name;
        cout << "Вызвался =\n";

        privateScore = other.privateScore;
        maxsize = other.maxsize;
        name = new T[maxsize];
        size = other.size;
        for (int i = 0; i < size; i++)
        {
            name[i] = other.name[i];
        }
        return *this;
    }

    template<class T>
    friend void SetZeroScore(Set<T>& value); // дружественная функция
  
    template<class T>
    friend Set<T> operator* (Set<T>& s1, Set<T>& s2);
   

    template<class T>
    friend bool operator > (T f, Set<T>& s2);
  
    template<class T>
    friend bool operator > (Set& s1, Set& s2);
    
};

template<class T>
bool operator > (T f, Set<T>& s2)
{
    bool found = false;
    for (int i = 0; i < s2.size; i++)
    {
        if (s2.name[i] == f)
        {
            found = true;
            break;
        }
    }
    return found;
}

template<class T>
bool operator > (Set<T>& s1, Set<T>& s2)
{
    return s1 == s2;
}




int main()
{

    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);
    Set<char> p(10, 100);
    Set<char> c(20, 200);
    p.print();
    c.print();
    c = p;
    c.print();
    SetZeroScore(c);
    c.print();
    Set<char> d;
    d = p * c;
    d += 't';
    d.print();
    cout << endl;

    if ('t' > d) cout << "такая буква имеется!\n";
    else cout << "такой буквы нет (\n";

    if (c > p) cout << "Они одинаковы!\n";
    else cout << "Они различаются (\n";

    return 0;
}

template<class T>
void SetZeroScore(Set<T>& value)
{
    value.privateScore = 0;
}

template<class T>
Set<T> operator* (Set<T>& s1, Set<T>& s2)
{
    int mSize;
    if (s1.maxsize > s2.maxsize) mSize = s1.maxsize;
    else mSize = s2.maxsize;

    Set<T> result(mSize);
    for (int i = 0; i < s1.size; i++) {
        for (int j = 0; j < s2.size; j++)
            if (s1.name[i] == s2.name[j])
                result += s1.name[i];
    }
    return result;
};
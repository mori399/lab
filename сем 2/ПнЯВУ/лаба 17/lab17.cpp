#include <iostream>
//#include <stack>
//#include <deque>
#include <list>
#include <algorithm>
#include <vector>
#include <time.h>
#include <Windows.h>

using namespace std;

void setRandom(list<int>& s, int n)
{
    srand(time(NULL));
    for (int i = 0; i < n; i++)
    {
        double x = (rand() % 101 - 10);
        s.push_back(x);
    }
}
void printStack(list<int> s)
{
    while (!s.empty())
    {
        cout << s.front() << " ";
        s.pop_front();
    }
    cout << endl;
}

list<int> sortt(list<int> s)
{
    list<int> result;
    vector <double> vec;
    while (!s.empty())
    {
        vec.push_back(s.front());
        s.pop_front();
    }
    sort(vec.begin(), vec.end());
    for (int i = 0; i < vec.size(); i++)
    {
        result.push_front(vec[i]);
    }



    return result;
}

list<int> someDelete(list<int> s, int find_c, int n, int size)
{
    list<int> result;
    list<int> r = s;
    vector <int> vec;
    int nnn = 0, found = 0;
    while (!s.empty())
    {
       
        if (s.front() == find_c) found = 1, vec.push_back(s.front());
        else
        {
            if (!found || found >= n + 1)
            {
                vec.push_back(s.front());
            }
            found++;
        }
        s.pop_front();
        nnn++;
    }
    reverse(vec.begin(), vec.end());

    for (int i = 0; i < vec.size(); i++)
    {
        result.push_front(vec[i]);
    }

    return result;
}

double findMin(list<int> s)
{
    double min = s.front();
    while (!s.empty())
    {
        if (s.front() < min) min = s.front();
        s.pop_front();
    }
    return min;
}

bool find(list<int> s, int find_c)
{
    bool found = false;
    while (!s.empty())
    {
        if (s.front() == find_c)
        {
            found = true;
            break;
        }
        s.pop_front();
    }
    return found;
}

int findCount(list<int> s, int find_c)
{
    int found = 0;
    while (!s.empty())
    {
        if (s.front() == find_c) found++;
        s.pop_front();
    }
    return found;
}


int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    list<int> s1;
    int size = 10;
    setRandom(s1, size);
    printStack(s1);
    cout << "~~~~~ Минимальный элемент: " << findMin(s1) << endl;
    int find_c;
    cout << endl;
    cout << "Введите число, которое хотите найти в списке: ";
    while (!(cin >> find_c))
    {
        cout << "Введите число, которое хотите найти в списке (дробное): ";
        cin.clear();
        fflush(stdin);
    }

    if (find(s1, find_c)) cout << "~~~~~ Такой элемент нашелся!\n";
    else cout << "~~~~~ Такого элемента нет (\n";

    cout << endl;
    find_c = 0.0;
    cout << "Введите число, которое хотите посчитать в списке: ";
    while (!(cin >> find_c))
    {
        cout << "Введите число, которое хотите посчитать в списке (дробное): ";
        cin.clear();
        fflush(stdin);
    }
    int result = findCount(s1, find_c);
    if (result) cout << "~~~~~ Найдено " << result << " эл.\n";
    else cout << "~~~~~ Такого элемента нет (\n";

    cout << endl;
    cout << "Сортируем...\n";
    s1 = sortt(s1);
    printStack(s1);

    cout << endl;
    cout << "Укажите элемент, с которого начать удаление: \n";
    find_c = 0.0;
    while (!(cin >> find_c))
    {
        cout << "Укажите элемент, с которого начать удаление: ";
        cin.clear();
        fflush(stdin);
    }

    int n = 0;
    cout << "Введите кол-во чисел, которое хотите удалить: \n";
    while (!(cin >> n))
    {
        cout << "Введите кол-во чисел, которое хотите удалить(целое число): ";
        cin.clear();
        fflush(stdin);
    }

    if (n > size - 1)
    {
        cout << "кол-во удаляемых не должно быть равно размеру списка!\n";
        return 1;
    }
    list<int> s2 = someDelete(s1, find_c, n, size);

    printStack(s2);
    return 0;
}
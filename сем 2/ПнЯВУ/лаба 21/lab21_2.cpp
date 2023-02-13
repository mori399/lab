#include <iostream>
#include <queue>
#include <vector>
#include <algorithm>
#include <Windows.h>

using namespace std;

template<class T>
void sort(queue<T> &q)
{
    queue<T> r;
    vector<T> vec;
    while (!q.empty())
    {
        vec.push_back(q.front());
        q.pop();
    }
    sort(vec.begin(), vec.end(), greater<T>());
    for (int i = 0; i < vec.size(); i++)
    {
        r.push(vec[i]);
    }
    q = r;
}

template<class T>
void printQueue(queue<T> q)
{
    cout << "~~~~~~~~ Вывод очереди ~~~~~~~~\n";
    while (!q.empty())
    {
        cout << q.front() << " ";
        q.pop();
    }
    cout << endl;
}

template<class T>
bool find(queue<T> q, T f)
{
    bool found = false;
    while (!q.empty())
    {
        if(q.front() == f) 
        {
            found = true;
            break;
        }
        q.pop();

    }
    return found;
}

template<class T>
queue<T> operator +(queue<T> q1,queue<T> q2)
{
    queue<T> res;
    while (!q1.empty())
    {
        res.push(q1.front());
        q1.pop();
    }
    while (!q2.empty())
    {
        res.push(q2.front());
        q2.pop();
    }

    return res;
}

int main()
{
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    int n;
    cout << "Введите кол-во чисел: ";
    cin >> n;

    queue<double> q;

    double a;
    for (int i = 0; i < n; i++)
    {
        cin >> a;
        q.push(a);
    }
    sort(q);
    printQueue(q);

    queue<double> q2;
    cout << "Введите 2 элемента, которые хотите найти: \n";
    double f = 0;
    cin >> f;
    cout << endl;
    if(find(q,f))
    { 
        q2.push(f);
        cout << "Элемент найден и добавлен!\n";

    }
    else cout << "Элемент не найден (\n";

    cin >> f;
    if(find(q,f))
    { 
        q2.push(f);
        sort(q2);
        cout << "Элемент найден и добавлен!\n";
        printQueue(q2);
    }    

    queue<double> q3 = q+q2;
    printQueue(q3);
    sort(q3);
    printQueue(q3);
    return 0;
}
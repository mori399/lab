#include <iostream>
#include <vector>
#include <string>

using namespace std;

template <typename T>
class Stack
{
public:
    void push(T);
    T pop();
    void printStack();

    Stack<T> operator+(const Stack<T> &stack2)
    {
        Stack<T> res;
        for (int i = 0; i < v.size(); i++)
        {
            res.v.push_back(v[i]);
        }
        for (int i = 0; i < stack2.v.size(); i++)
        {
            res.v.push_back(stack2.v[i]);
        }

        return res;
    }

    bool operator == (Stack<T> &stack1)
    {
        if(v.size() != stack1.v.size()) return false;
        for (int i = 0; i < v.size(); i++)
        {
            if(v[i] != stack1.v[i]) return false;
        }
        return true;
    }

    bool operator != (Stack<T> &stack1)
    {
        if(v.size() != stack1.v.size()) return true;
        for (int i = 0; i < v.size(); i++)
        {
            if(v[i] != stack1.v[i]) return true;
        }
        return false;        
    }

    Stack<T> operator += (T f)
    {
        v.push_back(f);
        return *this;
    }

    friend Stack<T> operator*(Stack<T> &stack, Stack<T> &stack1);

private:
    vector<T> v;
};


template <typename T>
Stack<T> operator*(Stack<T> &stack, Stack<T> &stack1)
{
    T res;
    res = stack.top() * stack1.top();
    stack.pop();
    stack.push(res);
}

int main()
{
    Stack<int> a;
    a.push(1);
    a.push(2);
    a.push(3);
    a.printStack();
    cout << "poped:" << a.pop() << endl;
    a.printStack();

    a += 5;

    a.printStack();

    Stack<int> a1;
    a1 = a + a;
    a1.printStack();

    if(a1 == a) cout << "equal\n";
    else cout << "no equal\n";

    if(a1 != a) cout << "no equal\n";
    else cout << "equal\n";
  
    return 0;
}

template <class T>
void Stack<T>::push(T elem)
{
    v.push_back(elem);
}

template <class T>
T Stack<T>::pop()
{
    T elem = v.back();
    v.pop_back();
    return elem;
}
template <class T>
void Stack<T>::printStack()
{
    cout << "stack:";
    for (int i = 0; i < v.size(); i++) cout << v[i] << " ";
    cout << endl;
}
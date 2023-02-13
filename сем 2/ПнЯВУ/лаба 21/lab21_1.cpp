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

    void func(T start, int n)
    {
        bool st = false;
        int nn = 0;
        vector<T> vv;
        for (int i = 0; i < v.size(); i++)
        {
            if(v[i] == start) st = true, vv.push_back(v[i]);
            else
            {
                if(st == true) 
                {
                    if(nn+1 == n) st = false;
                    nn++;
                }   
                else{
                    vv.push_back(v[i]);
                }             
            }
          
        }
        v = vv;
    }
    

    Stack<T> operator += (T f)
    {
        v.push_back(f);
        return *this;
    }

    Stack<T> operator += (Stack<T> st1)
    {
        for (int i = 0; i < st1.v.size(); i++)
        {
            v.push_back(st1.v[i]);
        }
        
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
    Stack<double> a;
    a.push(0.5);
    a.push(0.3);
    a.push(0.1);
    a.push(0.1);
    a.printStack();
    cout << "poped:" << a.pop() << endl;
    a.printStack();

    a += 0.11;
    a.printStack();

    cout << "b\n";
    a.func(0.3,2); // после эл. 0.3 удалить 2 элемента
    a.printStack();

    Stack<double> b;
    b.push(1.5);
    b.push(1.3);
    b.push(1.1);
    
    a += b;
    a.printStack();
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
    for (auto e : v)
        cout << e << " ";
    cout << endl;
}
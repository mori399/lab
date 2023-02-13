#include <iostream>
#include <cmath>

using namespace std;


double func(double a)
{
    if(a <= 0 || a == -2 || a == 2) throw a; // знаменатели

    double z1 = ((a+2)/sqrt(2*a) - a/(sqrt(2*a)+2) + 2/(a-sqrt(2*a)))*(sqrt(a)-sqrt(2))/(a+2);
    // cout << z1 << endl;

    double z2 = 1/(sqrt(a)-sqrt(2));
    // cout << z1 << endl;

    return z1 == z2;
}

int main()
{
    double a;
    cout << "Введите a: ";
    cin >> a;

    try
    {
        
        cout << "Successfull comleted\n";
        if(func(a)) cout << "Functions are the same )\n";
        else cout << "Function aren't the same (\n";

        // cout << "a = " << a << endl;
        // cout << "Result = " << res << endl;
    }
    catch(double a)
    {
        cout << "a = " << a;
        cout << "\n     ↑ this value isn't in the range of the function\n";
    }
    

    return 0;
}
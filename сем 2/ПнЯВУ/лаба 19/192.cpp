#include <iostream>

using namespace std;

class Double
{
public:
    Double() : val(0)
    {
    }
    Double(int d) : val(d)
    {
    }
    void print() const
    {
        cout << val;
        cout << endl;
    }
    operator int() const
    {
        return val;
    }
    Double& operator=(const double numb)
    {
        val = numb;
        return *this;
    }

private:
    double val;
};

bool operator<(const Double& x, const Double& y)
{
    return static_cast<double>(x) < static_cast<double>(y);
}

int main()
{
    Double d, c;
    d = 0.5;
    c = 1.0;
    d.print();
    c.print();
    if (d < c) cout << "d < c -> true";
    else cout << "false";
    // cout << d;

    return 0;
}
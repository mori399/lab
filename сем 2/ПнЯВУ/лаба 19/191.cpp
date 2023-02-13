#include <iostream>
#include <string.h>
//#define _CRT_SECURE_NO_WARNIGNS
#pragma warning(disable : 4996)

using namespace std;

class Char;

class String
{
private:
    int length;
    char* str;

public:
    String() : str(NULL), length(0)
    {
        str = new char;
        strcpy(str, "");
    }
    String(const char* s) : str(NULL)
    {
        length = strlen(s);
        str = new char[length + 1];
        strcpy(str, s);
    }
    void display() const
    {
        cout << str;
        cout << endl;
    }
    String& operator=(const String& obj)
    {
        length = strlen(obj.str);
        if (str != NULL)
            delete[] str;
        str = new char[length + 1];
        strcpy(str, obj.str);
        return *this;
    }
    operator char* () const
    {
        return str;
    }
    operator Char() const;
};

class Char
{
private:
    char* Val;

public:
    Char() : Val(0)
    {
    }
    Char(char* d) : Val(d)
    {
    }
    void display() const
    {
        cout << Val;
        cout << endl;
    }
    operator char*() const
    {
        return Val;
    }
    operator String() const
    {
        char buff[100];
        sprintf(buff, "%s", Val);

        return String(buff);
    }
};

String::operator Char() const
{
    return Char(this->str);
}

int main()
{
    String s1("zdarova mir!");
    String s2 = "mda";

    cout << "s1=";
    s1.display();
    cout << "s2=" << s2;
    cout << "\n\n";

    char* strrr = new char;
    cin >> strrr;
    Char d1(strrr);
    Char d2 = s2;
    cout << "d1=";
    d1.display();
    cout << "d2=";
    d2.display();
    cout << endl;

    s1 = d1;
    cout << "sl=" << s1;
    return 0;
}
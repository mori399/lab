#include <iostream>
#include <string>
#include <windows.h>

using namespace std;

string two(float num);
float un_two(string num);
string sum_two(int a, int b);
string minus_two(int a, int b);
string Two_Ten(int num);
int un_Two_Ten(string str);
string flip(string str);
int* ASCII(string str);
string un_ASCII(int code[50]);
string pram_code(int a);
int un_pram_code(string str);
string flip_Code(string str);
string dop_Code(string str);
string flip_Code_plus(string str1, string str2);
string dopPlus(string str1, string str2);
void normal_num(float &number1, int &degree);
float summ_normal(float& number1, float& number2, int& degree1, int& degree2);
float minus_normal(float& number1, float& number2, int& degree1, int& degree2);
float multiplication_normal(float& number1, float& number2, int& degree1, int& degree2);
float division_normal(float& number1, float& number2, int& degree1, int& degree2);

int main() {

    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    while (true)
    {
    int n, code[50], num1, num2, degree1 = 0, degree2 = 0, resultdegree = 0;
    float number1, number2, resultnumber;
    string twotennumber, str;
    cout << "1. В двоично-десятичную\n";
    cout << "2. Из двоично-десятичной\n";
    cout << "3. Текст в ASCII\n";
    cout << "4. Текст из ASCII\n";
    cout << "5. Число в прямом, обратном, дополнительном кодах\n";
    cout << "6. Сложить обратные коды\n";
    cout << "7. Сложить дополнительные коды\n";
    cout << "8. Представить число в нормализовнанном виде\n";
    cout << "9. Сложение \n";
    cout << "10. Вычитание\n";
    cout << "11. Умножение\n";
    cout << "12. Деление\n";
        cin >> n;
        switch (n)
        {
        case 1:
            system("CLS");
            cout << "Введите число: "; cin >> number1;
            cout << Two_Ten(number1) << "\n\n";
            break;

        case 2:
            system("CLS");
            cout << "Введите число: "; cin >> twotennumber;
            cout << un_Two_Ten(twotennumber) << "\n\n";
            break;

        case 3:
            system("CLS");
            cout << "Введите текст: "; getline(cin, str, '.');
            ASCII(str);
            break;

        case 4:
            system("CLS");
            cout << "Введите коды символов: "; 
            for (int i = 0; code != 0; i++) {
                cin >> code[i];
                if (code[i] == 0) {
                    break;
                }
            }
            cout << un_ASCII(code) << "\n\n";
            break;

        case 5:
            system("CLS");
            cout << "Введите число: "; cin >> num1;
            cout << "Прямой код: " << pram_code(num1) << endl;
            cout << "Обратный код: " << flip_Code(pram_code(num1)) << endl;
            cout << "Дополнительный код: " << dop_Code(pram_code(num1)) << endl;
            break;

        case 6:
            system("CLS");
            cout << "Введите первое число: "; cin >> num1;
            cout << "Введите второе число: "; cin >> num2;
            cout << flip_Code_plus(pram_code(num1), pram_code(num2)) << endl;
            cout << un_pram_code(flip_Code_plus(pram_code(num1), pram_code(num2))) << endl;
            break;

        case 7:
            system("CLS");
            cout << "Введите первое число: "; cin >> num1;
            cout << "Введите второе число: "; cin >> num2;
            cout << dopPlus(pram_code(num1), pram_code(num2)) << endl;
            cout << un_pram_code(dopPlus(pram_code(num1), pram_code(num2))) << endl;
            break;

        case 8:
            system("CLS");
            cout << "Введите число: "; cin >> number1;
            normal_num(number1, degree1);
            cout << "Результат : " << number1 << " * 10^" << degree1 << endl;
            break;

        case 9:
            system("CLS");
            cout << "Введите первое число: "; cin >> number1;
            normal_num(number1, degree1);
            cout << "Введите второе число: "; cin >> number2; 
            normal_num(number2, degree2);
            resultnumber = summ_normal(number1, number2, degree1, degree2);
            normal_num(resultnumber, resultdegree);
            cout << "Результат : " << resultnumber << " * 10^" << resultdegree << endl;
            break;

        case 10:
            system("CLS");
            cout << "Введите первое число: "; cin >> number1;
            normal_num(number1, degree1);
            cout << "Введите второе число: "; cin >> number2;
            normal_num(number2, degree2);
            resultnumber = minus_normal(number1, number2, degree1, degree2);
            normal_num(resultnumber, resultdegree);
            cout << "Результат : " << resultnumber << " * 10^" << resultdegree << endl;
            break;

        case 11:
            system("CLS");
            cout << "Введите первое число: "; cin >> number1;
            normal_num(number1, degree1);
            cout << "Введите второе число: "; cin >> number2;
            normal_num(number2, degree2);
            resultnumber = multiplication_normal(number1, number2, degree1, degree2);
            normal_num(resultnumber, resultdegree);
            cout << "Результат : " << resultnumber << " * 10^" << resultdegree << endl;
            break;

        case 12:
            system("CLS");
            cout << "Введите первое число: "; cin >> number1;
            normal_num(number1, degree1);
            cout << "Введите второе число: "; cin >> number2;
            normal_num(number2, degree2);
            resultnumber = division_normal(number1, number2, degree1, degree2);
            normal_num(resultnumber, resultdegree);
            cout << "Результат : " << resultnumber << " * 10^" << resultdegree << endl;
            break;

        case 0:
            system("CLS");

            break;

        default:
            system("CLS");
            break;
        }

    }
}

void normal_num(float &number, int &degree) {
      if (number < 0.1 && number >0) {
          while (number < 0.1) {
              number *= 10;
              degree--;
          }
    }
    else if (number > 0) {
        while ((int)number > 0)
        {
            number /= 10;
            degree++;
        }
    }
    else if (number > -0.1 && number < 0) {
          while (number > -0.1) {
              number *= 10;
              degree--;
          }
      }
    else{ while ((int)number < 0)
          {
              number /= 10;
              degree++;
          }
      }
}

float summ_normal(float& number1, float& number2, int& degree1, int& degree2) {
    float resul;
    resul = (number1 * pow(10, degree1 - degree2) + number2) * pow(10, degree2);
    return resul;
}

float minus_normal(float& number1, float& number2, int& degree1, int& degree2) {
    float resul;
    resul = (number1 * pow(10, degree1 - degree2) - number2) * pow(10, degree2);
    return resul;
}

float multiplication_normal(float& number1, float& number2, int& degree1, int& degree2) {
    float resul;
    int sumdegree = 0;
    resul = (number1 * number2) * pow(10, degree1 + degree2);
    return resul;
}

float division_normal(float& number1, float& number2, int& degree1, int& degree2) {
    float resul;
    int sumdegree = 0;
    resul = (number1 / number2) * pow(10, degree1 - degree2);
    return resul;
}

string flip(string str)
{
    int counter = str.size() - 1;
    for (int j = 0; j <= counter / 2; j++)
    {
        int temp = str[j];
        str[j] = str[counter - j];
        str[counter - j] = temp;
    }
    return str;
}

string Two_Ten(int num)
{
    string str, temp;

    num = stoi(flip(to_string(num)));

    while (num > 0)
    {
        temp += two(num % 10);
        temp = flip(temp);
        while (temp.size() % 4 != 0)
        {
            temp += '0';
        }
        str += flip(temp);
        temp = "";
        num /= 10;
    }

    return str;
}

int un_Two_Ten(string str)
{
    int num = 0;
    string temp;
    int step = 0;

    while (str.size() != 0)
    {
        for (int i = 0; i < 4; i++)
        {
            temp += str[0];
            str.erase(0, 1);
        }
        num += un_two(temp) * pow(10, step);
        step++;
        temp = "";
    }

    num = stoi(flip(to_string(num)));

    return num;
}

int* ASCII(string str) {
    int* code;
    code = new int[str.size()];

    for (int i = 0; i < str.size(); i++)
    {
        code[i] = str[i];
    }

    for (int i = 0; i < str.size(); i++)
    {
        cout << code[i] << " ";
    }
    cout << endl;
        return code;
}

string un_ASCII(int code[50])
{
    string str = "";

    int j = 0;
    while (code[j] != NULL) j++;
    for (int i = 0; i < j; i++)
    {
        str += code[i];
    }

    return str;
}

string pram_code(int a)
{
    string str = "";
    str = two(a);

    str = flip(str);

    int test = str.size() % 4;
    if (str.size() > 4)
        for (int i = test; i < 3; ++i)
        {
            str.push_back('0');
        }
    else if (str.size() < 3)
        for (int i = str.size(); i < 3; i++)
        {
            str.push_back('0');
        }
    else if (str.size() == 4)
        for (int i = 0; i < 3; i++)
        {
            str.push_back('0');
        }
    if (a < 0) str.push_back('1');
    else str.push_back('0');

    str = flip(str);
    return str;
}

int un_pram_code(string str)
{
    int minus = 1;
    if (str[0] == '1') {
        minus = -1;
        str[0] = '0';
    }

    int a = un_two(str);
    return a * minus;
}

string flip_Code(string str)
{
    if (str[0] == '0') return str;
    else for (int i = 1; i < str.size(); i++) {
        if (str[i] == '1') str[i] = '0';
        else str[i] = '1';
    }
    return str;
}

string dop_Code(string str)
{
    if (str[0] == '0') return str;
    str = flip_Code(str);

    int a = stoi(str);
    str = sum_two(a, 1);

    return str;
}

string flip_Code_plus(string str1, string str2)
{
    string str;
    int rev = 0;
    if (str1[0] == '1') {
        str1 = flip_Code(str1);
    }
    if (str2[0] == '1') {
        str2 = flip_Code(str2);
    }

    str = sum_two(stoi(str1), stoi(str2));
    if (un_pram_code(str1) + un_pram_code(str2) < 0) str = flip_Code(str);
    else str = pram_code(un_two(str));

    return str;
}

string dopPlus(string str1, string str2)
{
    string str;
    int rev = 0;
    if (str1[0] == '1') {
        str1 = flip_Code(str1);
        str1 = sum_two(stoi(str1), 1);
    }
    if (str2[0] == '1') {
        str2 = flip_Code(str2);
        str2 = sum_two(stoi(str2), 1);
    }
    int a;
    str = sum_two(stoi(str1), stoi(str2));
    if (un_pram_code(str1) + un_pram_code(str2) < 0) {
        str = minus_two(stoi(str), 1);
        str = flip_Code(str);
    }
    else str = pram_code(un_two(str));

    return str;
}

string two(float num) {
    int counter = 0;
    char tem[20];
    int a = num;

    if (a < 0) a = abs(a);
    if (a == 1) tem[0] = '1'; 
    if (a == 0) tem[0] = '0';

    while (a != 1 && a != 0) 
    {
        if ((int)a % 2 == 0)
            tem[counter] = '0';
        else tem[counter] = '1';

        counter++;
        a = (int)a / 2;
        if (a == 1) tem[counter] = '1';
    }

    int counter2 = counter;
    if (counter2 % 2 == 1) counter2++;

    for (int k = 0; k < counter2 / 2; k++)
    {
        int temp = tem[k];
        tem[k] = tem[counter - k];
        tem[counter - k] = temp;
    }

    a = num;
    if (a != num) {
        float b;
        b = num - a;
        counter++; tem[counter] = '.';
        for (int g = 0; g < 6; g++) {
            b = b * 2;
            counter++;
            if (b > 1) {
                tem[counter] = '1';
                b = b - 1;
            }
            else if (b < 1) {
                tem[counter] = '0';
            }
            else {
                tem[counter] = '1';
            }
        }
    }
    string s;
    for (int j = 0; j <= counter; j++)
    {
        s += tem[j];
    }
    return s;
}

float un_two(string num)
{
    float b = 0; int i = 0;
    while (num[i] == '1' || num[i] == '0')
    {
        if (num[i] == '1') {
            b = b * 2 + 1;
        }
        if (num[i] == '0') {
            b = b * 2;
        }
        i++;
    }

    if (num[i] == '.') {
        i++;
    }

    int step = 0;
    while (num[i] == '1' or num[i] == '0')
    {
        step--;
        if (num[i] == '1') {
            b = b + pow(2, step);
        }
        i++;
    }
    return b;
}

string sum_two(int a, int b)
{
    int result;
    result = a + b;
    int temp = result;

    int counter = 0;
    while (temp != 0)
    {
        if (temp % 10 >= 2)
        {
            result += 1 * pow(10, counter + 1);
            temp += 10;
            result -= 2 * pow(10, counter);
        }
        temp /= 10;
        counter++;
    }
    string str = to_string(result);
    return str;
}

string minus_two(int a, int b)
{
    int result;
    result = a - b;

    int temp = result;

    int counter = 0;
    while (temp != 0)
    {
        if (temp % 10 == 9)
        {
            result -= 8 * pow(10, counter);
        }
        temp /= 10;
        counter++;
    }
    string str = to_string(result);
    return str;
}
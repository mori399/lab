#include <iostream>
#include <string>

using namespace std; 

string two(double num); 
string eight(double num);
string sixteen(double num);
float untwo(string num);
float uneight(string num);
float unsixteen(string num);
void flip(int counter2, char *tem);
int sumtwo(int a, int b);
int minustwo(int a, int b);

int main() {
    int n = 1;
    double num;
    string unnum;
    int a, b;
    string da, db;
    float resul1, resul2, resul;
    cout << "1. two\n";
    cout << "2. eight\n";
    cout << "3. sixteen\n";
    cout << "4. from two\n";
    cout << "5. from eight\n";
    cout << "6. from sixteen\n";
    cout << "7. sumtwo\n";
    cout << "8. minustwo\n";
    cout << "9. sumeight\n";
    cout << "10. minussixteen\n";
    cout << "11. uptwo\n";
    cout << "12. upeight\n";
    cout << "0. exit\n";
    while (n != 0)
    {
        cin >> n;
        switch (n)
        {
        case 1: 
            system("CLS");
            cin >> num;
            cout << two(num);
            break;

        case 2: 
            system("CLS");
            cin >> num;
            cout << eight(num);
            break;

        case 3: 
            system("CLS");
            cin >> num;
            cout << sixteen(num);
            break;

        case 4: 
            system("CLS");
            cin >> unnum;
            cout << untwo(unnum);
            break;

        case 5: 
            system("CLS");
            cin >> unnum;
            cout << uneight(unnum);
            break;

        case 6: 
            system("CLS");
            cin >> unnum;
            cout << unsixteen(unnum);
            break;

         case 7: 
            system("CLS");
            cout << "a - "; cin >> a;
            cout << "b - "; cin >> b;
            cout << sumtwo(a, b);
            break;

        case 8:
            system("CLS");
            cout << "a - "; cin >> a;
            cout << "b - "; cin >> b;
            cout << minustwo(a, b);
            break;

        case 9:
            system("CLS");
            cout << "a - "; cin >> da;
            cout << "b - "; cin >> db;
            resul1 = uneight(da);
            resul2 = uneight(db);
            resul = resul1 + resul2;
            cout << eight(resul);
            break;

        case 10:
            system("CLS");
            cout << "a - "; cin >> da;
            cout << "b - "; cin >> db;
            resul1 = unsixteen(da);
            resul2 = unsixteen(db);
            resul = resul1 - resul2;
            cout << sixteen(resul);
            break;

        case 11:
            system("CLS");
            cout << "a - "; cin >> da;
            cout << "b - "; cin >> db;
            resul1 = untwo(da);
            resul2 = untwo(db);
            resul = resul1 * resul2;
            cout << two(resul);
            break;

        case 12:
            system("CLS");
            cout << "a - "; cin >> da;
            cout << "b - "; cin >> db;
            resul1 = uneight(da);
            resul2 = uneight(db);
            resul = resul1 * resul2;
            cout << eight(resul);
            break;

        case 0:
            system("CLS");
            return 0;
            break;

        default:
            system("CLS");
            break;
        }
        return 0;
    }
}

void flip(int counter, char *tem) {
    int counter2 = counter;
    if (counter2 % 2 == 1) counter2++;

    for (int k = 0; k < counter2 / 2; k++)
    {
        char temp = tem[k];
        tem[k] = tem[counter - k];
        tem[counter - k] = temp;
    }
    
}

string two(double num) {
    int counter = 0;
    char tem[20];
    int a = num;
    for (int i = 0; a != 0; i++) {
        if (a % 2 == 0) {
            tem[i] = '0';
        }
        else {
            tem[i] = '1';
        }
        a = a / 2;
        counter++;
    }

    flip(counter, tem);
 
    a = num;
    if (a != num) {
        double b;
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

string eight(double num) {
    char tem[20]; int counter = 0;
    float a2 = num - (int)num;
    float ost;

    while (num >= 8) 
    {
        ost = (int)num % 8; 
        if (ost < 8) tem[counter] = ost + '0'; 
        counter++;
        num = (int)num / 8;

    }
    if (num < 10) tem[counter] = num + '0'; 

    flip(counter, tem);

    if (a2 - (int)a2 > 0) 
    {
        counter++;
        tem[counter] = '.';

        for (int j = 0; j < 6; j++)
        {
            a2 *= 8;
            ost = (int)a2;
            counter++;
            {
                tem[counter] = ost + '0';
            }
            a2 = a2 - (int)a2;
        }
    }

    string s;
    for (int j = 0; j <= counter; j++)
    {
        s += tem[j];
    }
  
    return s;
}

string sixteen(double num) {
    char tem[20]; int counter = 0;
    float a2 = num - (int)num;
    float ost;

    while (num >= 16) 
    {
        ost = (int)num % 16; 
        if (ost < 10) {
            tem[counter] = ost + '0';
        }
        else {
            tem[counter] = ost + 'A' - 10;
        }
        counter++;
        num = (int)num / 16;

    }
    if (num < 10) {
        tem[counter] = num + '0';
    }
    else {
        tem[counter] = num + 'A' - 10;
    }

    flip(counter, tem);

    if (a2 - (int)a2 > 0) 
    {
        counter++;
        tem[counter] = '.';

        for (int j = 0; j < 6; j++)
        {
            a2 *= 16;
            ost = (int)a2;
            counter++;

            if (ost >= 10)
            {
                tem[counter] = ost + 55;
            }
            else 
            {
                tem[counter] = ost + '0';
            }
            a2 = a2 - (int)a2;
        }
    }

    string s;
    for (int j = 0; j <= counter; j++)
    {
        s += tem[j];
    }
    return s;
}

float untwo(string num)
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

float uneight(string num)
{
    float number = 0;
    int counter = 0;
    int step = 0;

    bool dot = false;

    while (1)
    {
        if (num[counter] == '.') {
            dot = true;
        }
        if (num[counter] != NULL && dot != true)
        {
            counter++;
            step++;
        }
        if (num[counter] != NULL and dot != false)
        {
            counter++;
        }
        if (num[counter] == NULL) break;
    }

    for (int j = 0; j < counter; j++)
    {
        if (num[j] != '.')
        {
            step--;
            number = number + pow(8, step) * (num[j] - 48);
        }
    }
 
    return number;
}

float unsixteen(string num)
{
    float number = 0;
    int counter = 0;
    int step = 0;

    bool dot = false;

    while (true)
    {
        if (num[counter] == '.') dot = true;

        if (num[counter] != NULL && dot != true)
        {
            counter++;
            step++;
        }
        if (num[counter] != NULL && dot != false)
        {
            counter++;
        }
        if (num[counter] == NULL) break;
    }

    for (int j = 0; j < counter; j++)
    {
        if (num[j] != '.')
        {
            step--;
            if (num[j] >= 'A' and num[j] <= 'F')
            {
                number = number + pow(16, step) * (num[j] - 55);
            }
            else
                number = number + pow(16, step) * (num[j] - 48);
        }
    }
    
    return number;
}

int sumtwo(int a, int b)
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
    return result;
}

int minustwo(int a, int b)
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
    return result;
}
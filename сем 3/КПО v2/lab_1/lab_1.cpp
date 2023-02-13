#include <iostream>

using namespace std;

void one();
void two();
void three();
void four();

int main()
{
    while (true)
    {
        int n; 
        cout << "number - ";
        cin >> n;
        switch (n)
        {
        case 1:
            one();
            break;
        case 2:
            two();
            break;
        case 3:
            three();
            break;
        case 4:
            four();
            break;
        }
        cout << endl;
    }
}

void one() {
    int arr[20] = { 1 ,6 ,12 ,4, 11 ,-6 ,7 ,2 ,10 , 8 , 22, 3, 7, 12, 87, 23, 1, -23, 19, 20};
    int n, k, mem;
    bool check = false ;
    cout << "n = ";
    cin >> n;
    cout << "k = ";
    cin >> k;
    for (int i = 0; i < 20; i++) {
        if (i == n - 1) {
            mem = arr[i];
            check = true;
        }
        if (check) {
            if (arr[i] < mem) {
                mem = arr[i];
            }
       }
        if (i == k - 1) {
            break;
        }
    }
    cout << mem;
}

void two() {
    int arrA[10] = {1, 2 ,3 ,4 ,5 ,6 ,7 ,8 ,9 ,0};
    int arrB[10] = {12, 5, 3, 6, 5, 5, 0, 2, 10, 10};
    int counter = 0;
    for (int i = 0; i < 10; i++) {
        for (int j = 0; j < 10; j++) {
            if (arrA[i] == arrB[j]) {
                counter++;
            }
        }
        cout << "nomer " << arrA[i] << " vstretilsa " << counter << " raz" << endl;
        counter = 0;
    }
}

void three() {
    int arr[3][5] = {
        {1, 2, 3, 4, 5},
        {2, 4, 6, 8, 10},
        {3, 6 ,9, 12,15}
    };
    int n, sum = 0;
    cout << "n = ";
    cin >> n;
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 5; j++) {
            if (i + j + 2 == n) {
                sum += arr[i][j];
            }
        }
    }
    cout << sum;
}

void four() {
    int arr[3][5] = {
        {1, 2, 3, 4, 5},
        {2, 4, 6, 8, 10},
        {3, 6 ,9, 12,15}
    };
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 5; j++) {
            if (arr[i][j] % 2 == 0) {
                arr[i][j] = arr[i][j] / 2;
            }
        }
    }
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 5; j++) {
            cout << arr[i][j] << " ";
        } cout << endl;
    }
}
#include <iostream>
#include <Windows.h>
#include "Device.h"
using namespace std;
int main()
{
	const int N = 5;
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	Device arr[N];

	char title[20];
	int number; 
	float cost;
	for (int i = 0; i < N; i++)
	{
		cout << "Товар номер " << i + 1 << endl;
		cout << "Наименование: ";
		cin >> title;
		cout << "Количество: ";
		cin >> number;
		cout << "Стоимость: ";
		cin >> cost;
		arr[i].setTitle(title);
		arr[i].setNumber(number);
		arr[i].setCost(cost);
	}
	cout << endl;
	for (int i = 0; i < N; i++)
		arr[i].print();
	cout << " Наименование | Количестов | Стоимость" << endl;
	for (int i = 0; i < N; i++)
	{
		cout.width(21);
		cout << arr[i].getTitle() << "|";
		cout.width(8);
		cout << arr[i].getNumber() << "|";
		cout.width(8);
		cout << arr[i].getcost() << endl;
	}
	system("pause");
	return 0;
}
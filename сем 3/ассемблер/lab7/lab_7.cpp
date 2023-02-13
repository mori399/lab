#include <iostream>
#include <windows.h>

using namespace std;

float func(float mas[])
{

	double y = 0;
	double del = 10;

	_asm {
		mov esi, [mas]
		mov ecx, 10
		fldz
		_for :
		fadd dword ptr[esi]
			add esi, 4
			loop _for
			fld del
			fdiv
			fstp[y]
	}
	return y;
}

int main()
{
	setlocale(LC_ALL, "RUS");
	float mas[10];
	cout << "Введите элементы массива\n";
	for (int i = 0; i < 10; i++) {
		cout << "massive [" << i << "]" << " = ";
		cin >> mas[i];
	}
	
	cout << "Среднее значение элементов: " << func(mas);
}

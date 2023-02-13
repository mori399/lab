#include <stdio.h> 
#include <time.h> 
#include <stdlib.h> 

void fillArray(int* mas) {
	for (int i = 0; i < 20; i++) // цикл по всем элементам массива
		mas[i] = rand() % 21 - 10; // генерируем случайное число
}
// функция выводит на экран содержимое массива
void printArray(int* mas) {
	printf("{");
	for (int i = 0; i < 20; i++)
		printf("%3i", mas[i]);
	printf("}\n");
}

int calcElems(int* mas) {
	int mem = 0; 
	for (int i = 1; i < 20; i++)
		mem += mas[i];
	return mem; 
}

int* searchArray(int* mas1, int* mas2) {
	int mem1 = calcElems(mas1), // считаем элементы в первом массиве
		mem2 = calcElems(mas2); // считаем элементы во втором массиве
	if (mem1 < mem2) // сравниваем результаты
		return mas1; // возвращаем указатель на массив...
	else // ...в зависимости от...
		return mas2; // ...условия
}
// функция обмениваем местами значения ячеек памяти по указателям a и b
void swap(int* a, int* b) {
	int tmp = *a;
	*a = *b;
	*b = tmp;
}
// функция сортировки массива методом пузырька
void sortArray(int* mas)
{
	int temp = 0;
	for (int i = 0; i < 19; i++) {
		for (int j = 0; j < 19 - i; j++) {
			if (mas[j] > mas[j + 1]) {
				// меняем элементы местами
				temp = mas[j];
				mas[j] = mas[j + 1];
				mas[j + 1] = temp;
			}
		}
	}
}

int main() {
	srand((unsigned)time(NULL));
	int m1[20], m2[20];
	fillArray(m1); printf("M1="); printArray(m1);
	fillArray(m2); printf("M2="); printArray(m2);
	
	int* min = searchArray(m1, m2);
	printf("MN="); printArray(min); // и выводим его на экран
	sortArray(min); // сортируем массив
	printf("ST="); printArray(min); // и выводим на экран
	return 0; // выходим из программы
}
#include <stdio.h> // для ввода/вывода
#include <string.h> // для работы со строками
#include <Windows.h>
#include <iostream>

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	// описание структуры
	struct TRAIN {
		char way[31];
		char num[21];
		int time_h;
		int time_m;
	}; 
	// массив структур
	TRAIN mas[6];
	// заполнение массива
	for (int i = 0; i < 6; i++) {
		fflush(stdin); // очищаем буфер ввода
		printf("МАРШРУТ %i\n", i + 1);
		printf("Пункт назначения: ");
		std::cin >> mas[i].way;
		printf("Номер поезда: ");
		std::cin >> mas[i].num;
		printf("Время отправления: ");
		scanf_s("%i", &mas[i].time_h);
		scanf_s("%i", &mas[i].time_m);
	}
	// сортировка массива
	for (int i = 0; i < 6; i++)
		for (int j = 0; j < 6; j++)
			if (mas[i].time_h * 60 + mas[i].time_m < mas[j].time_h * 60 + mas[j].time_m) {
				TRAIN tmp = mas[i];
				mas[i] = mas[j];
				mas[j] = tmp;
			}
	// массив после сортировки
	printf("ОТСОРТИРОВАННЫЙ МАССИВ\n");
	printf("%30s %20s %10s\n", "Пункт назначения :", "Номер поезда:", "Время отправления :");
	for (int i = 0; i < 6; i++)
		printf("%30s %20s %10i%s%i\n", mas[i].way, mas[i].num, mas[i].time_h, ":", mas[i].time_m);
	// ищем необходимый товар
	char way[31];
	printf("Название пункта: ");
	fflush(stdin);
	std::cin >> way;
	printf("РЕЗУЛЬТАТ:\n");
	printf("%30s %20s %10s\n", "Пункт назначения :", "Номер поезда:", "Время отправления :");
	bool present = false; // флаг присутствия товара
	for (int i = 0; i < 6; i++)
		if (strcmp(mas[i].way, way) == 0) {
			printf("%30s %20s %10i%s%i\n", mas[i].way, mas[i].num, mas[i].time_h, ":", mas[i].time_m);
				present = true;
		}
	if (!present)
		printf("TOBAP HE НАЙДЕН\n");
	return 0;
}
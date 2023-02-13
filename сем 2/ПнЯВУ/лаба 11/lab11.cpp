#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <string.h>
#include <Windows.h>
using namespace std;
class tovar {
private:
	char *title;
	int number;
	float cost;
public:
	tovar() {

		title = new char[20];
		strcpy(title, "");
		number = NULL;
		cost = NULL;
		
	}
	tovar(char *tit,int num, float diag) {
		title = new char[20];
		title = tit;
		number = num;
		cost = diag;
	}
	tovar(tovar &tov) {
		title = new char[20];
		title = tov.title;
		number = tov.number;
		cost = tov.cost;
	}
	~tovar() {
		cout << "des";
		delete[] title;
	}
	void Print() {
		cout << "Наименование: " << title << "\nКоличество: " << number << "\nСтоимость: " << cost << endl;
	}
	void Settitle(char *titl) {
	//	strcpy_s(title, titl);
	}
	char* Gettitle() {
		return title;
	}
	void Setnumb(int numb) {
		number = numb;
	}
	int Getnumb() {
		return number;
	}
	void Setcost(float cos) {
		cost = cos;
	}
	float getcost() {
		return cost;
	}
};
int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	char title[20];
	int number;
	float costs;
	cout << "Наиминование" << endl;
	cin >> title;
	cout << "Количество" << endl;
	cin >> number;
	cout << "Стоимость" << endl;
	cin >> costs;
	tovar *a = new tovar(title, number, costs);
	tovar *b = new tovar();
	tovar *c = new tovar(*a);
	a->Print();
	b->Print();
	c->Print();
	//strcpy_s(title, " ");
}


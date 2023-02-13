#include<iostream>
using namespace std;

class xy
{
	friend xy& operator--(xy a);
private:
	int x, y;
public:
	xy()
	{
		x = 0;
		y = 0;
	}
	~xy()
	{
	}
	void setX(int a) {x = a;}
	int getX() {return x;}
	void setY(int a) {y = a;}
	int getY() {return y;}
	xy& operator++()
	{
		this->x = this->x + 1;
		this->y = this->y + 1;
		return *this;
	}
	xy& operator-()
	{
		this->x = this->x * (-1);
		this->y = this->y * (-1);
		return *this;
	}
};

xy& operator--(xy a)
{
	a.x = a.x--;
	a.y = a.y--;
	return a;
}

int main()
{
	xy a;
	a.setX(3);
	a.setY(5);
	cout << a.getX() << endl;
	cout << a.getY() << endl;
	++a;
	cout << a.getX() << endl;
	cout << a.getY() << endl;
	a = --a;
	cout << a.getX() << endl;
	cout << a.getY() << endl;
	-a;
	cout << a.getX() << endl;
	cout << a.getY() << endl;
}
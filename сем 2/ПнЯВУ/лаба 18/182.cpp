#include<iostream>
using namespace std;

class Long
{
private:
	long data;
public:
	Long()
	{
		data = 0;
	}
	~Long()
	{
	}
	void setData(long a){ data = a; }
	long getData() { return data; }
	Long operator - (Long ddta)
	{
		data -= ddta.getData();
		return *this;
	}
	Long operator = (Long ddta)
	{
		data = ddta.getData();
		return *this;
	}
	Long operator == (Long ddta)
	{
		if (data == ddta.getData())
			cout << "same" << endl;
		else cout << "different" << endl;
		return *this;
	}
	
	friend Long operator+(Long a, Long b);
};

Long operator+(Long a, Long b)
{
	a.data += b.getData();
	return a;
}

int main()
{
	Long a;
	a.setData(3);
	Long b;
	b.setData(7);
	Long c;
	c = a - b;
	cout << c.getData() << endl;
	///////////////////////////
	a.setData(3);
	b.setData(7);
	c = a + b;
	cout << c.getData() << endl;
	////////////////////////////
	a.setData(3);
	b.setData(7);
	a == b;
	////////////////////////////
	cout << a.getData() << endl;
	cout << b.getData() << endl;
	a = b;
	cout << a.getData() << endl;
}
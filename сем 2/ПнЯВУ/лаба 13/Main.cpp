#include <iostream>
#include"Disk.h"
#include <Windows.h>

int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	//disk* disk1 = new disk();
	disk disk1;
	musikDisk disk2;
	dataDisk disk3;
	disk* denis = &disk1;
	denis->input();
	if (denis->getMd() == 1)
	{
		denis = &disk2;
		musikDisk* disk2 = new musikDisk();
		disk2->input();
		disk2->print();
	}
	else if (denis->getMd() == 2)
	{
		denis = &disk3;
		dataDisk* disk3 = new dataDisk();
		disk3->input();
		disk3->print();
	}
	//delete disk1;
	system("pause");
	return 0;
}
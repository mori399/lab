#include <iostream>
#include"Disk.h"
#include <Windows.h>

int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	disk* disk1 = new disk();
	disk1->input();
	if (disk1->getMd() == 1)
	{
		musikDisk* disk2 = new musikDisk();
		disk2->inputMusik();
		disk2->printMusik();
	}
	else if (disk1->getMd() == 2)
	{
		dataDisk* disk2 = new dataDisk();
		disk2->inputData();
		disk2->printData();
	}
	delete disk1;
	system("pause");
	return 0;
}
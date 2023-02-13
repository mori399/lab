#include "disk.h"

dataDisk::dataDisk()
{
	this->dataType = new char[20];
	this->description = new char[20];
	this->setWeight(0);
}

dataDisk::dataDisk(string dataType, string description, int weight)
{
	this->dataType = (dataType);
	this->description = (description);
	this->setWeight(weight);
}

dataDisk::dataDisk(const dataDisk& disk)
{
	this->dataType = new char[20];
	this->setDataType(disk.getDataType());
	this->description = new char[20];
	this->setDescription(disk.getDescription());
	this->setWeight(disk.getWeight());
}
dataDisk::~dataDisk()
{
	this->Weight = 0;
}
void dataDisk::setDataType(string dataType)
{
	this->dataType = dataType;
}
void dataDisk::setDescription(string description)
{
	this->description = description;
}
void dataDisk::setWeight(int Weight)
{
	this->Weight = Weight;
}


string dataDisk::getDataType() const
{
	return this->dataType;
}
string dataDisk::getDescription() const
{
	return this->description;
}
int dataDisk::getWeight() const
{
	return this->Weight;
}

void dataDisk::input()
{
	char type[20];    cout << "Тип диска(cd/dvd/blu-ray/HDDVD): "; cin >> type; this->setType(type);
	int day, mount, year;    cout << "Время записи день, месяц, год: ";
	cin >> day;
	cin >> mount;
	cin >> year;
	this->setDate(day, mount, year);
	char dataType[20];    cout << "Тип данных: "; cin >> dataType; this->setDataType(dataType);
	char description[20]; cout << "Описание: "; cin >> description; this->setDescription(description);
	int Weight;			  cout << "Вес данных: "; cin >> Weight; this->setWeight(Weight);
}
void dataDisk::print()
{
	cout << endl;
	cout << "Диск с данными" << endl;
	cout << "Дата записи: " << this->getDay() << '.' << this->getMount() << '.' << this->getYear() << endl;
	cout << "Тип диска cd/dvd/blu-ray: " << this->getType() << endl;
	cout << "Тип данных: " << this->getDataType() << endl;
	cout << "Описание: " << this->getDescription() << endl;
	cout << "Вес данных: " << this->getWeight() << endl;

}

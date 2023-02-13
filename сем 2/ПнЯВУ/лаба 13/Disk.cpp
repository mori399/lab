#include"Disk.h"

disk::disk()
{
	this->setDate(0, 0, 0);
	this->type = new char[20];
}

disk::disk(string type, int day, int mount, int year, int md)
{
	this->setDate(day, mount, year);
	this->type = (type);
	this->setMd(md);
}

disk::disk(const disk& Disk)
{
	this->type = new char[20];
	this->setType(Disk.getType());
	this->setDate(Disk.getDay(), Disk.getMount(), Disk.getYear());
}

disk::~disk()
{
	day = 0;
	mount = 0;
	year = 0;
}

void disk::setDate(int Day, int Mount, int Year)
{
	this->day = Day;
	this->mount = Mount;
	this->year = Year;
}
void disk::setType(string Type)
{
	this->type = Type;
}
void disk::setMd(int md)
{
	this->md = md;
}

int disk::getDay() const
{
	return this->day;
}
int disk::getMount() const
{
	return this->mount;
}
int disk::getYear() const
{
	return this->year;
}
string disk::getType() const
{
	return this->type;
}
int disk::getMd() const
{
	return this->md;
}
void disk::input()
{
	int md; cout << "1 - музыкальный диск/2 - диск с данными"; cin >> md; this->setMd(md);
}
void disk::print()
{
	cout << endl;
	cout << "Дата записи " << this->getDay() << '.' << this->getMount() << '.' << this->getYear() << endl;
	cout << "Тип диска cd/dvd/blu-ray: " << this->getType() << endl;
}
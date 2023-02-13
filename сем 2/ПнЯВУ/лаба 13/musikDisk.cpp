#include "disk.h"

musikDisk::musikDisk()
{
	this->author = new char[20];
	this->album = new char[20];
	this->setTime(0);
}

musikDisk::musikDisk(string author, string album, int time)
{
	this->author = (author);
	this->album = (album);
	this->setTime(time);
}

musikDisk::musikDisk(const musikDisk& Disk)
{
	this->author = new char[20];
	this->setAuthor(Disk.getAuthor());
	this->album = new char[20];
	this->setAlbum(Disk.getAlbum());
	this->setTime(Disk.getTime());
}
musikDisk::~musikDisk()
{
	time = 0;
}
void musikDisk::setAuthor(string author)
{
	this->author = author;
}
void musikDisk::setAlbum(string album)
{
	this->album = album;
}
void musikDisk::setTime(int time)
{
	this->time = time;
}


string musikDisk::getAuthor() const
{
	return this->author;
}
string musikDisk::getAlbum() const
{
	return this->album;
}
int musikDisk::getTime() const
{
	return this->time;
}

void musikDisk::input()
{
	char type[20];    cout << "Тип диска(cd/dvd/blu-ray/HDDVD): "; cin >> type; this->setType(type);
	int day, mount, year;    cout << "Время записи день, месяц, год: ";
	cin >> day;
	cin >> mount;
	cin >> year;
	this->setDate(day, mount, year);
	char author[20]; cout << "Исполнитель: "; cin >> author; this->setAuthor(author);
	char album[20]; cout << "Альбом: "; cin >> album; this->setAlbum(album);
	int time;		cout << "Время песен в минутах: "; cin >> time; this->setTime(time);
}

void musikDisk::print()
{
	cout << endl;
	cout << "Музыкальный диск" << endl;
	cout << "Дата записи: " << this->getDay() << '.' << this->getMount() << '.' << this->getYear() << endl;
	cout << "Тип диска cd/dvd/blu-ray: " << this->getType() << endl;
	cout << "Исполнитель: " << this->getAuthor() << endl;
	cout << "Альбом: " << this->getAlbum() << endl;
	cout << "Время песен в минутах: " << this->getTime() << endl;
}

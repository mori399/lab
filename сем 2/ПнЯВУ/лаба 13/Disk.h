#pragma once
using namespace std;
#include <iostream>
class disk
{
protected:
	int md;
	string type;

	int day;
	int mount;
	int year;
public:
	disk();
	disk(string type, int day, int mount, int year, int md);
	disk(const disk& Disk);
	~disk();

	void setDate(int day, int mount, int year);
	void setType(string type);
	void setMd(int md);

	int getDay() const;
	int getMount() const;
	int getYear() const;
	string getType() const;
	int getMd() const;

	virtual void input();
	virtual void print();
};

class musikDisk :public disk
{
private:

	string author;
	string album;
	int time;
public:
	musikDisk();
	musikDisk(string, string album, int time);
	musikDisk(const musikDisk& disk);
	~musikDisk();

	void setAuthor(string author);
	void setAlbum(string album);
	void setTime(int time);

	string getAuthor() const;
	string getAlbum() const;
	int getTime() const;

	void input() override;
	void print() override;
};

class dataDisk :public disk
{
private:
	string description;
	int Weight;
	string dataType;
public:
	dataDisk();
	dataDisk(string dataType, string description, int weight);
	dataDisk(const dataDisk& disk);
	~dataDisk();

	void setDescription(string description);
	void setWeight(int Weight);
	void setDataType(string dataType);

	string getDescription() const;
	int getWeight() const;
	string getDataType() const;

	void input() override;
	void print() override;
};
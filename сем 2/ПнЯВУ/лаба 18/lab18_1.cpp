#include <iostream>

using namespace std;

class Queue
{
	static const int SIZE = 100;
	int *queue;
	int head, tail;

public:
	Queue();
	void push(int num);
	friend void printQueue(Queue q);
	int size();
	void pop();
	int front();
	int back();

	friend Queue operator--(Queue queue1);
};

Queue::Queue()
{
	queue = new int[SIZE];
	head = tail = 0;
}

void printQueue(Queue q)
{
	cout << "\nВывод очереди: \n";
	for (int i = q.head + 1; i < q.tail + 1; i++)
	{
		cout << q.queue[i] << " ";
	}
	cout << endl;
}

void Queue::push(int num)
{
	if (tail + 1 == head || (tail + 1 == SIZE && !head))
	{
		cout << "очередь полна\n";
		return;
	}
	tail++;
	if (tail == SIZE)
		tail = 0;
	queue[tail] = num;
}

void Queue::pop()
{
	if (head == tail)
	{
		cout << "очередь пуста\n";
		return;
	}
	head++;
	if (head == SIZE)
		head = 0;
}

int Queue::size()
{
	int s = 0;
	for (int i = head; i < tail; i++)
	{
		s++;
	}
	return s;
}

int Queue::back()
{
	return queue[tail];
}

int Queue::front()
{
	return queue[head + 1];
}

void operator++(Queue &queue1)
{
	queue1.push(0);
}
// что должна возвращать префкс и постфкс.
void operator++(Queue &queue1, int)
{
	cout << "0";
	queue1.push(0);
}

void operator--(Queue &queue1)
{
	queue1.pop();
}

void operator--(Queue &queue1, int)
{
	queue1.pop();
}

bool operator!(Queue queue1)
{
	if(queue1.size() == 0) return true;
	return false;
}


int main()
{
	Queue queue;
	int n;
	cout << "Введите кол-во элементов: ";
	cin >> n;
	int numb = 0;
	for (int i = 0; i < n; i++)
	{
		cin >> numb;
		queue.push(numb);
	}
	printQueue(queue);
	queue.pop();
	if (!queue)
		cout << "empty!\n";
	else
		cout << "no empty\n";

	queue++;
	printQueue(queue);
	queue--;
	printQueue(queue);
	return 0;
}
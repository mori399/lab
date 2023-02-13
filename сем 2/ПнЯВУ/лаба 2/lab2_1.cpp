#include <iostream>

int main()
{
	int x, y;
	std::cin >> x >> y;
	if (y >= 1 || y <= -3) {
		std::cout << "YES";
	}
	else {
		std::cout << "NO";
	}
}

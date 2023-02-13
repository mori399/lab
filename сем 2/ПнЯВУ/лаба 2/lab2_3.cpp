#include <iostream>
#include <math.h>
using namespace std;
int main() {
	float x, y;
	cin >> x;
	if (x >= -10 && x <= -6) {
		y = sqrt(4 - pow(x + 8, 2)) - 2;
		if (y >= -2 && y <= 0) {
			cout << y;
		}
		else { cout << "NO"; }

	}
	else if (x > -6 && x <= 2) {
		y = x / 2 + 1;
		cout << y;
	}
	else if (x > 2 && x <= 6) {
		y = 0;
		cout << y;
	}
	else if (x > 6 && x <= 8) {
		y = pow(x - 6, 2);
		cout << y;
	}

	return 0;
}
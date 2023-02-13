#include <iostream>
#include <cmath>
using namespace std;
int main()
{

	float R, x, y;
	cin >> R >> x >> y;
	if (x >= 0) {
		if (pow(x, 2) + pow(y, 2) <= pow(R, 2)) { printf("Yes"); }
		else { printf("No"); }
	}
	else {
		if ((x >= -R && y <= R && x <= y) || (x >= -R && y >= -R && x >= y)) { printf("Yes"); }
		else { printf("No"); }
	}


	return 0;
}
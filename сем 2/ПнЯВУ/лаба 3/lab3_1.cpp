#include <iostream>
#include <cmath>
using namespace std;
int main()
{

	float R, x[10], y[10];
	bool flag[10];
	printf("R="); scanf_s("%f", &R);
	
	for (int i = 0; i < 10; i++) {
		printf("%i", i + 1);
		printf(".X="); scanf_s("%f", &x[i]);
		printf("%i", i + 1);
		printf(".Y="); scanf_s("%f", &y[i]);
		if (x[i] >= 0) {
			if (pow(x[i], 2) + pow(y[i], 2) <= pow(R, 2)) { flag[i] = true; }
			else { flag[i] = false; }
		}
		else {
			if ((x[i] >= -R && y[i] <= R && x[i] <= y[i]) || (x[i] >= -R && y[i] >= -R && x[i] >= y[i])) { flag[i] = true; }
			else { flag[i] = false; }
		}
	}
	for (int i = 0; i < 10; i++) {
		printf("%i", i + 1);
		printf("%s", ".");
		if (flag[i]) {
			printf("Yes\n");
		}
		else printf("No\n");
	}
	return 0;
}
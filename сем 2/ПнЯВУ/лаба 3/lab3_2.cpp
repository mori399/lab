#include <iostream>
#include <math.h>

int main()
{
	float x1, x2, y;

	printf("X[1]="); scanf_s("%f", &x1);
	printf("X[n]="); scanf_s("%f", &x2);

	for (; x1 < x2; x1++)
	{
		y = (sin(3.14 / 2 + 3 * x1)) / (1 - sin(3 * x1 - 3.14));
			printf("%i", (int)x1); printf("%c", ' '); printf("%f", y); printf("\n");
	}
}

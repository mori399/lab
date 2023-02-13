#define _USE_MATH_DEFINES
#include <iostream>
#include <math.h>

float fact(float N) {
	float mul = 1;
	for (int i = 1; i != N + 1; i++) {
		mul *= i;
	} return mul;
}

int main()
{
	float x, y;

	printf("X="); scanf_s("%f", &x);
	
	for (int n = 0; (pow(-1, n)*pow(x, 2 * n)) / fact(n) < pow(M_E, pow(-x,2)); n++)
	{
		y =(pow(-1, n)*pow(x, 2 * n)) / fact(n);
		printf("%i", (int)n + 1); printf("%c", ' '); printf("%f", y); printf("\n");
	
	}
}

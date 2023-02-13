#include <iostream>
#include<stdio.h>
#include<math.h>
int main()
{
	float a;
	printf("A="); scanf_s("%f", &a);
	float z = cos(a) + cos(2*a) + cos(6*a) + cos(7*a);
	printf("Z=%.5f\n", z);
	return 0;
}
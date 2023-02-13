#include <iostream>
#include <stdio.h>
#include <stdlib.h>

using namespace std;

int main()
{
	int n;
	cin >> n;
	float a[100];
	for (int i = 0; i < n; i++) {
		cin >> a[i];

	}
	float min = a[0];
	for (int i = 0; i < n; i++) {
		if (a[i] < min) { min = a[i]; }
	}
	cout << "min=" << min << endl;
	float sum = 0, na = 0, ko = 0, u = 0;
	for (int i = 0; i < n; i++) {
		if (a[i] < 0) {
			if (u == 1) { ko = i; break; }
			na = i; u++;
		}
	}
	for (int i = na + 1; i < ko; i++) {
		sum += a[i];
	}
	cout << "summa=" << sum << endl;

	int t = 0;
	for (int i = 0; i < n; i++) {
		if (a[i] <= 1 && a[i] >= -1) {
			float temp = a[t];
			a[t] = a[i];
			a[i] = temp;
			t++;
		}
	}
	for (int i = 0; i < n; i++) {
		cout << a[i] << " ";
	}
}
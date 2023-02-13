#include <iostream>
#include <stdlib.h>
#include <iomanip>
using namespace std;
int main()
{
	int a[100][100], n, m;
	cin >> n >> m;
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			a[i][j] = rand() % 50 - 25;
		}
	}
	int sum[100];
	for (int j = 0; j < m; j++) {
		sum[j] = 0;
		for (int i = 0; i < n; i++) {
			if (a[i][j] % 2 != 0 && a[i][j] < 0) {
				sum[j] += a[i][j];
			}
		}
		cout << "in " << j + 1 << " column summa nedative odd=" << sum[j] << endl;
	}
	cout << endl << endl;
	int summa, count = 0;
	for (int j = 0; j < m; j++) {
		summa = 0;
		for (int i = 0; i < n; i++) {
			summa += a[i][j];
			if (a[i][j] >= 0) { count++; }
		}
		if (count == n) {
			cout << "in " << j + 1 << " column no negative numbers" << endl;
		}
		else {
			cout << "in " << j + 1 << " column summa=" << summa << endl;
		}
		count = 0; summa = 0;
	}




	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			cout << setw(4) << a[i][j] << " ";
		}cout << endl;
	}

}

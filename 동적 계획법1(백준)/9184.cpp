#include <stdio.h>
#include <queue>

using namespace std;

int D[21][21][21] = { 0, };

int w(int a, int b, int c) {
	if (a <= 0) return 1;
	if (b <= 0) return 1;
	if (c <= 0) return 1;
	if (a > 20) return w(20, 20, 20);
	if (b > 20) return w(20, 20, 20);
	if (c > 20) return w(20, 20, 20);
	if (D[a][b][c] != 0) return D[a][b][c];
	else {
		if (a < b && b < c) {
			D[a][b][c] = w(a, b, c - 1) + w(a, b - 1, c - 1) - w(a, b - 1, c);
			return D[a][b][c];
		}
		else {
			D[a][b][c] = w(a - 1, b, c) + w(a - 1, b - 1, c) + w(a - 1, b, c - 1) - w(a - 1, b - 1, c - 1);
			return D[a][b][c];
		}
	}

}

int main() {
	int a, b, c;
	queue<int> result;
	queue<int> aVal;
	queue<int> bVal;
	queue<int> cVal;
	
	while (true) {
		scanf_s("%d %d %d", &a, &b, &c);

		if (a == -1 && b == -1 && c == -1) break;

		aVal.push(a);
		bVal.push(b);
		cVal.push(c);
		result.push(w(a, b, c));
	}

	while (!aVal.empty())
	{
		printf("w(%d, %d, %d) = %d\n", aVal.front(), bVal.front(), cVal.front(), result.front());
		aVal.pop();
		bVal.pop();
		cVal.pop();
		result.pop();
	}

	return 0;
}
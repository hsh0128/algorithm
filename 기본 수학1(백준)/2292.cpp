/*

*/
#include <stdio.h>

int main() {
	int N, div, res = 0, cnt = 1;

	scanf_s("%d", &N);

	if (N == 1) res = 0;
	else {
		div = (N - 2) / 6;
		div += 1;

		while (div > 0) {
			div -= cnt;

			res += 1;
			cnt += 1;
		}
	}
	res++;

	printf("%d", res);

	return 0;
}
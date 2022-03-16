#include <stdio.h>
#include <math.h>

bool isPrime(int n) {
	//fdfdf
	if (n == 1) return false;
	if (n == 2) return true;

	int maxSearch = sqrt(n);
	for (int i = 2; i <= maxSearch; i++) {
		if (n % i == 0) {
			return false;
		}
	}
	return true;
}

int main() {
	int M, N;

	scanf_s("%d %d", &M, &N);

	for (int i = M; i <= N; i++) {
		if (isPrime(i))
			printf("%d\n", i);
	}

	return 0;
}
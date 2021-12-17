#include <stdio.h>

int main() {
	int N, M, c, D[100], sum = 0;

	scanf_s("%d %d", &N, &M);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &c);
		D[i] = c;
	}

	for (int i = 0; i < N; i++) {
		for (int j = i+1; j < N; j++) {
			for (int k = j+1; k < N; k++) {
				if (D[i] + D[j] + D[k] <= M) {
					if (D[i] + D[j] + D[k] > sum) sum = D[i] + D[j] + D[k];
				}
			}
		}
	}

	printf("%d", sum);

	return 0;
}
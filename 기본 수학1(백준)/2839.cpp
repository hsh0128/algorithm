#include <stdio.h>

// N = 3X + 5Y (N은 3~5000 사이의 상수, X와 Y는 변수)
// X + Y 의 최솟값을 구하라 (Y의 최대, X의 최소를 구하면 된다)
// 5Y = N - 3X
// Y = (N - 3X) / 5

int main() {
	int N, X, Y = -1;

	scanf_s("%d", &N);

	for (X = 0; 3 * X <= N; X++) {
		if ((N - 3 * X) % 5 == 0) {
			Y = (N - 3 * X) / 5;
			break;
		}
	}

	if (Y == -1) X = 0;

	printf("%d", X + Y);

	return 0;
}
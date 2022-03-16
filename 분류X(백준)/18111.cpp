#include <stdio.h>

int height[501][501];

int N, M, B, answerTime = -1, answerHeight, minHeight = 257, maxHeight = -1;

void search(int nowHeight) {
	if (nowHeight < minHeight) {
		return;
	}

	int p = 0, b = 0, tempTime;

	for (int i = 0; i < N; i++) {
		for (int j = 0; j < M; j++) {
			if (height[j][i] > nowHeight) {
				b += (height[j][i] - nowHeight);
			}
			else if (height[j][i] < nowHeight) {
				p += (nowHeight - height[j][i]);
			}
		}
	}

	if (p > B + b) {
		search(nowHeight - 1);
		return;
	}

	tempTime = b * 2 + p;

	if (answerTime != -1 && tempTime >= answerTime) {
		return;
	}

	answerTime = tempTime;
	answerHeight = nowHeight;
	search(nowHeight - 1);

	return;
}

int main() {
	int cache;

	scanf_s("%d %d %d", &N, &M, &B);

	for (int i = 0; i < N; i++) {
		for (int j = 0; j < M; j++) {
			scanf_s("%d", &cache);
			height[j][i] = cache;

			if (cache < minHeight)
				minHeight = cache;

			if (cache > maxHeight)
				maxHeight = cache;
		}
	}

	search(maxHeight);

	printf("%d %d", answerTime, answerHeight);

	return 0;
}
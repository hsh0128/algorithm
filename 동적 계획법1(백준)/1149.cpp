#include <stdio.h>
#include <vector>
#include <algorithm>

using namespace std;

// 0 = R, 1 = G, 2 = B
int cost[3][1001];
int N;

int cal(int nowIdx, int minR, int minG, int minB) {
	int nextMinR, nextMinG, nextMinB;

	nowIdx += 1;

	nextMinR = min(minG + cost[0][nowIdx], minB + cost[0][nowIdx]);
	nextMinG = min(minR + cost[1][nowIdx], minB + cost[1][nowIdx]);
	nextMinB = min(minR + cost[2][nowIdx], minG + cost[2][nowIdx]);

	if (nowIdx == N - 1) {
		return min(nextMinR, min(nextMinG, nextMinB));
	}

	return cal(nowIdx, nextMinR, nextMinG, nextMinB);
}

int main() {
	int R, G, B, answer;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d %d %d", &R, &G, &B);
		cost[0][i] = R;
		cost[1][i] = G;
		cost[2][i] = B;
	}

	answer = cal(0, cost[0][0], cost[1][0], cost[2][0]);

	printf("%d", answer);

	return 0;
}
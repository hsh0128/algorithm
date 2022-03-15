#include <stdio.h>
#include <unordered_map>
#include <queue>

using namespace std;

unordered_map<int, int> cards;
queue<int> answer;

int main() {
	int N, M, cache;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);
		cards[cache] = 1;
	}

	scanf_s("%d", &M);

	for (int i = 0; i < M; i++) {
		scanf_s("%d", &cache);
		answer.push(cards[cache]);
	}

	while (!answer.empty()) {
		printf("%d ", answer.front());
		answer.pop();
	}

	return 0;
}
#include <stdio.h>
#include <queue>

using namespace std;

queue<int> deck;

int main() {
	int N, lastCard, cnt = 0;

	scanf_s("%d", &N);

	for (int i = 1; i <= N; i++) {
		deck.push(i);
	}

	while (!deck.empty()) {
		lastCard = deck.front();
		if (cnt) {
			deck.pop();
			deck.push(lastCard);
			cnt = 0;
		}
		else {
			deck.pop();
			cnt = 1;
		}
	}

	printf("%d", lastCard);

	return 0;
}
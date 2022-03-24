#include <stdio.h>
#include <queue>

using namespace std;

priority_queue<int, vector<int>, greater<int> > h;

queue<int> answer;

int main() {
	int N, cache;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);

		if (cache) {
			h.push(cache);
			continue;
		}

		if (h.empty()) {
			answer.push(0);
			continue;
		}

		answer.push(h.top());
		h.pop();
	}

	while (!answer.empty()) {
		printf("%d\n", answer.front());
		answer.pop();
	}

	return 0;
}
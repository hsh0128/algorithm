#include <stdio.h>
#include <queue>
#include <vector>

using namespace std;

priority_queue<int, vector<int>, greater<int> > P;

int main() {
	int N, cache, partialSum = 0, answer = 0;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);
		P.push(cache);
	}

	while (!P.empty()) {
		partialSum += P.top();
		answer += partialSum;
		P.pop();
	}

	printf("%d", answer);

	return 0;
}
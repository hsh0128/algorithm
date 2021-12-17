#include <stdio.h>
#include <queue>

using namespace std;

// 작은 것이 top에 오도록 정렬
priority_queue<int, vector<int>, greater<int> > maxHeap;
priority_queue<int, vector<int>, less<int> > minHeap;

queue<int> result;

int main() {
	int N, cache, swapCache1, swapCache2;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);

		if (minHeap.size() == maxHeap.size()) minHeap.push(cache);
		else maxHeap.push(cache);

		while (1) {
			if (maxHeap.empty()) break;

			if (maxHeap.top() < minHeap.top()) {
				swapCache1 = maxHeap.top();
				swapCache2 = minHeap.top();
				maxHeap.pop();
				minHeap.pop();
				maxHeap.push(swapCache2);
				minHeap.push(swapCache1);
			}
			else break;
		}

		result.push(minHeap.top());
	}

	while (!result.empty()) {
		printf("%d\n", result.front());
		result.pop();
	}

	return 0;
}
#include <stdio.h>
#include <queue>

using namespace std;

priority_queue<int> heap;
queue<int> result;

int main() {
	int N, cache;
	
	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);
		if (cache == 0) {
			if (heap.empty()) {
				result.push(0);
			}
			else {
				result.push(heap.top());
				heap.pop();
			}
		}
		else {
			heap.push(cache);
		}
	}

	while (!result.empty()) {
		printf("%d\n", result.front());
		result.pop();
	}

	return 0;
}
#include <stdio.h>
#include <set>
#include <queue>

using namespace std;

set<int> record;
queue<int> result;

int main() {
	int N, M, cache;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);
		record.insert(cache);
	}

	scanf_s("%d", &M);

	for (int i = 0; i < M; i++) {
		scanf_s("%d", &cache);
		if (record.find(cache) == record.end()) result.push(0);
		else result.push(1);
	}

	while (!result.empty()) {
		printf("%d\n", result.front());
		result.pop();
	}

	return 0;
}
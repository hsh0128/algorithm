#include <stdio.h>
#include <stack>

using namespace std;

stack<int> record;

int main() {
	int K, cache, result = 0;

	scanf_s("%d", &K);

	for (int i = 0; i < K; i++) {
		scanf_s("%d", &cache);
		if (!cache) record.pop();
		else record.push(cache);
	}

	while (!record.empty()) {
		result += record.top();
		record.pop();
	}

	printf("%d", result);

	return 0;
}
#include <stdio.h>
#include <queue>

using namespace std;

queue<int> result;
queue<int> num;
int main() {
	int N, K;

	scanf_s("%d %d", &N, &K);

	for (int i = 1; i <= N; i++) {
		num.push(i);
	}

	while (!num.empty()) {
		for (int i = 0; i < K - 1; i++) {
			num.push(num.front());
			num.pop();
		}
		result.push(num.front());
		num.pop();
	}

	printf("<");
	while (true)
	{
		printf("%d", result.front());
		result.pop();
		if (!result.empty()) printf(", ");
		else {
			printf(">");
			break;
		}
	}

	return 0;
}
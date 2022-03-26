#include <stdio.h>
#include <unordered_map>
#include <queue>

using namespace std;

unordered_map<int, int> D;
queue<int> answer;

int search(int remain) {
	if (D[remain]) {
		return D[remain];
	}

	D[remain] = search(remain - 1) + search(remain - 2) + search(remain - 3);

	return D[remain];

}

int main() {
	int T, n;

	D[1] = 1;
	D[2] = 2;
	D[3] = 4;

	scanf_s("%d", &T);

	for (int i = 0; i < T; i++) {
		scanf_s("%d", &n);
		answer.push(search(n));
	}

	while (!answer.empty()) {
		printf("%d\n", answer.front());
		answer.pop();
	}

	return 0;
}
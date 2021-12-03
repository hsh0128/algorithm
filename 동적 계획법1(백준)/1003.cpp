#include <stdio.h>
#include <queue>

using namespace std;

int zero[45] = { 0, };
int one[45] = { 0, };

int fibo_zero(int n) {
	if (n == 0) return 1;
	else if (n == 1) return 0;
	if (zero[n] == 0) zero[n] = fibo_zero(n - 1) + fibo_zero(n - 2);
	return zero[n];
}

int fibo_one(int n) {
	if (n == 0) return 0;
	else if (n == 1) return 1;
	if (one[n] == 0) one[n] = fibo_one(n - 1) + fibo_one(n - 2);
	return one[n];
}

int main() {
	int T, N;
	queue<int> zero_queue;
	queue<int> one_queue;


	scanf_s("%d", &T);

	for (int i = 0; i < T; i++) {
		scanf_s("%d", &N);
		zero_queue.push(fibo_zero(N));
		one_queue.push(fibo_one(N));
	}

	while (!zero_queue.empty()) {
		printf("%d %d", zero_queue.front(), one_queue.front());
		zero_queue.pop();
		one_queue.pop();
		printf("\n");
	}

	return 0;
}
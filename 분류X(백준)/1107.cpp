#include <stdio.h>
#include <unordered_map>
#include <vector>

using namespace std;

vector<int> canPress;
int answer;

int absolute(int a) {
	if (a < 0)
		return -a;
	else
		return a;
}

int calDigit(int n) {
	int cnt = 0;

	if (n == 0)
		return 1;

	while (n > 0) {
		n /= 10;
		cnt++;
	}

	return cnt;
}

void search(int target, int now) {
	if (calDigit(now) > calDigit(target) + 1 || calDigit(now) > 6) {
		return;
	}

	int temp, next;

	for (int i = 0; i < canPress.size(); i++) {
		next = now * 10 + canPress[i];
		temp = absolute(target - next) + calDigit(next);

		if (temp < answer) {
			answer = temp;
		}

		if (next)
			search(target, next);
	}

	return;
}

int main() {
	int N, M, cache;
	unordered_map<int, int> banned;

	scanf_s("%d", &N);
	scanf_s("%d", &M);

	for (int i = 0; i < M; i++) {
		scanf_s("%d", &cache);
		banned[cache] = 1;
	}

	for (int i = 0; i < 10; i++) {
		if (banned[i]) {
			continue;
		}
		canPress.push_back(i);
	}

	answer = (N > 100) ? N - 100 : 100 - N;

	search(N, 0);

	printf("%d", answer);

	return 0;
}
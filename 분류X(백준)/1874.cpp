#include <stdio.h>
#include <queue>
#include <vector>
#include <stack>

using namespace std;

vector<int> input;
priority_queue<int, vector<int>, greater<int> > numbers;
stack<int> s;
queue<bool> answer;

int main() {
	int n, cache, idx = 0;
	bool noFlag = false;

	scanf_s("%d", &n);

	for (int i = 0; i < n; i++) {
		scanf_s("%d", &cache);
		numbers.push(cache);
		input.push_back(cache);
	}

	while (n > idx) {
		if (s.empty() || s.top() != input[idx]) {
			if (numbers.empty()) {
				noFlag = true;
				break;
			}
			s.push(numbers.top());
			numbers.pop();
			answer.push(true);
			continue;
		}

		s.pop();
		idx++;
		answer.push(false);
	}

	if (noFlag) {
		printf("NO");
	} else {
		while (!answer.empty()) {
			if (answer.front()) {
				printf("+\n");
			} else {
				printf("-\n");
			}
			answer.pop();
		}
	}

	return 0;
}
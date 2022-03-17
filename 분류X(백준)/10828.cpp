#include <stdio.h>
#include <iostream>
#include <string>
#include <stack>
#include <queue>

using namespace std;

stack<int> s;
queue<int> answer;

int main() {
	int N, intCache;
	string cache;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		cin >> cache;

		if (cache == "push") {
			scanf_s("%d", &intCache);
			s.push(intCache);
		} else if (cache == "pop") {
			if (s.empty()) {
				answer.push(-1);
			} else {
				answer.push(s.top());
				s.pop();
			}
		} else if (cache == "size") {
			answer.push(s.size());
		} else if (cache == "empty") {
			if (s.empty())
				answer.push(1);
			else
				answer.push(0);
		} else if (cache == "top") {
			if (s.empty())
				answer.push(-1);
			else
				answer.push(s.top());
		}
	}

	while (!answer.empty()) {
		printf("%d\n", answer.front());
		answer.pop();
	}

	return 0;
}
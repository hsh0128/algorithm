#include <stdio.h>
#include <iostream>
#include <string>
#include <unordered_map>
#include <queue>

using namespace std;

unordered_map<string, string> dic;
queue<string> answer;

int main() {
	string cache;
	int N, M;

	scanf_s("%d %d", &N, &M);

	for (int i = 1; i <= N; i++) {
		cin >> cache;
		dic[cache] = to_string(i);
		dic[to_string(i)] = cache;
	}

	for (int i = 0; i < M; i++) {
		cin >> cache;
		answer.push(dic[cache]);
	}

	while (!answer.empty()) {
		cout << answer.front() << '\n';
		answer.pop();
	}

	return 0;
}
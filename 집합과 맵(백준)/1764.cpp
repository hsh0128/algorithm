#include <stdio.h>
#include <iostream>
#include <string>
#include <set>
#include <unordered_map>

using namespace std;

unordered_map<string, int> names;
set<string> answer;

int main() {
	int N, M, cnt = 0;
	string cache;

	scanf_s("%d %d", &N, &M);

	for (int i = 0; i < N; i++) {
		cin >> cache;
		names[cache] += 1;
	}

	for (int i = 0; i < M; i++) {
		cin >> cache;

		if (names[cache]) {
			answer.insert(cache);
			cnt += 1;
		}
	}

	printf("%d\n", cnt);

	for (auto iter = answer.begin(); iter != answer.end(); iter++) {
		cout << *iter << '\n';
	}

	return 0;
}
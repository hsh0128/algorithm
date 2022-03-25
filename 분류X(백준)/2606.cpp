#include <stdio.h>
#include <set>
#include <map>

using namespace std;

set<int> connection[101];
bool visited[101];

int search(int index) {
	if (visited[index]) {
		return 0;
	}

	visited[index] = true;
	int cnt = 1;

	for (auto iter = connection[index].begin(); iter != connection[index].end(); iter++) {
		cnt += search(*iter);
	}

	return cnt;
}

int main() {
	int N, M, cache1, cache2, answer;

	scanf_s("%d", &N);
	scanf_s("%d", &M);

	for (int i = 0; i < M; i++) {
		scanf_s("%d %d", &cache1, &cache2);
		connection[cache1].insert(cache2);
		connection[cache2].insert(cache1);
	}

	answer = search(1);

	printf("%d", answer - 1);

	return 0;
}
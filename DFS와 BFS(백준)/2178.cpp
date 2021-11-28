/*

*/
#include <stdio.h>
#include <queue>

using namespace std;

int graph[101][101];
int visited[101][101];

int N, M;

int search(queue<pair<int, int> > nowVertex, int depth) {
	queue<pair<int, int> > nextVertex;
	int i, j;

	while (!nowVertex.empty()) {
		// 4방향으로 탐색을 진행
		i = nowVertex.front().first;
		j = nowVertex.front().second;

		if (graph[i - 1][j])
			if (!visited[i - 1][j]) {
				visited[i - 1][j] = 1;
				nextVertex.push(make_pair(i - 1, j));
			}
		if (graph[i][j - 1])
			if (!visited[i][j - 1]) {
				visited[i][j - 1] = 1;
				nextVertex.push(make_pair(i, j - 1));
			}
		if (graph[i + 1][j])
			if (!visited[i + 1][j]) {
				if (i + 1 == N && j == M) return depth + 1;
				visited[i + 1][j] = 1;
				nextVertex.push(make_pair(i + 1, j));
			}
		if (graph[i][j + 1])
			if (!visited[i][j + 1]) {
				if (i == N && j + 1 == M) return depth + 1;
				visited[i][j + 1] = 1;
				nextVertex.push(make_pair(i, j + 1));
			}
		nowVertex.pop();
	}

	return search(nextVertex, depth + 1);
}

int main() {
	char cache;
	int result;
	queue<pair<int, int> > startVertex;

	startVertex.push(pair<int, int>(1, 1));

	scanf_s("%d %d", &N, &M);

	for (int i = 1; i <= N; i++) {
		for (int j = 1; j <= M; j++) {
			cache = getchar();
			if (cache == '0') graph[i][j] = 0;
			else if (cache == '1') graph[i][j] = 1;
			else if (cache == '\n') {
				j--;
				continue;
			}
		}
	}

	result = search(startVertex, 1);

	printf("%d", result);

	return 0;
}
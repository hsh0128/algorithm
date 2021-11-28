/*

*/
#include <stdio.h>
#include <set>
#include <queue>

using namespace std;

set<int> graph[1001];

int dfsVisited[1001];
int bfsVisited[1001];

queue<int> bfsVisitQueue;

queue<int> bfsResult;
queue<int> dfsResult;

void dfs(int nowVertex) {
	set<int>::iterator iter;
	dfsResult.push(nowVertex);
	dfsVisited[nowVertex] = 1;

	for (iter = graph[nowVertex].begin(); iter != graph[nowVertex].end(); iter++) {
		// 방문하지 않았을 경우
		if (!dfsVisited[*iter]) {
			dfs(*iter);
		}
	}
}

void bfs(int startVertex) {
	set<int>::iterator iter;
	int nowVertex;

	bfsVisited[startVertex] = 1;
	bfsVisitQueue.push(startVertex);

	while (!bfsVisitQueue.empty()) {
		nowVertex = bfsVisitQueue.front();
		bfsResult.push(nowVertex);

		for (iter = graph[nowVertex].begin(); iter != graph[nowVertex].end(); iter++) {
			if (!bfsVisited[*iter]) {
				bfsVisited[*iter] = 1;
				bfsVisitQueue.push(*iter);
			}
		}
		bfsVisitQueue.pop();
	}
}

int main() {
	int N, M, V, v1, v2;

	scanf_s("%d %d %d", &N, &M, &V);

	for (int i = 0; i < M; i++) {
		scanf_s("%d %d", &v1, &v2);
		graph[v1].insert(v2);
		graph[v2].insert(v1);
	}

	dfs(V);
	bfs(V);

	while (!dfsResult.empty()) {
		printf("%d ", dfsResult.front());
		dfsResult.pop();
	}

	printf("\n");

	while (!bfsResult.empty()) {
		printf("%d ", bfsResult.front());
		bfsResult.pop();
	}

	return 0;
}
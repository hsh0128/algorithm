#include <stdio.h>
#include <queue>

using namespace std;

struct TreeNode {
	queue<int> links;
};

TreeNode tree[100001];
int parent[100001];

void check(int node) {
	while (!tree[node].links.empty()) {
		if (parent[node] != tree[node].links.front()) {
			parent[tree[node].links.front()] = node;
			check(tree[node].links.front());
		}
		tree[node].links.pop();
	}
}

int main() {
	int N, cache1, cache2;

	scanf_s("%d", &N);

	for (int i = 0; i < N - 1; i++) {
		scanf_s("%d %d", &cache1, &cache2);
		tree[cache1].links.push(cache2);
		tree[cache2].links.push(cache1);
	}

	check(1);

	for (int i = 2; i <= N; i++) {
		printf("%d\n", parent[i]);
	}

	return 0;
}
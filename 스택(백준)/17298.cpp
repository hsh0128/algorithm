#include <stdio.h>
#include <vector>
#include <queue>

using namespace std;

priority_queue<pair<int, int>, vector<pair<int, int> >, greater<pair<int, int> > > NStack;
vector<int> answer;

int main() {
	int N, cache;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);

		while (!NStack.empty() && NStack.top().first < cache) {
			answer[NStack.top().second] = cache;
			NStack.pop();
		}

		NStack.push(make_pair(cache, i));
		answer.push_back(-1);
	}

	for (auto iter = answer.begin(); iter != answer.end(); iter++) {
		printf("%d ", *iter);
	}

	return 0;
}
#include <stdio.h>
#include <vector>
#include <queue>

using namespace std;

priority_queue<pair<int, int>, vector<pair<int, int>>, greater<pair<int, int> > > pq;
vector<int> answer;

int main() {
	int N, cache, top, cnt = 0;
	bool flag = true;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);
		pq.push(make_pair(cache, i));
		answer.push_back(0);
	}

	while (!pq.empty()) {
		if (flag) {
			flag = false;
			top = pq.top().first;
			answer[pq.top().second] = cnt;

			pq.pop();
			continue;
		}

		if (top == pq.top().first) {
			answer[pq.top().second] = cnt;

			pq.pop();
			continue;
		}

		cnt++;
		top = pq.top().first;
		answer[pq.top().second] = cnt;

		pq.pop();
	}

	for (int i = 0; i < answer.size(); i++) {
		printf("%d ", answer[i]);
	}

	return 0;
}
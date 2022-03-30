#include <stdio.h>
#include <iostream>
#include <set>
#include <queue>

using namespace std;

multiset<int> double_pq;
queue<pair<int, int> > answer;
queue<bool> hasAnswer;

int main() {
	char cacheChar;
	int cacheInt;
	int T, k;

	scanf_s("%d", &T);

	for (int i = 0; i < T; i++) {
		scanf_s("%d", &k);

		double_pq.clear();

		for (int i = 0; i < k; i++) {
			cin >> cacheChar >> cacheInt;
			
			if (cacheChar == 'D') {
				if (double_pq.empty()) {
					continue;
				}

				if (cacheInt == 1) {
					double_pq.erase(--(double_pq.end()));
				}
				else if (cacheInt == -1) {
					double_pq.erase(double_pq.begin());
				}
			}
			else if (cacheChar == 'I') {
				double_pq.insert(cacheInt);
			}
		}

		if (double_pq.empty()) {
			hasAnswer.push(false);
			continue;
		}

		answer.push(make_pair(*(--double_pq.end()), *double_pq.begin()));
		hasAnswer.push(true);
	}

	while (!answer.empty() || !hasAnswer.empty()) {
		if (!hasAnswer.front()) {
			printf("EMPTY\n");
			hasAnswer.pop();
			continue;
		}

		printf("%d %d\n", answer.front().first, answer.front().second);
		answer.pop();
		hasAnswer.pop();
	}

	return 0;
}
#include <stdio.h>
#include <set>
#include <unordered_map>

using namespace std;

set<int> connection[101];

int search(int step, unordered_map<int, int> searched, set<int> nowNode) {
	if (nowNode.empty()) {
		return 0;
	}

	int temp = 0;
	set<int> nextNode;
	step += 1;

	for (auto iter = nowNode.begin(); iter != nowNode.end(); iter++) {
		for (auto it = connection[*iter].begin(); it != connection[*iter].end(); it++) {
			if (searched[*it]) {
				continue;
			}

			searched[*it] = 1;
			temp++;
			nextNode.insert(*it);
		}
	}

	return step * temp + search(step, searched, nextNode);
}

int main() {
	int N, M, fir, sec, answer = 999999, tmpAnswer, answerIdx = -1;

	scanf_s("%d %d", &N, &M);

	for (int i = 0; i < M; i++) {
		scanf_s("%d %d", &fir, &sec);
		connection[fir].insert(sec);
		connection[sec].insert(fir);
	}

	for (int i = 1; i <= N; i++) {
		unordered_map<int, int> tempMap;
		set<int> tempSet;

		tempMap[i] = 1;
		tempSet.insert(i);

		tmpAnswer = search(0, tempMap, tempSet);

		if (tmpAnswer < answer) {
			answer = tmpAnswer;
			answerIdx = i;
		}
	}

	printf("%d", answerIdx);

	return 0;
}
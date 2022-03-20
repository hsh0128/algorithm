#include <stdio.h>
#include <unordered_map>
#include <vector>
#include <string>
#include <queue>

using namespace std;

int field[51][51];

// 0: land 1: cabbage(not searched) 2 : searched cabbage
// 100 * X + Y = key
unordered_map<int, int> cabbageMap;
vector<pair<int, int> > cabbageVector;

queue<int> answerQueue;

void search(int nowX, int nowY) {
	cabbageMap[100 * nowX + nowY] = 2;

	if (cabbageMap[100 * (nowX - 1) + nowY] == 1) {
		search(nowX - 1, nowY);
	}

	if (cabbageMap[100 * (nowX + 1) + nowY] == 1) {
		search(nowX + 1, nowY);
	}

	if (cabbageMap[100 * nowX + nowY - 1] == 1) {
		search(nowX, nowY - 1);
	}

	if (cabbageMap[100 * nowX + nowY + 1] == 1) {
		search(nowX, nowY + 1);
	}
}

int main() {
	int T, M, N, K, tempX, tempY, answer;

	scanf_s("%d", &T);

	for (int i = 0; i < T; i++) {
		answer = 0;
		cabbageMap.clear();
		cabbageVector.clear();
		scanf_s("%d %d %d", &M, &N, &K);
		
		for (int j = 0; j < K; j++) {
			scanf_s("%d %d", &tempX, &tempY);
			cabbageMap[100 * tempX + tempY] = 1;
			cabbageVector.push_back(make_pair(tempX, tempY));
		}

		for (auto iter = cabbageVector.begin(); iter != cabbageVector.end(); iter++) {
			if (cabbageMap[100 * (iter->first) + iter->second] == 1) {
				search(iter->first, iter->second);
				answer += 1;
			}
		}

		answerQueue.push(answer);
	}

	while (!answerQueue.empty()) {
		printf("%d\n", answerQueue.front());
		answerQueue.pop();
	}

	return 0;
}
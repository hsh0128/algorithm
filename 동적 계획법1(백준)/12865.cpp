#include <stdio.h>
#include <vector>
#include <map>

using namespace std;

// first -> weight, second -> value
vector<pair<int, int> > stuffs, dpCache;
map<int, int> D;
int N, K, maxValue = 0;

int search(int nowIdx) {
	if (nowIdx == N) {
		return maxValue;
	}

	int nowWeight = stuffs[nowIdx].first;
	int nowValue = stuffs[nowIdx].second;

	if (nowWeight > K) {
		return search(nowIdx + 1);
	}

	dpCache.clear();

	for (auto iter = D.begin(); iter != D.end(); iter++) {
		if (iter->first + nowWeight > K) {
			break;
		}

		if (D[iter->first + nowWeight] < iter->second + nowValue) {
			// D[iter->first + nowWeight] = iter->second + nowValue;
			dpCache.push_back(make_pair(iter->first + nowWeight, iter->second + nowValue));

			if (iter->second + nowValue > maxValue) {
				maxValue = iter->second + nowValue;
			}
		}
	}

	for (int i = 0; i < dpCache.size(); i++) {
		D[dpCache[i].first] = dpCache[i].second;
	}

	if (D[nowWeight] < nowValue) {
		D[nowWeight] = nowValue;

		if (nowValue > maxValue) {
			maxValue = nowValue;
		}
	}

	return search(nowIdx + 1);
}

int main() {
	int W, V, answer;

	scanf_s("%d %d", &N, &K);

	for (int i = 0; i < N; i++) {
		scanf_s("%d %d", &W, &V);
		stuffs.push_back(make_pair(W, V));
	}

	answer = search(0);

	printf("%d", answer);

	return 0;
}
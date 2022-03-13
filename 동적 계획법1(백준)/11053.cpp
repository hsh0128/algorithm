#include <stdio.h>
#include <vector>
#include <map>

using namespace std;

vector<int> A;
map<int, int> D;

int N, maxLen = 0;

int search(int nowIdx) {
	if (nowIdx == N) {
		return maxLen;
	}
	//dfdf
	int nowValue = A[nowIdx];
	int longest = 0;

	for (auto iter = D.begin(); iter != D.end(); iter++) {
		if (iter->first >= nowValue) {
			break;
		}

		if (iter->second > longest) {
			longest = iter->second;
		}
	}

	longest += 1;

	if (D[nowValue] < longest) {
		D[nowValue] = longest;
		
		if (longest > maxLen) {
			maxLen = longest;
		}
	}

	return search(nowIdx + 1);
}

int main() {
	int cache, answer;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);
		A.push_back(cache);
	}

	answer = search(0);

	printf("%d", answer);

	return 0;
}
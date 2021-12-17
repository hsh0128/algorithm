/* 
* 이 문제는 풀긴 했는데 약간의 의문점이 남는다
* 밑에 NVal이 0 이하일 경우 각 입력의 buffer(func와 arr)를 완전히 초기화 해주는 코드가 있는데
* 이 코드가 있을 경우엔 문제를 해결했지만
* 이 코드가 없을 경우엔 50%에서 틀렸다고 나온다
* 아마도 buffer를 잘 비우느냐에 따른 반례가 존재한다는 것이니 버퍼는 꼬박꼬박 비우기?
* 나중에 반례를 생각해봐도 좋고
*/

#include <stdio.h>
#include <queue>
#include <deque>

using namespace std;

deque<int> arr;
// 1은 Reverse, 2는 Delete를 뜻함
queue<int> func;
queue<int> result;

// 여기에 앞으로 몇개의 int를 result에서 뽑아내야 할지 기록
int NVal[101];

int main() {
	char a, p;
	int T, n, DeleteCnt, arrayCache;
	bool isReversed;

	scanf_s("%d", &T);


	for (int i = 0; i < T; i++) {
		// \n값 제거
		scanf_s("%c", &p, 1);
		DeleteCnt = 0;
		isReversed = false;

		while (true) {
			scanf_s("%c", &p, 1);
			if (p == '\n') break;
			if (p == 'R') func.push(1);
			if (p == 'D') {
				func.push(2);
				DeleteCnt++;
			}
		}
		scanf_s("%d", &n);
		// \n값 제거
		scanf_s("%c", &p, 1);
		while (true) {
			scanf_s("%c", &a, 1);
			if (a == ']') break;
			scanf_s("%d", &arrayCache);
			arr.push_back(arrayCache);
		}
		NVal[i] = n - DeleteCnt;

		if (NVal[i] <= 0) {
			while (!func.empty()) func.pop();
			while (!arr.empty()) arr.pop_front();
		}
		else {
			while (!func.empty()) {
				// Reverse
				if (func.front() == 1) {
					isReversed = !isReversed;
				}
				// Delete
				if (func.front() == 2) {
					if (isReversed) {
						arr.pop_back();
					}
					else {
						arr.pop_front();
					}
				}
				func.pop();
			}

			while (!arr.empty()) {
				if (isReversed) {
					result.push(arr.back());
					arr.pop_back();
				}
				else {
					result.push(arr.front());
					arr.pop_front();
				}
			}
		}
	}

	for (int i = 0; i < T; i++) {
		if (NVal[i] < 0) {
			printf("error\n");
			continue;
		}
		printf("[");
		for (int j = 1; j <= NVal[i]; j++) {
			printf("%d", result.front());
			result.pop();
			if (j != NVal[i]) printf(",");
		}
		printf("]\n");
	}
	
	return 0;
}
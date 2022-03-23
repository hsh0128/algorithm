#include <stdio.h>
#include <set>

using namespace std;

bool searched[200001];

int search(int M, int step, set<int> now) {
	set<int> next;
	
	for (auto iter = now.begin(); iter != now.end(); iter++) {
		if (*iter + 1 == M || *iter - 1 == M || *iter * 2 == M) {
			return step + 1;
		}

		// -
		if (*iter > 0 && !searched[*iter - 1]) {
			next.insert(*iter - 1);
			searched[*iter - 1] = true;
		}

		// +
		if (*iter < M && !searched[*iter + 1]) {
			next.insert(*iter + 1);
			searched[*iter + 1] = true;
		}

		// 2x
		if (*iter < M && !searched[*iter * 2]) {
			next.insert(*iter * 2);
			searched[*iter * 2] = true;
		}
	}

	return search(M, step + 1, next);
}

int main() {
	set<int> temp;
	int N, M, answer;

	scanf_s("%d %d", &N, &M);

	if (N == M) {
		answer = 0;
	}
	else {
		temp.insert(N);

		answer = search(M, 0, temp);
	}

	printf("%d", answer);

	return 0;
}
#include <stdio.h>
#include <vector>

using namespace std;

vector<int> P, R;

int main() {
	int N, cache, max;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);
		P.push_back(cache);
	}

	R.push_back(P[0]);

	for (int i = 1; i < N; i++) {
		max = P[i];

		for (int j = 1; j <= i; j++) {
			if (max < P[i - j] + R[j - 1]) {
				max = P[i - j] + R[j - 1];
			}
		}

		R.push_back(max);
	}

	printf("%d", R[N - 1]);

	return 0;
}
#include <iostream>

using namespace std;

bool isConstructor(int now, int N);

int main(void) {
	int N;

	cin.tie(NULL);
	ios_base::sync_with_stdio(false);

	cin >> N;

	for (int i = 1; i < N; i++) {
		if (isConstructor(i, N)) {
			cout << i;
			return 0;
		}
	}

	cout << "0";

	return 0;
}

bool isConstructor(int now, int N) {
	int cache = now;

	while (cache > 0) {
		now += (cache % 10);
		cache /= 10;
	}

	return (N == now);
}
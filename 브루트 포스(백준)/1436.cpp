#include <iostream>

using namespace std;

bool isSix(int value);

int main() {
	int N, n = 0, nowValue = 665;

	cin.tie(NULL);
	ios_base::sync_with_stdio(false);

	cin >> N;

	while (true) {
		nowValue++;

		if (!isSix(nowValue)) {
			continue;
		}

		n++;
		if (n == N) {
			cout << nowValue;
			break;
		}
	}

	return 0;
}

bool isSix(int value) {
	int countSix = 0;

	while (value > 0) {
		if (value % 10 != 6) {
			countSix = 0;
			value /= 10;
			continue;
		}

		countSix++;
		if (countSix == 3) {
			return true;
		}

		value /= 10;
	}

	return false;
}
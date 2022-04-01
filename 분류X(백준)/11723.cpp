#include <iostream>
#include <string>

using namespace std;

int D[21];

int main() {
	int M, c;
	string cache;

	cin.tie(NULL);
	ios_base::sync_with_stdio(false);

	cin >> M;

	for (int i = 0; i < M; ++i) {
		cin >> cache;

		if (cache == "add") {
			cin >> c;
			D[c] = 1;
			continue;
		}
		
		if (cache == "remove") {
			cin >> c;
			D[c] = 0;
			continue;
		}

		if (cache == "check") {
			cin >> c;
			cout << D[c] << '\n';
			continue;
		}

		if (cache == "toggle") {
			cin >> c;
			D[c] = D[c] ? 0 : 1;
			continue;
		}

		if (cache == "all") {
			for (int i = 1; i <= 20; ++i) {
				D[i] = 1;
			}
			continue;
		}

		if (cache == "empty") {
			for (int i = 1; i <= 20; ++i) {
				D[i] = 0;
			}
		}
	}

	return 0;
}
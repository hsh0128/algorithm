#include <stdio.h>
#include <set>
#include <map>

using namespace std;

map<int, set<int> > connection;
bool searched[1001];

void search(int index) {
	if (searched[index]) {
		return;
	}

	searched[index] = true;
	set<int> now = connection[index];

	for (auto iter = now.begin(); iter != now.end(); iter++) {
		search(*iter);
	}
}

int main() {
	int N, M, fir, sec, answer = 0;

	scanf_s("%d %d", &N, &M);

	for (int i = 0; i < M; i++) {
		scanf_s("%d %d", &fir, &sec);
		connection[fir].insert(sec);
		connection[sec].insert(fir);
	}

	for (int i = 1; i <= N; i++) {
		if (searched[i]) {
			continue;
		}

		answer += 1;
		search(i);
	}

	printf("%d", answer);

	return 0;
}
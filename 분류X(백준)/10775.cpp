#include <iostream>

using namespace std;

int D[100001];
int G, P;

int FindMin(int nowIdx) {
	if (nowIdx == D[nowIdx]) return nowIdx;
	
	D[nowIdx] = FindMin(D[nowIdx]);
	return D[nowIdx];
}

int main() {
	cin.tie(NULL);
	ios_base::sync_with_stdio(false);

	int g;
	bool flag = false;
	int answer = 0;
	int minimum;

	cin >> G >> P;

	for (int i = 1; i <= G; i++) {
		D[i] = i;
	}

	for (int i = 0; i < P; i++) {
		cin >> g;

		if (flag) continue;

		minimum = FindMin(g);

		if (minimum == 0) {
			flag = true;
			continue;
		}

		answer += 1;
		D[minimum] -= 1;
	}

	cout << answer;

	return 0;
}
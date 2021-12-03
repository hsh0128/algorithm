#include <stdio.h>
#include <queue>

using namespace std;

// N과 K의 크기가 14밖에 되지 않으므로 DP를 사용해보자 -> 크기가 작아서 사용할 필요가 없다
// 브루트 포스로 풀어도 풀렸다
int D[14][14] = { 0, };

int f(int k, int n) {
	int ret = 0;
	if (k == 0) return n;
	//if (D[k][n - 1] != 0) return D[k][n - 1];
	for (int i = 1; i <= n; i++) {
		ret += f(k - 1, i);
	}
	//D[k][n - 1] = ret;
	return ret;
}

int main() {
	int T, k, n;
	queue<int> res;

	scanf_s("%d", &T);

	for (int i = 0; i < T; i++) {
		scanf_s("%d", &k);
		scanf_s("%d", &n);

		res.push(f(k, n));
	}

	while (!res.empty())
	{
		printf("%d\n", res.front());
		res.pop();
	}

	return 0;
}
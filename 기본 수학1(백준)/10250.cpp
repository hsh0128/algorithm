#include <stdio.h>
#include <queue>

using namespace std;

int main() {
	int T, H, W, N;
	queue<int> res;

	scanf_s("%d", &T);

	for (int i = 0; i < T; i++) {
		scanf_s("%d %d %d", &H, &W, &N);
		if (N % H != 0)
			res.push((N % H) * 100 + (N / H) + 1);
		else
			res.push(H * 100 + (N / H));
	}

	while (!res.empty()) {
		if (res.size() != 1) 
			printf("%d\n", res.front());
		else
			printf("%d", res.front());
		res.pop();
	}

	return 0;
}
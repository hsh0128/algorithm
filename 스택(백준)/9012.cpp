#include <stdio.h>
#include <queue>

using namespace std;

queue<int> result;

int main() {
	int T, cnt;
	char str[52];

	scanf_s("%d", &T);

	for (int i = 0; i < T; i++) {
		cnt = 0;
		scanf_s("%s", str, 51);
		for (int j = 0; str[j] != 0; j++) {
			if (str[j] == '(') {
				cnt++;
			}
			else if (str[j] == ')') {
				cnt--;
				if (cnt < 0) break;
			}
			else {
				printf("error");
			}
		}
		if (cnt == 0) result.push(0);
		else result.push(1);
	}

	while (!result.empty()) {
		if (!result.front()) printf("YES\n");
		else printf("NO\n");
		result.pop();
	}

	return 0;
}
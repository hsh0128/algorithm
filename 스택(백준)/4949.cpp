#include <stdio.h>
#include <queue>
#include <stack>

using namespace std;

queue<int> result;

int main() {
	int cnt1, cnt2;
	char str[102];
	// 소괄호는 1로 저장, 대괄호는 2로 저장
	stack<int> s;

	while (true) {
		while (!s.empty()) s.pop();
		cnt1 = 0;
		cnt2 = 0;
		scanf_s("%[^.]%*s", str, 101);
		if (str[1] == 0) {
			break;
		}
		else {
			for (int i = 0; str[i] != 0; i++) {
				if (str[i] == '(') {
					s.push(1);
				}
				else if (str[i] == '[') {
					s.push(2);
				}
				else if (str[i] == ')') {
					if (s.empty()) {
						s.push(3);
						break;
					}
					if (s.top() == 1) s.pop();
					else break;
				}
				else if (str[i] == ']') {
					if (s.empty()) {
						s.push(3);
						break;
					}
					if (s.top() == 2) s.pop();
					else break;
				}
			}
			if (s.empty()) result.push(1);
			else result.push(0);
		}
	}

	while (!result.empty()) {
		if (result.front()) printf("yes\n");
		else printf("no\n");
		result.pop();
	}

	return 0;
}
#include <stdio.h>
#include <iostream>
#include <string>

using namespace std;

int main() {
	string query, temp;
	int answer = 0, startIdx = 0;
	bool flag = false;

	cin >> query;

	for (int i = 0; i < query.length(); i++) {
		if (query[i] == '-') {
			if (i == 0) {
				flag = true;
				startIdx = 1;
				continue;
			}

			temp = query.substr(startIdx, i - startIdx);

			if (flag) {
				answer -= stoi(temp);
			} else {
				answer += stoi(temp);
			}
			startIdx = i + 1;

			flag = true;
			continue;
		}

		if (query[i] == '+') {
			temp = query.substr(startIdx, i - startIdx);

			if (flag) {
				answer -= stoi(temp);
			} else {
				answer += stoi(temp);
			}

			startIdx = i + 1;
		}
	}

	temp = query.substr(startIdx, query.length() - startIdx);

	if (flag) {
		answer -= stoi(temp);
	}
	else {
		answer += stoi(temp);
	}

	printf("%d", answer);

	return 0;
}
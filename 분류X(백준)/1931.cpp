#include <stdio.h>
#include <map>
#include <set>

using namespace std;

map<int, multiset<int> > rooms;

int main() {
	int N, fir, sec, nowTime = 0, answer = 0;
	bool flag = true;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d %d", &fir, &sec);
		rooms[sec].insert(fir);
	}

	while (flag && !rooms.empty() && rooms.rbegin()->first >= nowTime) {
		for (auto iter = rooms.begin(); iter != rooms.end();) {
			if (iter->first < nowTime) {
				rooms.erase(iter++);
				continue;
			}

			//printf("begin : %d\n", *(iter->second.begin()));

			if (*(iter->second.begin()) < nowTime) {
				rooms[iter->first].erase(iter->second.begin());

				if (rooms[iter->first].size() == 0) {
					rooms.erase(iter++);
				}

				continue;
			}

			//printf("%d %d\n", *(iter->second.begin()), iter->first);
			nowTime = iter->first;
			answer++;
			flag = false;

			rooms[iter->first].erase(iter->second.begin());
			if (rooms[iter->first].size() == 0) {
				rooms.erase(iter);
			}
			break;
		}

		flag = !flag;
		//printf("size : %d\n", rooms.size());
	}

	printf("%d", answer);

	return 0;
}
#include <stdio.h>
#include <vector>

using namespace std;

struct pos {
	int x;
	int y;
};

int N, M;

// true: wall, false: moveable
bool map[1001][1001];
// 0: not visited, 1: visited with no break, 2: visited with break
int visited[1001][1001];

// pos, state pair
int search(int step, vector<pair<pos, bool> > haveToVisit) {
	if (haveToVisit.size() == 0) {
		return -1;
	}

	vector<pair<pos, bool> > nextVisit;
	
	int nowX, nowY;
	bool canBreak;

	pos temp;
	
	for (auto iter = haveToVisit.begin(); iter != haveToVisit.end(); iter++) {
		nowX = iter->first.x;
		nowY = iter->first.y;

		if (nowX == M - 1 && nowY == N - 1) {
			return step;
		}

		canBreak = iter->second;

		//printf("X : %d / Y : %d / step : %d / canBreak : %d\n", nowX, nowY, step, canBreak);

		// up
		if (nowY > 0) {
			temp.x = nowX;
			temp.y = nowY - 1;

			// block is here
			if (map[temp.y][temp.x]) {
				if (canBreak && !visited[temp.y][temp.x]) {
					nextVisit.push_back(make_pair(temp, false));
					visited[temp.y][temp.x] = 2;
				}
			} // no block
			else {
				if (visited[temp.y][temp.x] == 0) {
					nextVisit.push_back(make_pair(temp, canBreak));

					if (canBreak) {
						visited[temp.y][temp.x] = 1;
					}
					else {
						visited[temp.y][temp.x] = 2;
					}
				}

				else if (visited[temp.y][temp.x] == 2) {
					if (canBreak) {
						nextVisit.push_back(make_pair(temp, canBreak));
						visited[temp.y][temp.x] = 1;
					}
				}
			}
		}

		// down
		if (nowY < N - 1) {
			temp.x = nowX;
			temp.y = nowY + 1;

			// block is here
			if (map[temp.y][temp.x]) {
				if (canBreak && !visited[temp.y][temp.x]) {
					nextVisit.push_back(make_pair(temp, false));
					visited[temp.y][temp.x] = 2;
				}
			} // no block
			else {
				if (visited[temp.y][temp.x] == 0) {
					nextVisit.push_back(make_pair(temp, canBreak));

					if (canBreak) {
						visited[temp.y][temp.x] = 1;
					}
					else {
						visited[temp.y][temp.x] = 2;
					}
				}

				else if (visited[temp.y][temp.x] == 2) {
					if (canBreak) {
						nextVisit.push_back(make_pair(temp, canBreak));
						visited[temp.y][temp.x] = 1;
					}
				}
			}
		}
		
		// left
		if (nowX > 0) {
			temp.x = nowX - 1;
			temp.y = nowY;

			// block is here
			if (map[temp.y][temp.x]) {
				if (canBreak && !visited[temp.y][temp.x]) {
					nextVisit.push_back(make_pair(temp, false));
					visited[temp.y][temp.x] = 2;
				}
			} // no block
			else {
				if (visited[temp.y][temp.x] == 0) {
					nextVisit.push_back(make_pair(temp, canBreak));

					if (canBreak) {
						visited[temp.y][temp.x] = 1;
					}
					else {
						visited[temp.y][temp.x] = 2;
					}
				}

				else if (visited[temp.y][temp.x] == 2) {
					if (canBreak) {
						nextVisit.push_back(make_pair(temp, canBreak));
						visited[temp.y][temp.x] = 1;
					}
				}
			}
		}
		
		// right
		if (nowX < M - 1) {
			temp.x = nowX + 1;
			temp.y = nowY;

			// block is here
			if (map[temp.y][temp.x]) {
				if (canBreak && !visited[temp.y][temp.x]) {
					nextVisit.push_back(make_pair(temp, false));
					visited[temp.y][temp.x] = 2;
				}
			} // no block
			else {
				if (visited[temp.y][temp.x] == 0) {
					nextVisit.push_back(make_pair(temp, canBreak));

					if (canBreak) {
						visited[temp.y][temp.x] = 1;
					}
					else {
						visited[temp.y][temp.x] = 2;
					}
				}

				else if (visited[temp.y][temp.x] == 2) {
					if (canBreak) {
						nextVisit.push_back(make_pair(temp, canBreak));
						visited[temp.y][temp.x] = 1;
					}
				}
			}
		}
	}

	return search(step + 1, nextVisit);
}

int main() {
	int answer;
	char cache;
	pos tmpPos;
	vector<pair<pos, bool> > tmpVec;

	tmpPos.x = 0;
	tmpPos.y = 0;

	tmpVec.push_back(make_pair(tmpPos, true));

	scanf_s("%d %d", &N, &M);

	scanf_s("%c", &cache, 1);

	for (int i = 0; i < N; i++) {
		for (int j = 0; j < M; j++) {
			scanf_s("%c", &cache, 1);

			if (cache == '0') {
				map[i][j] = false;
			} else {
				map[i][j] = true;
			}
		}
		scanf_s("%c", &cache, 1);
	}

	answer = search(1, tmpVec);

	printf("%d", answer);

	return 0;
}
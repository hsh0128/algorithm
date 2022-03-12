#include <stdio.h>
#include <vector>

using namespace std;

int D[1001][1001];
int N, M;
vector<pair<int, int> > initNode;

int BFS(int remain, int step, vector<pair<int, int> > nodes) {
	if (remain <= 0) {
		return step;
	}

	if (nodes.empty()) {
		return -1;
	}

	vector<pair<int, int> > nextNode;
	
	int tempX, tempY;

	for (auto iter = nodes.begin(); iter != nodes.end(); iter++) {
		tempX = iter->first;
		tempY = iter->second;

		// up
		if (tempY > 0 && !D[tempX][tempY - 1]) {
			D[tempX][tempY - 1] = 1;
			nextNode.push_back(make_pair(tempX, tempY - 1));
			remain--;
		}
		// down
		if (tempY < N-1 && !D[tempX][tempY + 1]) {
			D[tempX][tempY + 1] = 1;
			nextNode.push_back(make_pair(tempX, tempY + 1));
			remain--;
		}

		// left
		if (tempX > 0 && !D[tempX - 1][tempY]) {
			D[tempX - 1][tempY] = 1;
			nextNode.push_back(make_pair(tempX - 1, tempY));
			remain--;
		}
		
		// right
		if (tempX < M-1 && !D[tempX + 1][tempY]) {
			D[tempX + 1][tempY] = 1;
			nextNode.push_back(make_pair(tempX + 1, tempY));
			remain--;
		}

	}

	return BFS(remain, step + 1, nextNode);

}

int main() {
	int cache, remainZero = 0, answer;

	scanf_s("%d %d", &M, &N);

	for (int i = 0; i < N; i++) {
		for (int j = 0; j < M; j++) {
			scanf_s("%d", &cache);
			
			if (cache == 1) {
				initNode.push_back(make_pair(j, i));
			}

			if (cache == 0) {
				remainZero += 1;
			}

			D[j][i] = cache;
		}
	}

	answer = BFS(remainZero, 0, initNode);

	printf("%d", answer);

	return 0;
}
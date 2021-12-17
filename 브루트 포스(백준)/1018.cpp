#include <stdio.h>

int main() {
	int D[50][50] = { 0, };
	int chessboard1[8][8] = {
		{0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0}
	};
	int chessboard2[8][8] = {
		{1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1}
	};
	char color[52];
	int N, M ,count, result = 3000;

	scanf_s("%d %d", &N, &M);

	for (int i = 0; i < N; i++) {
		scanf_s("%s", color, M+1);
		for (int j = 0; j < M; j++) {
			if (color[j] == 'B') D[i][j] = 0;
			else if (color[j] == 'W') D[i][j] = 1;
		}
	}

	// 체스판 찾기
	for (int i = 0; i < N - 7; i++) {
		for (int j = 0; j < M - 7; j++) {
			for (int m = 0; m < 2; m++) {
				count = 0;
				for (int k = 0; k < 8; k++) {
					for (int l = 0; l < 8; l++) {
						if (m) {
							if (chessboard1[k][l] != D[i + k][j + l]) count++;
						}
						else {
							if (chessboard2[k][l] != D[i + k][j + l]) count++;
						}
					}
				}
				if (count < result) result = count;
			}
		}
	}

	printf("%d", result);

	return 0;
}
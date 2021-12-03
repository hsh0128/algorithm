/*
문제를 쪼개야 한다 어떻게 쪼갤까
일단 쪼개지는 수는 최대 8번이다

종이의 횟수를 구하는 방법

분할 정복은 3가지 단계를 가진다
문제를 나누기 -> 나눠진 각 문제의 답을 구하기 -> 이들을 합쳐서 전체 문제의 답을 구하기
1. 문제를 나누는 방법 -> 사각형은 항상 2^n크기의 정사각형임, 색이 모두 다를 경우 count(2^7, 0, 0) = count(2^6, 0, 0) + count(2^6, 2^6, 0) + ... 이렇게 된다
2. 각 문제의 답 -> 사각형의 색이 같으면 1, 아닐 경우 4로 무조건 나누어짐
3. 이 문제들을 합치기 -> 모든 색종이의 색이 같다면 그냥 1이 되고, 아닐 경우 각 경우의 수를 모두 더하면 된다!

문제를 나누는 방법, 현재 색종이의 x(or y)에서 length/2를 더해주면 된다?
*/

#include <stdio.h>
#include <math.h>

int D[128][128];

int count(int length, int x, int y, int color) {
	int clr = D[x][y];
	for (int i = 0; i < length; i++) {
		for (int j = 0; j < length; j++) {
			if (clr != D[x + i][y + j]) return count(length / 2, x, y, color) + count(length / 2, x + (length/2), y, color)
				+ count(length / 2, x, y + (length/2), color) + count(length/2, x + (length/2), y + (length/2), color);
		}
	}
	if (color == clr) return 1;
	else return 0;
}

int main() {
	int N, white, blue;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		for (int j = 0; j < N; j++) {
			scanf_s("%d", &D[i][j]);
		}
	}

	white = count(N, 0, 0, 0);
	blue = count(N, 0, 0, 1);

	printf("%d\n%d", white, blue);

	return 0;
}
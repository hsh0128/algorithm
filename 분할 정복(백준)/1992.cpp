/*
사진을 압축한 결과를 내야 한다
색이 모두 흰색일 경우 0, 검은색일 경우 1
만약 다르다면 ()를 붙이고 안에 적음
재귀를 적용해서 문자열을 전역변수로 옮기고 리턴값을 void로 설정해서 만들어보기
*/

#include <stdio.h>
#include <queue>

using namespace std;

int D[64][64];
queue<char> result;

void QuadTree(int size, int x, int y) {
	int clr = D[x][y];
	for (int i = 0; i < size; i++) {
		for (int j = 0; j < size; j++) {
			if (clr != D[x+i][y+j]) {
				result.push('(');
				QuadTree(size / 2, x, y);
				QuadTree(size / 2, x, y + (size / 2));
				QuadTree(size / 2, x + (size / 2), y);
				QuadTree(size / 2, x + (size / 2), y + (size / 2));
				result.push(')');
				return;
			}
		}
	}
	if (clr) result.push('1');
	else result.push('0');
	return;
}

int main() {
	int N;
	char str[65];

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%s", str, N+1);
		for (int j = 0; j < N; j++) {
			if (str[j] == '0') D[i][j] = 0;
			else D[i][j] = 1;
		}
	}

	QuadTree(N, 0, 0);

	while (!result.empty())
	{
		printf("%c", result.front());
		result.pop();
	}

	return 0;
}
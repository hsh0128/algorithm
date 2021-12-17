/*
* 문제의 풀이방법
* 1. 인오더와 포스트오더를 바탕으로 원래 트리를 생성한다
* 2. 이렇게 생성된 트리로 프리오더 배열을 생성한다
* 3. 이 프리오더를 출력한다
* 
* 트리의 생성방법
* 1. 포스트오더 배열에서 트리의 마지막 값을 구하고, 이를 트리노드에 연결한다
* 2. 인오더 배열에서 그 루트값을 찾는다
* 3.
* 
* 트리를 생성할 필요가 없을듯?
* 왜냐하면 코드의 구조상 root를 찾고 내려가는 코드라
* 그냥 계속 queue에 root값을 계속 넘겨주면 답이 나올듯
* 
* 이게 시간초과? inOrderindex부터 탐색을 하는데 1번부터 찾을 이유가 없다
* inOrderFirstindex부터 찾아보기!
*/

#include <stdio.h>
#include <queue>

using namespace std;

// 1부터 n까지의 인덱스를 가짐
int inOrder[100001];
int postOrder[100001];

queue<int> preOrder;
int n;

// shiftVal은 인오더와 포스트오더를 보정해주기 위한 값(오른쪽 트리를 탈 때마다 1씩 증가)
void makeTree(int inOrderFirstIndex, int shiftVal, int length) {
	if (length == 1) {
		preOrder.push(postOrder[inOrderFirstIndex + length - 1 - shiftVal]);
	}
	else if (length > 1) {
		preOrder.push(postOrder[inOrderFirstIndex + length - 1 - shiftVal]);
		for (int i = inOrderFirstIndex; i <= n; i++) {
			// i는 inOrder에서 찾은 root의 위치임
			if (inOrder[i] == postOrder[inOrderFirstIndex + length - 1 - shiftVal]) {
				// 왼쪽에 있는 트리
				makeTree(inOrderFirstIndex, shiftVal, i - inOrderFirstIndex);
				// 오른쪽에 있는 트리
				makeTree(inOrderFirstIndex + i - inOrderFirstIndex + 1, shiftVal + 1, length - i + inOrderFirstIndex - 1);
			}
		}
	}
}

int main() {

	scanf_s("%d", &n);

	for (int i = 1; i <= n; i++) {
		scanf_s("%d", &inOrder[i]);
	}

	for (int i = 1; i <= n; i++) {
		scanf_s("%d", &postOrder[i]);
	}

	// n번째 postOrder는 항상 최상위 root를 가짐
	makeTree(1, 0, n);

	while (!preOrder.empty()) {
		printf("%d ", preOrder.front());
		preOrder.pop();
	}

	return 0;
}
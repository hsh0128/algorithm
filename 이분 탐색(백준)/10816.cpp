/*
* 직접 이진트리를 포인터와 구조체로 구현하여 문제를 풀었는데 시간 초과가 뜸
* (오름차순으로 정렬된 값을 줄경우 시간 초과가 발생할듯, 최악의 경우니까)
* 그래서 STL에 이진 트리가 구현된 경우를 찾아서 문제를 풀어볼까 함
* 원래 써놓은 코드는 혹시 모르니 저장해 놓아야겠다
* 
* 그래서 STL container 중 뭘 써야 문제가 풀릴까?
* pair로 값을 저장해야 하니(card값과 그 숫자) map이라는 container를 사용할 것이다
* 혹시 모르니 구현해둔 코드를 밑에 적어놓았따

#include <stdio.h>
#include <queue>

using namespace std;

struct Node {
	int Value, count;
	Node* left, * right;
};

queue<int> result;
Node* root{0};

void makeTree(int input) {
	// root가 없을 경우
	if (!root) {
		Node *node = new Node();
		node->Value = input;
		node->count = 1;
		node->left = 0;
		node->right = 0;
		root = node;
	}
	else {
		Node* nowNode;
		nowNode = root;
		while (1) {
			// 현재 노드가 비어있을 경우 함수 리턴
			if (!nowNode) return;

			// 노드보다 입력값이 작은 경우(왼쪽)
			if (nowNode->Value > input) {
				// 왼쪽 노드가 있을경우
				if (nowNode->left) {
					nowNode = nowNode->left;
				}
				else {
					Node *addNode = new Node();
					addNode->Value = input;
					addNode->count = 1;
					addNode->left = 0;
					addNode->right = 0;
					nowNode->left = addNode;
					break;
				}
			}
			// 노드보다 입력값이 큰 경우(오른쪽)
			else if (nowNode->Value < input) {
				// 오른쪽 노드가 있을경우
				if (nowNode->right) {
					nowNode = nowNode->right;
				}
				else {
					Node* addNode = new Node();
					addNode->Value = input;
					addNode->count = 1;
					addNode->left = 0;
					addNode->right = 0;
					nowNode->right = addNode;
					break;
				}
			}
			// 노드와 입력값이 같은 경우(count 증가)
			else {
				nowNode->count += 1;
				break;
			}
		}
	}
}

int searchTree(int foundVal, Node* nowNode) {
	if (!nowNode) return 0;
	if (nowNode->Value > foundVal) return searchTree(foundVal, nowNode->left);
	else if (nowNode->Value < foundVal) return searchTree(foundVal, nowNode->right);
	else return nowNode->count;
}

int main() {
	int N, M, cache;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);
		makeTree(cache);
	}

	scanf_s("%d", &M);

	for (int i = 0; i < M; i++) {
		scanf_s("%d", &cache);
		result.push(searchTree(cache, root));
	}

	while (!result.empty()) {
		printf("%d ", result.front());
		result.pop();
	}

	return 0;
} */

// 여기서부터 진짜 문제를 푼 코드

#include <stdio.h>
#include <map>
#include <queue>

using namespace std;

map<int, int> cards;
queue<int> result;

int main() {
	int N, M, cache;

	scanf_s("%d", &N);

	for (int i = 0; i < N; i++) {
		scanf_s("%d", &cache);
		if (cards.find(cache) == cards.end()) {
			cards.insert(pair<int, int>(cache, 1));
		}
		else {
			cards[cache] += 1;
		}
	}

	scanf_s("%d", &M);

	for (int i = 0; i < M; i++) {
		scanf_s("%d", &cache);
		if (cards.find(cache) == cards.end()) {
			result.push(0);
		}
		else {
			result.push(cards[cache]);
		}
	}


	while (!result.empty()) {
		printf("%d ", result.front());
		result.pop();
	}

	return 0;
}
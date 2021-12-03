#include <stdio.h>

int main() {
	int A, B, C, BP = -1;
	
	scanf_s("%d %d %d", &A, &B, &C);

	// A < (C - B) * BP => A / (C - B) < BP
	// A가 0인 경우 항상 나머지가 0
	// 식 이후에 무조건 더해져야 함
	if ((C - B) > 0) {
		BP = A / (C - B);
		BP += 1;
	}
	else {
		BP = -1;
	}

	printf("%d", BP);

	return 0;
}
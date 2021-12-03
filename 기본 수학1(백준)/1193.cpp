#include <stdio.h>

int main() {
	int X, sum, front = 1, back = 1;
	bool frontToBack = true;
	scanf_s("%d", &X);

	while (X > 1) {
		if (frontToBack) {
			if (front == 1) {
				frontToBack = false;
			}
			else {
				front--;
			}
			back++;
		}
		else {
			if (back == 1) {
				frontToBack = true;
			}
			else {
				back--;
			}
			front++;
		}

		X--;
	}


	printf("%d/%d", front, back);

	return 0;
}
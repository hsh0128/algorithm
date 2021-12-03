#include <stdio.h>

int main() {
	int A, B, V, res;

	scanf_s("%d %d %d", &A, &B, &V);

	res = (V - A) / (A - B);
	if ((V - A) % (A - B)) res++;

	res++;

	printf("%d", res);

	return 0;
}
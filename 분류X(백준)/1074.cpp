#include <stdio.h>
#include <math.h>

int main() {
	int N, r, c, answer = 0, length, size;

	scanf_s("%d %d %d", &N, &r, &c);
	r++;
	c++;

	length = (int)pow(2, N);
	size = (int)pow(4, N);

	while (length > 1) {
		if (r > length / 2) {
			r -= length / 2;
			answer += size / 2;
		}

		if (c > length / 2) {
			c -= length / 2;
			answer += size / 4;
		}
		length /= 2;
		size /= 4;
	}

	printf("%d", answer);

	return 0;
}
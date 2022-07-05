#include <stdio.h>
#include <algorithm>

using namespace std;

int countTwo = 0;
int countFive = 0;

int countOfZero(int now, int max) {
	if (now > max) {
		return min(countTwo, countFive);
	}

	int tempNow = now;

	while (tempNow % 2 == 0) {
		tempNow /= 2;
		countTwo++;
	}

	while (tempNow % 5 == 0) {
		tempNow /= 5;
		countFive++;
	}

	return countOfZero(now + 1, max);
}

int main() {
	int N, answer;

	scanf_s("%d", &N);

	answer = countOfZero(2, N);

	printf("%d", answer);

	return 0;
}
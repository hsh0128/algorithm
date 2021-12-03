/* 
* 소소한 팁
* 메모이제이션을 쓸 때 오버플로우가 발생할 경우(가령 아래 D 배열에서 크기를 1,000,000으로 하고
* D[1,000,000]에 접근해서 오버플로우가 발생할 경우) 컴파일 에러가 뜨지 않고 틀렸다고 뜬다!
* 항상 유의할 것
* 
* + 모듈러 연산은 합연산만 나오는 경우 나올때마다 모듈라를 적용하면 잘 계산된다
*/

#include <stdio.h>

int D[1000005] = { 0, };

int count(int n) {
	if (n < 0) return 0;
	if (n == 0) return 1;
	if (n == 1) return 1;
	if (D[n] != 0) return D[n];
	else {
		D[n] = ((count(n - 1) % 15746) + (count(n - 2) % 15746)) % 15746;
		return D[n];
	}
}

int main() {
	int N;

	scanf_s("%d", &N);

	printf("%d", count(N));

	return 0;
}
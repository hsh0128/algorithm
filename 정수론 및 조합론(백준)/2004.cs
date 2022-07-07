int calculateTwoFactor(int n) {
    int cnt = 0;

    while(n % 2 == 0) {
        cnt += 1;
        n /= 2;
    }

    return cnt;
}

int calculateFiveFactor(int n) {
    int cnt = 0;

    while (n % 5 == 0) {
        cnt += 1;
        n /= 5;
    }

    return cnt;
}

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

if (M > N / 2) {
    M = N - M;
}

int countOfTwo = 0, countOfFive = 0;

int cnt = M / 2;

for (int i = 1; i <= cnt; i++) {
    countOfTwo -= calculateTwoFactor(i * 2);
}

cnt = M / 5;

for (int i = 1; i <= cnt; i++) {
    countOfFive -= calculateFiveFactor(i * 5);
}

int start = N / 5;
int end = (N - M) / 5;

for (int i = start; i > end; i--) {
    countOfFive += calculateFiveFactor(i * 5);
}

start = N / 2;
end = (N - M) / 2;

for (int i = start; i > end; i--) {
    countOfTwo += calculateTwoFactor(i * 2);
}

Console.WriteLine(Math.Min(countOfTwo, countOfFive));
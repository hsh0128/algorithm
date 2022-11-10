const long X = 1000000007;

long power(long a, long b) {
    if (b == 0) return 1;
    if (b == 1) return a;
    if (b == 2) return (a * a) % X;

    if (b % 2 == 0) return power(power(a, b / 2), 2);
    else return (a * power(a, b - 1)) % X;
}

long Converter(long n, long s) {
    long invertN = power(n, X - 2);

    long ret = ((invertN % X) * (s % X)) % X;

    return ret;
}

int M = int.Parse(Console.ReadLine());

long N, S;

long answer = 0, cache;

for (int i = 0; i < M; i++) {
    string[] inputs = Console.ReadLine().Split(' ');

    N = long.Parse(inputs[0]);
    S = long.Parse(inputs[1]);

    cache = Converter(N, S);
    answer += cache;
    answer %= X;
}

Console.WriteLine(answer);
int L = int.Parse(Console.ReadLine());

string input = Console.ReadLine();

long answer = 0, M = 1234567891, r = 31, a;

long pow(long low, long high) {
    if (high == 0) {
        return 1;
    }
    if (high == 1) {
        return low;
    }
    return ((pow(low, high - 1) % M) * low) % M;
}

for (int i = 0; i < L; i++) {
    a = (long)(input[i] - 96);

    a *= pow(r, (long)i);
    a %= M;

    answer += a;
    answer %= M;
}

Console.WriteLine(answer);
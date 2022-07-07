int[,] D = new int[1001,1001];

int Combination(int N, int K) {
    if (N == K || K == 0) {
        return 1;
    }

    if (D[N, K] == 0) {
        D[N, K] = (Combination(N - 1, K) % 10007 + Combination(N - 1, K - 1) % 10007) % 10007;
    }

    return D[N, K];
}

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int k = int.Parse(inputs[1]);

Console.WriteLine(Combination(N, k));
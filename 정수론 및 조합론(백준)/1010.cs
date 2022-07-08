using System.Text;

int[,] D = new int[31,31];

int Combination(int N, int K) {
    if (N == K || K == 0) {
        return 1;
    }

    if (D[N, K] == 0) {
        D[N, K] = Combination(N - 1, K) + Combination(N - 1, K - 1);
    }

    return D[N, K];
}

int T = int.Parse(Console.ReadLine());

StringBuilder sb = new StringBuilder();

int N, M;

for (int i = 0; i < T; i++) {
    string[] inputs = Console.ReadLine().Split(' ');

    N = int.Parse(inputs[0]);
    M = int.Parse(inputs[1]);

    sb.AppendLine(Combination(M, N).ToString());
}

Console.Write(sb);
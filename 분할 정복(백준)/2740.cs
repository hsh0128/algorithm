using System.Text;

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

int[,] A = new int[N,M];

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < M; j++) {
        A[i,j] = int.Parse(inputs[j]);
    }
}

inputs = Console.ReadLine().Split(' ');

int K = int.Parse(inputs[1]);

int[,] B = new int[M,K];

for (int i = 0; i < M; i++) {
    inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < K; j++) {
        B[i,j] = int.Parse(inputs[j]);
    }
}

StringBuilder sb = new StringBuilder();

int cache;

for (int i = 0; i < N; i++) {
    for (int j = 0; j < K; j++) {
        cache = 0;

        for (int k = 0; k < M; k++) {
            cache += A[i, k] * B[k, j];
        }

        sb.Append(cache.ToString());
        if (j != K - 1) sb.Append(' ');
        else sb.Append('\n');
    }
}

Console.Write(sb);
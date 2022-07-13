using System.Text;

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
long B = long.Parse(inputs[1]);

int[,] A = new int[N,N];

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < N; j++) {
        A[i,j] = int.Parse(inputs[j]);
    }
}

int[,] MatMul(int[,] Amat, int[,] Bmat) {
    int[,] cacheMat = new int[N,N];

    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
            int cache = 0;

            for (int k = 0; k < N; k++) {
                cache += (Amat[i, k] * Bmat[k, j]) % 1000;
                cache %= 1000;
            }

            cacheMat[i,j] = cache;
        }
    }

    return cacheMat;
}

int[,] CalcuateMat(long current) {
    if (current == 1) {
        return A;
    }

    if (current % 2 == 0) {
        int[,] half = CalcuateMat(current / 2);
        return MatMul(half, half);
    }

    return MatMul(A, CalcuateMat(current - 1));
}

int[,] result = CalcuateMat(B);

StringBuilder sb = new StringBuilder();

for (int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
        sb.Append(result[i,j] % 1000);

        if (j != N - 1) sb.Append(' ');
        else sb.Append('\n');
    }
}

Console.Write(sb);
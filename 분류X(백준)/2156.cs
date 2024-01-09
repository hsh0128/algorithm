StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

int[] wine = new int[N];

for (int i = 0; i < N; i++) {
    wine[i] = int.Parse(sr.ReadLine());
}

if (N == 1) {
    sw.WriteLine(wine[0]);
} else if (N == 2) {
    sw.WriteLine(wine[0] + wine[1]);
} else {
    int[,] D = new int[N, 3];

    D[0, 0] = 0;
    D[0, 1] = wine[0];
    D[0, 2] = wine[0];

    D[1, 0] = wine[0];
    D[1, 1] = wine[1];
    D[1, 2] = wine[1] + wine[0];

    for (int i = 2; i < N; i++) {
        D[i, 0] = Math.Max(D[i - 1, 0], Math.Max(D[i - 1, 1], D[i - 1, 2]));
        D[i, 1] = D[i - 1, 0] + wine[i];
        D[i, 2] = D[i - 1, 1] + wine[i];
    }

    int answer = Math.Max(D[N - 1, 0], Math.Max(D[N - 1, 1], D[N - 1, 2]));

    sw.WriteLine(answer);
}

sr.Close();
sw.Close();
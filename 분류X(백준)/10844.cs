StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int DIVIDER = 1000000000;

int N = int.Parse(sr.ReadLine());

int[,] D = new int[10, N + 1];

D[0, 1] = 0;

for (int i = 1; i < 10; i++) {
    D[i, 1] = 1;
}

for (int i = 2; i <= N; i++) {
    for (int j = 0; j < 10; j++) {
        if (j > 0) {
            D[j, i] += D[j - 1, i - 1];
            D[j, i] %= DIVIDER;
        }
        if (j < 9) {
            D[j, i] += D[j + 1, i - 1];
            D[j, i] %= DIVIDER;
        }
    }
}

int answer = 0;

for (int i = 0; i < 10; i++) {
    answer += D[i, N];
    answer %= DIVIDER;
}

sw.WriteLine(answer);

sr.Close();
sw.Close();
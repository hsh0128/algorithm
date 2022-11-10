StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int E = int.Parse(inputs[1]);

int[,] D = new int[N,N];
int start, dest, len;

for (int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
        if (i == j) D[i, j] = 0;
        else D[i, j] = 9999999;
    }
}

for (int i = 0; i < E; i++) {
    inputs = sr.ReadLine().Split(' ');

    start = int.Parse(inputs[0]) - 1;
    dest = int.Parse(inputs[1]) - 1;
    len = int.Parse(inputs[2]);

    D[start, dest] = len;
    D[dest, start] = len;
}

for (int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
        for (int k = 0; k < N; k++) {
            if (i == j || j == k || i == k) continue;

            if (D[j, k] > D[j, i] + D[i, k]) {
                D[j, k] = D[j, i] + D[i, k];
            }
        }
    }
}

inputs = sr.ReadLine().Split(' ');

int v1 = int.Parse(inputs[0]) - 1;
int v2 = int.Parse(inputs[1]) - 1;

int answer1 = D[0, v1] + D[v1, v2] + D[v2, N - 1];
int answer2 = D[0, v2] + D[v2, v1] + D[v1, N - 1];

int answer = Math.Min(answer1, answer2);

if (answer >= 9999999) answer = -1;

sw.WriteLine(answer);

sr.Close();
sw.Close();
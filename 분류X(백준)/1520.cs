StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int M = int.Parse(inputs[0]);
int N = int.Parse(inputs[1]);

int[,] map = new int[M,N];
int[,] D = new int[M, N];

for (int i = 0; i < M; i++) {
    inputs = sr.ReadLine().Split(' ');

    for (int j = 0; j < N; j++) {
        map[i, j] = int.Parse(inputs[j]);
        D[i, j] = -1;
    }
}

int Search(int x, int y) {
    if (x == M - 1 && y == N - 1) return 1;

    if (D[x, y] != -1) return D[x, y];

    int ret = 0;

    if (x > 0 && map[x - 1, y] < map[x, y]) ret += Search(x - 1, y);
    if (y > 0 && map[x, y - 1] < map[x, y]) ret += Search(x, y - 1);
    if (x < M - 1 && map[x + 1, y] < map[x, y]) ret += Search(x + 1, y);
    if (y < N - 1 && map[x, y + 1] < map[x, y]) ret += Search(x, y + 1);

    D[x, y] = ret;

    return ret;
}

sw.WriteLine(Search(0, 0));

sr.Close();
sw.Close();
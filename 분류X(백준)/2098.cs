StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

int maxVal = 1 << N;
int maxLen = 1000000 * (N + 1);

int[,,] D = new int[maxVal, N, N];
int[,] W = new int[N, N];

string[] inputs;

for (int i = 0; i < N; i++) {
    inputs = sr.ReadLine().Split(' ');
    for (int j = 0; j < N; j++) {
        W[i, j] = int.Parse(inputs[j]);
    }
}

int Search(int searched, int start, int nowEnd) {
    if (D[searched, start, nowEnd] != 0) return D[searched, start, nowEnd];
    if (searched == maxVal - 1) {
        if (W[nowEnd, start] == 0) return maxLen;
        else return W[nowEnd, start];
    }

    int min = int.MaxValue, cache;

    for (int i = 0; i < N; i++) {
        if (W[nowEnd, i] == 0) continue;
        if ((searched & (1 << i)) != 0) continue;

        cache = W[nowEnd, i] + Search(searched | (1 << i), start, i);

        if (cache < min) min = cache;
    }

    if (min == int.MaxValue) D[searched, start, nowEnd] = maxLen;
    else D[searched, start, nowEnd] = min;
    
    return D[searched, start, nowEnd];
}

int answer = Search(1, 0, 0);

sw.WriteLine(answer);

sr.Close();
sw.Close();
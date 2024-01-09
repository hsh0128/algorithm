StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

long T = long.Parse(sr.ReadLine());


int N = int.Parse(sr.ReadLine());

long[] SA = new long[N + 1];
long nowSum = 0;

string[] inputs = sr.ReadLine().Split(' ');

for (int i = 0; i < N; i++) {
    SA[i] = nowSum;

    nowSum += long.Parse(inputs[i]);
}
SA[N] = nowSum;


int M = int.Parse(sr.ReadLine());

long[] SB = new long[M + 1];
nowSum = 0;

inputs = sr.ReadLine().Split(' ');

for (int i = 0; i < M; i++) {
    SB[i] = nowSum;
    
    nowSum += long.Parse(inputs[i]);
}
SB[M] = nowSum;


Dictionary<long, int> D = new Dictionary<long, int>();
long cache;

for (int i = 0; i <= N - 1; i++) {
    for (int j = i + 1; j <= N; j++) {
        cache = SA[j] - SA[i];

        if (D.ContainsKey(cache)) {
            D[cache] += 1;
            continue;
        }

        D.Add(cache, 1);
    }
}

long answer = 0;

for (int i = 0; i <= M - 1; i++) {
    for (int j = i + 1; j <= M; j++) {
        cache = SB[j] - SB[i];
        cache = T - cache;

        if (D.ContainsKey(cache)) {
            answer += D[cache];
        }
    }
}

sw.WriteLine(answer);

sr.Close();
sw.Close();
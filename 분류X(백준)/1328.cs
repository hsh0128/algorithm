string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);
int X = int.Parse(inputs[2]) - 1;

int[,] distances = new int[N,N];

int startIdx, endIdx, length;

for (int i = 0; i < M; i++) {
    inputs = Console.ReadLine().Split(' ');

    startIdx = int.Parse(inputs[0]) - 1;
    endIdx = int.Parse(inputs[1]) - 1;
    length = int.Parse(inputs[2]);

    distances[startIdx, endIdx] = length;
}

for (int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
        for (int k = 0; k < N; k++) {
            if (j == k || i == j || i == k) continue;

            if (distances[j, i] == 0 || distances[i, k] == 0)
                continue;

            if (distances[j, k] == 0) {
                distances[j, k] = distances[j, i] + distances[i, k];
                continue;
            }

            if (distances[j, k] > distances[j, i] + distances[i, k])
                distances[j, k] = distances[j, i] + distances[i, k];
        }
    }
}

int answer = -1, cache;

for (int i = 0; i < N; i++) {
    cache = distances[i, X] + distances[X, i];

    if (cache > answer) answer = cache;
}

Console.WriteLine(answer);
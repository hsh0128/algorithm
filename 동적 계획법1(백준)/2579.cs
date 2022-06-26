List<int> scores = new List<int>();
int[,] D = new int[300, 2];

int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++) {
    scores.Add(int.Parse(Console.ReadLine()));
}

D[0, 0] = scores[0];

if (N > 1) {
    D[1, 0] = scores[1];
    D[1, 1] = scores[0] + scores[1];
}

for (int i = 2; i < N; i++) {
    D[i, 0] = Math.Max(D[i-2, 0], D[i-2, 1]) +scores[i];
    D[i, 1] = D[i-1, 0] + scores[i];
}

int answer = Math.Max(D[N-1, 0], D[N-1, 1]);

Console.WriteLine(answer);
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

int[,] cost = new int[N, 3];
string[] inputs;

for (int i = 0; i < N; i++) {
    inputs = sr.ReadLine().Split(' ');

    cost[i, 0] = int.Parse(inputs[0]);
    cost[i, 1] = int.Parse(inputs[1]);
    cost[i, 2] = int.Parse(inputs[2]);
}

int[,] R = new int[N, 3];
int[,] G = new int[N, 3];
int[,] B = new int[N, 3];

R[1, 0] = 9999999;
R[1, 1] = cost[0, 0] + cost[1, 1];
R[1, 2] = cost[0, 0] + cost[1, 2];

G[1, 0] = cost[0, 1] + cost[1, 0];
G[1, 1] = 9999999;
G[1, 2] = cost[0, 1] + cost[1, 2];

B[1, 0] = cost[0, 2] + cost[1, 0];
B[1, 1] = cost[0, 2] + cost[1, 1];
B[1, 2] = 9999999;

for (int i = 2; i < N; i++) {
    R[i, 0] = Math.Min(R[i - 1, 1], R[i - 1, 2]) + cost[i, 0];
    R[i, 1] = Math.Min(R[i - 1, 0], R[i - 1, 2]) + cost[i, 1];
    R[i, 2] = Math.Min(R[i - 1, 0], R[i - 1, 1]) + cost[i, 2];

    G[i, 0] = Math.Min(G[i - 1, 1], G[i - 1, 2]) + cost[i, 0];
    G[i, 1] = Math.Min(G[i - 1, 0], G[i - 1, 2]) + cost[i, 1];
    G[i, 2] = Math.Min(G[i - 1, 0], G[i - 1, 1]) + cost[i, 2];

    B[i, 0] = Math.Min(B[i - 1, 1], B[i - 1, 2]) + cost[i, 0];
    B[i, 1] = Math.Min(B[i - 1, 0], B[i - 1, 2]) + cost[i, 1];
    B[i, 2] = Math.Min(B[i - 1, 0], B[i - 1, 1]) + cost[i, 2];
}

int red = Math.Min(R[N - 1, 1], R[N - 1, 2]);
int green = Math.Min(G[N - 1, 0], G[N - 1, 2]);
int blue = Math.Min(B[N - 1, 0], B[N - 1, 1]);

int answer = Math.Min(red, Math.Min(green, blue));

sw.WriteLine(answer);

sr.Close();
sw.Close();
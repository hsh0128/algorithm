StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int V = int.Parse(inputs[0]);
int E = int.Parse(inputs[1]);

int[,] D = new int[V,V];

int a, b, c;

for (int i = 0; i < E; i++) {
    inputs = sr.ReadLine().Split(' ');

    a = int.Parse(inputs[0]) - 1;
    b = int.Parse(inputs[1]) - 1;
    c = int.Parse(inputs[2]);

    D[a, b] = c;
}

for (int i = 0; i < V; i++) {
    for (int j = 0; j < V; j++) {
        for (int k = 0; k < V; k++) {
            if (D[j, i] == 0) continue;
            if (D[i, k] == 0) continue;

            if (D[j, k] == 0) D[j, k] = D[j, i] + D[i, k];

            if (D[j, k] > D[j, i] + D[i, k]) D[j, k] = D[j, i] + D[i, k];
        }
    }
}

int answer = -1;

for (int i = 0; i < V; i++) {
    if (D[i, i] == 0) continue;

    if (answer == -1 || D[i, i] < answer) answer = D[i, i];
}

sw.WriteLine(answer);

sr.Close();
sw.Close();
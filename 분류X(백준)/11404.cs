using System.Text;

int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

int[,] D = new int[n,n];
string[] inputs;
int origin, dest, length;

for (int i = 0; i < m; i++) {
    inputs = Console.ReadLine().Split(' ');
    origin = int.Parse(inputs[0]) - 1;
    dest = int.Parse(inputs[1]) - 1;
    length = int.Parse(inputs[2]);

    if (D[origin, dest] != 0 && D[origin, dest] < length) continue;
    
    D[origin, dest] = length;
}

for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
        for (int k = 0; k < n; k++) {
            if (j == k || i == j || i == k) continue;
            if (D[j, i] == 0) continue;
            if (D[i, k] == 0) continue;

            if (D[j, k] == 0 || D[j, k] > D[j, i] + D[i, k]) {
                D[j, k] = D[j, i] + D[i, k];
            }
        }
    }
}

StringBuilder sb = new StringBuilder();

for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
        sb.Append(D[i, j].ToString());
        if (j == n - 1) sb.Append('\n');
        else sb.Append(' ');
    }
}

Console.Write(sb);
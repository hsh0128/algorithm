string[] inputs = Console.ReadLine().Split(' ');

int n = int.Parse(inputs[0]);
int m = int.Parse(inputs[1]);
int r = int.Parse(inputs[2]);

inputs = Console.ReadLine().Split(' ');
int[] t = new int[n];

for (int i = 0; i < n; i++) {
    t[i] = int.Parse(inputs[i]);
}

int first, second, value;
int[,] D = new int[n,n];

for (int i = 0; i < r; i++) {
    inputs = Console.ReadLine().Split(' ');

    first = int.Parse(inputs[0]) - 1;
    second = int.Parse(inputs[1]) - 1;
    value = int.Parse(inputs[2]);

    D[first, second] = value;
    D[second, first] = value;
}

for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
        for (int k = 0; k < n; k++) {
            if (i == j) continue;
            if (j == k) continue;
            if (i == k) continue;

            if (D[j, i] == 0) continue;
            if (D[i, k] == 0) continue;

            if (D[j, k] == 0 || D[j, k] > D[j, i] + D[i, k]) {
                D[j, k] = D[j, i] + D[i, k];
                D[k, j] = D[j, i] + D[i, k];
            }
        }
    }
}

int answer = 0;
int temp;

for (int i = 0; i < n; i++) {
    temp = 0;

    for (int j = 0; j < n; j++) {
        if (i == j || (D[i, j] != 0 && D[i, j] <= m)) temp += t[j];
    }
    
    if (temp > answer) answer = temp;
}

Console.WriteLine(answer);
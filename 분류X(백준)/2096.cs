int N = int.Parse(Console.ReadLine());

string[] inputs;
int[,] numbers = new int[3,N];

int[,] minimums = new int[3, N];
int[,] maximums = new int[3, N];

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < 3; j++) {
        numbers[j, i] = int.Parse(inputs[j]);
    }
}

for (int i = 0; i < 3; i++) {
    minimums[i, 0] = numbers[i, 0];
    maximums[i, 0] = numbers[i, 0];
}

for (int i = 1; i < N; i++) {
    minimums[0, i] = numbers[0, i] + Math.Min(minimums[0, i - 1], minimums[1, i - 1]);
    minimums[2, i] = numbers[2, i] + Math.Min(minimums[2, i - 1], minimums[1, i - 1]);
    minimums[1, i] = numbers[1, i] + Math.Min(Math.Min(minimums[0, i - 1], minimums[1, i - 1]), minimums[2, i - 1]);

    maximums[0, i] = numbers[0, i] + Math.Max(maximums[0, i - 1], maximums[1, i - 1]);
    maximums[2, i] = numbers[2, i] + Math.Max(maximums[2, i - 1], maximums[1, i - 1]);
    maximums[1, i] = numbers[1, i] + Math.Max(Math.Max(maximums[0, i - 1], maximums[1, i - 1]), maximums[2, i - 1]);
}

int min = Math.Min(Math.Min(minimums[0, N - 1], minimums[1, N - 1]), minimums[2, N - 1]);
int max = Math.Max(Math.Max(maximums[0, N- 1], maximums[1, N - 1]), maximums[2, N - 1]);

Console.WriteLine(max.ToString() + " " + min.ToString());
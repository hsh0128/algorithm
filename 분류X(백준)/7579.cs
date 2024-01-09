StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

inputs = sr.ReadLine().Split(' ');

List<int> memory = new List<int>();
List<int> cost = new List<int>();

for (int i = 0; i < N; i++) {
    memory.Add(int.Parse(inputs[i]));
}

inputs = sr.ReadLine().Split(' ');
int maxCost = 0, nowCost;

for (int i = 0; i < N; i++) {
    nowCost = int.Parse(inputs[i]);

    cost.Add(nowCost);
    maxCost += nowCost;
}

int[,] D = new int[N + 1, maxCost + 1];
int answer = int.MaxValue;

int nowShiftCost, nowShiftMemory;

for (int i = 1; i <= N; i++) {
    nowShiftCost = cost[i - 1];
    nowShiftMemory = memory[i - 1];

    for (int j = 0; j <= maxCost; j++) {
        if (j - nowShiftCost < 0) {
            D[i, j] = D[i - 1, j];
            continue;
        }

        if (D[i - 1, j] < D[i - 1, j - nowShiftCost] + nowShiftMemory) {
            D[i, j] = D[i - 1, j - nowShiftCost] + nowShiftMemory;

            if (D[i, j] >= M && j < answer) answer = j;
        } else {
            D[i, j] = D[i - 1, j];
        }
    }
}

sw.WriteLine(answer);

sr.Close();
sw.Close();
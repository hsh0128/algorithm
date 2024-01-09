StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());
List<KeyValuePair<int, int>> matrices = new List<KeyValuePair<int, int>>();
int first, second;
string[] inputs;

for (int i = 0; i < N; i++) {
    inputs = sr.ReadLine().Split(' ');

    first = int.Parse(inputs[0]);
    second = int.Parse(inputs[1]);

    matrices.Add(new KeyValuePair<int, int>(first, second));
}

int[,] D = new int[N, N];

for (int i = 0; i < N - 1; i++) {
    D[i, i + 1] = matrices[i].Key * matrices[i].Value * matrices[i + 1].Value;
}

for (int delta = 2; delta < N; delta++) {
    for (int i = 0; i < N - delta; i++) {
        int val = int.MaxValue, cache;

        for (int center = i; center < i + delta; center++) {
            cache = D[i, center] + D[center + 1, i + delta] + matrices[i].Key * matrices[center].Value * matrices[i + delta].Value;

            if (cache < val) val = cache;
        }

        D[i, i + delta] = val;
    }
}

sw.WriteLine(D[0, N - 1]);

sr.Close();
sw.Close();
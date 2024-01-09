StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int T = int.Parse(sr.ReadLine());
string[] inputs;

for (int i = 0; i < T; i++) {
    int K = int.Parse(sr.ReadLine());

    int[,] cost = new int[K, K];
    int[,] D = new int[K, K];

    inputs = sr.ReadLine().Split(' ');

    for (int j = 0; j < K; j++) {
        cost[j, j] = int.Parse(inputs[j]);
        
        for (int l = 0; l < j; l++) {
            cost[l, j] = cost[l, j - 1] + cost[j, j];
        }
    }

    for (int j = 0; j < K - 1; j++) {
        D[j, j + 1] = cost[j, j + 1];
    }

    for (int space = 2; space < K; space++) {
        for (int start = 0; start < K - space; start++) {
            int minCost = int.MaxValue;
            int localCost;

            for (int mid = start; mid < start + space; mid++) {
                localCost = D[start, mid] + D[mid + 1, start + space] + cost[start, mid] + cost[mid + 1, start + space];

                if (minCost > localCost) minCost = localCost;
            }

            D[start, start + space] = minCost;
        }
    }

    sw.WriteLine(D[0, K - 1]);
}

sr.Close();
sw.Close();
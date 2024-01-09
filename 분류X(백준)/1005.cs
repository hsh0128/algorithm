StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs;

int T = int.Parse(sr.ReadLine());

for (int i = 0; i < T; i++) {
    inputs = sr.ReadLine().Split(' ');

    int N = int.Parse(inputs[0]);
    int K = int.Parse(inputs[1]);

    int[] D = new int[N];
    int[] count = new int[N];
    int[] maxTime = new int[N];
    inputs = sr.ReadLine().Split(' ');

    for (int j = 0; j < N; j++) {
        D[j] = int.Parse(inputs[j]);
    }

    Dictionary<int, List<int>> connection = new Dictionary<int, List<int>>();

    int first, second;

    for (int j = 0; j < K; j++) {
        inputs = sr.ReadLine().Split(' ');

        first = int.Parse(inputs[0]) - 1;
        second = int.Parse(inputs[1]) - 1;

        if (!connection.ContainsKey(first)) connection.Add(first, new List<int>());

        connection[first].Add(second);
        count[second] += 1;
    }

    int W = int.Parse(sr.ReadLine()) - 1;

    Queue<int> nowSearch = new Queue<int>();

    for (int j = 0; j < N; j++) {
        if (count[j] == 0) nowSearch.Enqueue(j);
    }

    int nowVal;

    while(nowSearch.Count() > 0) {
        nowVal = nowSearch.Dequeue();

        if (nowVal == W) {
            sw.WriteLine(D[nowVal] + maxTime[nowVal]);
            break;
        }

        maxTime[nowVal] += D[nowVal];

        if (!connection.ContainsKey(nowVal)) continue;

        foreach(int j in connection[nowVal]) {
            count[j] -= 1;

            if (count[j] == 0) nowSearch.Enqueue(j);

            if (maxTime[j] < maxTime[nowVal]) maxTime[j] = maxTime[nowVal];
        }
    }
}

sr.Close();
sw.Close();
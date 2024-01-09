StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int K = int.Parse(sr.ReadLine());

for (int i = 0; i < K; i++) {
    string[] inputs = sr.ReadLine().Split(' ');

    int V = int.Parse(inputs[0]);
    int E = int.Parse(inputs[1]);

    bool[] searched = new bool[V];
    bool[] color = new bool[V];
    Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();

    for (int j = 0; j < V; j++) {
        edges.Add(j, new List<int>());
    }

    for (int j = 0; j < E; j++) {
        inputs = sr.ReadLine().Split(' ');

        int first = int.Parse(inputs[0]) - 1;
        int second = int.Parse(inputs[1]) - 1;

        edges[first].Add(second);
        edges[second].Add(first);
    }

    bool answer = true;

    void dfs(bool prevClr, int nowSearch) {
        if (!answer) return;

        if (searched[nowSearch]) {
            if (prevClr == color[nowSearch]) answer = false;

            return;
        }

        searched[nowSearch] = true;
        color[nowSearch] = !prevClr;

        foreach(int node in edges[nowSearch]) {
            dfs(!prevClr, node);
        }
    }

    for (int j = 0; j < V; j++) {
        if (searched[j]) continue;
        if (!answer) break;

        dfs(false, j);
    }

    if (answer) sw.WriteLine("YES");
    else sw.WriteLine("NO");
}

sr.Close();
sw.Close();
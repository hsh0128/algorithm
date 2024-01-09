using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
StringBuilder sb = new StringBuilder();

int T = int.Parse(sr.ReadLine());

for (int i = 0; i < T; i++) {
    string[] inputs = sr.ReadLine().Split(' ');
    
    int N = int.Parse(inputs[0]);
    int M = int.Parse(inputs[1]);
    int t = int.Parse(inputs[2]);

    inputs = sr.ReadLine().Split(' ');

    int S = int.Parse(inputs[0]);
    int G = int.Parse(inputs[1]);
    int H = int.Parse(inputs[2]);

    Dictionary<int, List<KeyValuePair<int, int>>> edges = new Dictionary<int, List<KeyValuePair<int, int>>>();
    SortedSet<int> candidates = new SortedSet<int>();

    for (int j = 0; j < M; j++) {
        inputs = sr.ReadLine().Split(' ');

        int a = int.Parse(inputs[0]);
        int b = int.Parse(inputs[1]);
        int d = int.Parse(inputs[2]) * 2;

        if (!edges.ContainsKey(a)) edges.Add(a, new List<KeyValuePair<int, int>>());
        if (!edges.ContainsKey(b)) edges.Add(b, new List<KeyValuePair<int, int>>());

        if ((a == G && b == H) || (a == H && b == G)) {
            d -= 1;
        }

        edges[a].Add(new KeyValuePair<int, int>(b, d));
        edges[b].Add(new KeyValuePair<int, int>(a, d));
    }
    
    for (int j = 0; j < t; j++) {
        candidates.Add(int.Parse(sr.ReadLine()));
    }

    bool[] visited = new bool[N + 1];
    int[] minLength = new int[N + 1];

    PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

    for (int j = 0; j <= N; j++) {
        minLength[j] = int.MaxValue / 2;
    }

    minLength[S] = 0;

    pq.Enqueue(S, 0);

    while(pq.Count > 0) {
        int now = pq.Dequeue();
        
        if (visited[now]) continue;

        visited[now] = true;

        foreach(KeyValuePair<int, int> tar in edges[now]) {
            if (minLength[tar.Key] > minLength[now] + tar.Value) {
                minLength[tar.Key] = minLength[now] + tar.Value;

                pq.Enqueue(tar.Key, minLength[tar.Key]);
            }
        }
    }

    foreach(int j in candidates) {
        if (minLength[j] != int.MaxValue / 2 && minLength[j] % 2 == 1) {
            sb.Append(j);
            sb.Append(' ');
        }
    }
    sb.Append('\n');
}

sw.Write(sb);

sr.Close();
sw.Close();
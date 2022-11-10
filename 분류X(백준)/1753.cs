StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

string[] inputs = sr.ReadLine().Split(' ');

int V = int.Parse(inputs[0]);
int E = int.Parse(inputs[1]);

Dictionary<int, int>[] edges = new Dictionary<int, int>[V];

for (int i = 0; i < V; i++) {
    edges[i] = new Dictionary<int, int>();
}

int K = int.Parse(sr.ReadLine()) - 1;

edges[K].Add(K, 0);

int u, v, w;

for (int i = 0; i < E; i++) {
    inputs = sr.ReadLine().Split(' ');

    u = int.Parse(inputs[0]) - 1;
    v = int.Parse(inputs[1]) - 1;
    w = int.Parse(inputs[2]);

    if (!edges[u].ContainsKey(v)) {
        edges[u].Add(v, w);
        continue;
    }

    if (edges[u][v] > w) {
        edges[u][v] = w;
    }
}

bool[] searched = new bool[V];
searched[K] = true;

PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

for (int i = 0; i < V; i++) {
    if (edges[K].ContainsKey(i)) {
        pq.Enqueue(i, edges[K][i]);
        continue;
    }

    edges[K].Add(i, 3000001);
}

int nowIdx, cache;

while(pq.Count > 0) {
    nowIdx = pq.Dequeue();

    if (searched[nowIdx]) continue;

    foreach(KeyValuePair<int, int> i in edges[nowIdx]) {
        cache = edges[K][nowIdx] + i.Value;

        if (edges[K][i.Key] > cache) {
            edges[K][i.Key] = cache;
            pq.Enqueue(i.Key, cache);
        }
    }

    searched[nowIdx] = true;
}

for (int i = 0; i < V; i++) {
    if (edges[K][i] == 3000001) sw.WriteLine("INF");
    else sw.WriteLine(edges[K][i]);
}

sr.Close();
sw.Close();
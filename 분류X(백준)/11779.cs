StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());
int M = int.Parse(sr.ReadLine());

Dictionary<int, int>[] edges = new Dictionary<int, int>[N];

string[] inputs;
int A, B, cost;

for (int i = 0; i < N; i++) {
    edges[i] = new Dictionary<int, int>();
}

for (int i = 0; i < M; i++) {
    inputs = sr.ReadLine().Split(' ');

    A = int.Parse(inputs[0]) - 1;
    B = int.Parse(inputs[1]) - 1;
    cost = int.Parse(inputs[2]);

    if (!edges[A].ContainsKey(B)) {
        edges[A].Add(B, cost);
        continue;
    }

    if (edges[A][B] > cost)
        edges[A][B] = cost;
}

inputs = sr.ReadLine().Split(' ');

int start = int.Parse(inputs[0]) - 1;
int dest = int.Parse(inputs[1]) - 1;

bool[] searched = new bool[N];
searched[start] = true;

PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
List<int>[] answerPath = new List<int>[N];

for (int i = 0; i < N; i++) {
    answerPath[i] = new List<int>();

    if (edges[start].ContainsKey(i)) {
        pq.Enqueue(i, edges[start][i]);
        continue;
    }

    edges[start].Add(i, 100000001);
}

int nowIdx, cache;

while(pq.Count > 0) {
    nowIdx = pq.Dequeue();

    if (searched[nowIdx]) continue;

    foreach (KeyValuePair<int, int> i in edges[nowIdx]) {
        cache = edges[start][nowIdx] + i.Value;

        if (edges[start][i.Key] > cache) {
            edges[start][i.Key] = cache;
            pq.Enqueue(i.Key, cache);

            answerPath[i.Key].Clear();

            foreach(int j in answerPath[nowIdx]) {
                answerPath[i.Key].Add(j);
            }

            answerPath[i.Key].Add(nowIdx);
        }
    }

    searched[nowIdx] = true;
}

sw.WriteLine(edges[start][dest]);

int len = answerPath[dest].Count();

sw.WriteLine(len + 2);

sw.Write(start + 1);
sw.Write(' ');
foreach(int i in answerPath[dest]) {
    sw.Write(i + 1);
    sw.Write(' ');
}
sw.Write(dest + 1);

sr.Close();
sw.Close();
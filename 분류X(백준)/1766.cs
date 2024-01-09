using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

int[] count = new int[N + 1];
Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();
int first, second;

for (int i = 0; i < M; i++) {
    inputs = sr.ReadLine().Split(' ');

    first = int.Parse(inputs[0]);
    second = int.Parse(inputs[1]);

    if (!edges.ContainsKey(first)) edges.Add(first, new List<int>());

    if (edges[first].Contains(second)) continue;

    edges[first].Add(second);
    count[second] += 1;
}

PriorityQueue<int, int> q = new PriorityQueue<int, int>();

for (int i = 1; i <= N; i++) {
    if (count[i] == 0) q.Enqueue(i, i);
}

StringBuilder sb = new StringBuilder();

while(q.Count > 0) {
    int nowIdx = q.Dequeue();

    if (sb.Length == 0) sb.Append(nowIdx).ToString();
    else sb.Append(" " + nowIdx.ToString());

    if (!edges.ContainsKey(nowIdx)) continue;

    foreach(int i in edges[nowIdx]) {
        count[i] -= 1;

        if (count[i] == 0) q.Enqueue(i, i);
    }
}

sw.Write(sb);

sr.Close();
sw.Close();
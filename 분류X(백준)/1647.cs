StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

int[] parent = new int[N];
int unique = N;
int answer = 0;
SortedDictionary<int, List<KeyValuePair<int, int>>> edges = new SortedDictionary<int, List<KeyValuePair<int, int>>>();
int A, B, C;
bool foundAnswer = false;

for (int i = 0; i < N; i++) {
    parent[i] = i;
}

for (int i = 0; i < M; i++) {
    inputs = sr.ReadLine().Split(' ');

    A = int.Parse(inputs[0]) - 1;
    B = int.Parse(inputs[1]) - 1;
    C = int.Parse(inputs[2]);

    if (!edges.ContainsKey(C)) edges.Add(C, new List<KeyValuePair<int, int>>());

    edges[C].Add(new KeyValuePair<int, int>(A, B));
}

Dictionary<int, List<int>> connection = new Dictionary<int, List<int>>();

void UpdateParent(int index, int value) {
    if (parent[index] == value) return;

    parent[index] = value;

    if (!connection.ContainsKey(index)) return;

    foreach(int i in connection[index]) {
        UpdateParent(i, value);
    }
}

foreach(KeyValuePair<int, List<KeyValuePair<int, int>>> i in edges) {
    if (foundAnswer) break;

    foreach(KeyValuePair<int, int> j in i.Value) {
        if (parent[j.Key] == parent[j.Value]) continue;

        answer += i.Key;
        unique -= 1;

        if (unique == 2) {
            foundAnswer = true;
            break;
        }

        if (parent[j.Key] > parent[j.Value]) UpdateParent(j.Key, parent[j.Value]);
        else UpdateParent(j.Value, parent[j.Key]);

        if (!connection.ContainsKey(j.Key)) connection.Add(j.Key, new List<int>());
        connection[j.Key].Add(j.Value);

        if (!connection.ContainsKey(j.Value)) connection.Add(j.Value, new List<int>());
        connection[j.Value].Add(j.Key);
    }
}

sw.WriteLine(answer);

sr.Close();
sw.Close();
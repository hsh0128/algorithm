StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs;
int n = int.Parse(sr.ReadLine());

KeyValuePair<float, float>[] stars = new KeyValuePair<float, float>[n];
SortedDictionary<float, List<KeyValuePair<int, int>>> edges = new SortedDictionary<float, List<KeyValuePair<int, int>>>();

float first, second, distance;

float Distance(KeyValuePair<float, float> pos1, KeyValuePair<float, float> pos2) {
    return MathF.Sqrt(MathF.Pow(pos1.Key - pos2.Key, 2) + MathF.Pow(pos1.Value - pos2.Value, 2));
}

for (int i = 0; i < n; i++) {
    inputs = sr.ReadLine().Split(' ');

    first = float.Parse(inputs[0]);
    second = float.Parse(inputs[1]);

    stars[i] = new KeyValuePair<float, float>(first, second);

    for (int j = 0; j < i; j++) {
        distance = Distance(stars[i], stars[j]);

        if (!edges.ContainsKey(distance)) edges.Add(distance, new List<KeyValuePair<int, int>>());

        edges[distance].Add(new KeyValuePair<int, int>(i, j));
    }
}

float answer = 0;
bool foundAnswer = false;
int count = n;
int[] parent = new int[n];
Dictionary<int, List<int>> connection = new Dictionary<int, List<int>>();

void UpdateParent(int index, int value) {
    if (parent[index] == value) return;

    parent[index] = value;

    if (!connection.ContainsKey(index)) return;

    foreach(int i in connection[index]) {
        UpdateParent(i, value);
    }
}

for (int i = 0; i < n; i++) {
    parent[i] = i;
}

foreach(KeyValuePair<float, List<KeyValuePair<int, int>>> i in edges) {
    if (foundAnswer) break;

    foreach(KeyValuePair<int, int> j in i.Value) {
        if (parent[j.Key] == parent[j.Value]) continue;

        answer += i.Key;
        count -= 1;

        if (count == 1) {
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

sw.WriteLine(answer.ToString("0.00"));

sr.Close();
sw.Close();
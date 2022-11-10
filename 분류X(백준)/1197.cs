StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int V = int.Parse(inputs[0]);
int E = int.Parse(inputs[1]);

List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();
int A, B, C;

for (int i = 0; i < E; i++) {
    inputs = sr.ReadLine().Split(' ');
    
    A = int.Parse(inputs[0]) - 1;
    B = int.Parse(inputs[1]) - 1;
    C = int.Parse(inputs[2]);

    edges.Add(new Tuple<int, int, int>(C, A, B));
}

int[] parent = new int[V];
Dictionary<int, List<int>> connection = new Dictionary<int, List<int>>();
int answer = 0;
int count = V;

for(int i = 0; i < V; i++) {
    parent[i] = i;
    connection.Add(i, new List<int>());
}

void UpdateParent(int index, int value) {
    if (parent[index] == value) return;

    parent[index] = value;

    foreach(int i in connection[index]) {
        UpdateParent(i, value);
    }
}

int Compare(Tuple<int, int, int> x, Tuple<int, int, int> y) {
    return x.Item1 - y.Item1;
}

edges.Sort(Compare);

foreach(Tuple<int, int, int> i in edges) {
    if (parent[i.Item2] == parent[i.Item3]) continue;

    answer += i.Item1;
    count -= 1;

    if (count == 1) break;

    if (parent[i.Item2] > parent[i.Item3]) UpdateParent(i.Item2, parent[i.Item3]);
    else UpdateParent(i.Item3, parent[i.Item2]);

    connection[i.Item2].Add(i.Item3);
    connection[i.Item3].Add(i.Item2);
}

sw.WriteLine(answer);

sr.Close();
sw.Close();
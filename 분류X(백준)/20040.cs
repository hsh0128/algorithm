StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int n = int.Parse(inputs[0]);
int m = int.Parse(inputs[1]);

int[] parent = new int[n];
Dictionary<int, List<int>> connection = new Dictionary<int, List<int>>();
int answer = 0;
int first, second;

for (int i = 0; i < n; i++) {
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

for (int i = 1; i <= m; i++) {
    inputs = sr.ReadLine().Split(' ');

    if (answer != 0) continue;

    first = int.Parse(inputs[0]);
    second = int.Parse(inputs[1]);

    if (parent[first] == parent[second]) {
        answer = i;
        continue;
    }

    if (parent[first] > parent[second]) {
        UpdateParent(first, parent[second]);
    } else {
        UpdateParent(second, parent[first]);
    }

    connection[second].Add(first);
    connection[first].Add(second);
}

sw.WriteLine(answer);

sr.Close();
sw.Close();
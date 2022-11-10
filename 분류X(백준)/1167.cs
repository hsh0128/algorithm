StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int V = int.Parse(sr.ReadLine());

string[] inputs;
List<KeyValuePair<int, int>>[] edges = new List<KeyValuePair<int, int>>[V];
int start, dest, len;

for (int i = 0; i < V; i++) {
    inputs = sr.ReadLine().Split(' ');

    start = int.Parse(inputs[0]) - 1;
    edges[start] = new List<KeyValuePair<int, int>>();

    int iter = (inputs.Count() - 2) / 2;

    for (int j = 0; j < iter; j++) {
        dest = int.Parse(inputs[j * 2 + 1]) - 1;
        len = int.Parse(inputs[j * 2 + 2]);

        edges[start].Add(new KeyValuePair<int, int>(dest, len));
    }
}

bool[] searched = new bool[V];
int maxLen = 0, maxIdx = -1;

void Search(int nowIdx, int nowLen) {
    if (searched[nowIdx]) return;
    
    searched[nowIdx] = true;

    if (nowLen > maxLen) {
        maxIdx = nowIdx;
        maxLen = nowLen;
    }

    foreach(KeyValuePair<int, int> i in edges[nowIdx]) {
        Search(i.Key, i.Value + nowLen);
    }
}

Search(0, 0);

searched = new bool[V];
maxLen = 0;

Search(maxIdx, 0);

sw.WriteLine(maxLen);

sr.Close();
sw.Close();
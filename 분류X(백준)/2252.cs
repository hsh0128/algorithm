using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

int[] count = new int[N + 1];
int first, second;
Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();

for (int i = 0; i < M; i++) {
    inputs = sr.ReadLine().Split(' ');
    first = int.Parse(inputs[0]);
    second = int.Parse(inputs[1]);

    if (!edges.ContainsKey(first)) edges.Add(first, new List<int>());

    edges[first].Add(second);
    count[second] += 1;
}

Queue<int> searching = new Queue<int>();

for (int i = 1; i <= N; i++) {
    if (count[i] == 0) searching.Enqueue(i);
}

StringBuilder sb = new StringBuilder();

int nowVal;

while(searching.Count() > 0) {
    nowVal = searching.Dequeue();

    sb.Append(nowVal.ToString());
    sb.Append(' ');

    if (!edges.ContainsKey(nowVal)) continue;

    foreach(int i in edges[nowVal]) {
        count[i] -= 1;

        if (count[i] == 0) searching.Enqueue(i);
    }
}


sb.Remove(sb.Length - 1, 1);
sw.Write(sb);

sr.Close();
sw.Close();
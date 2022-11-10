using System.Text;

int N = int.Parse(Console.ReadLine());

List<int>[] tree = new List<int>[N];

for (int i = 0; i < N; i++) {
    tree[i] = new List<int>();
}

string[] inputs;
int first, second;

for (int i = 0; i < N - 1; i++) {
    inputs = Console.ReadLine().Split(' ');
    first = int.Parse(inputs[0]) - 1;
    second = int.Parse(inputs[1]) - 1;

    tree[first].Add(second);
    tree[second].Add(first);
}

bool[] searched = new bool[N];
int[] parent = new int[N];

void Search(int nowNode, int prevNode) {
    if (searched[nowNode]) return;

    searched[nowNode] = true;
    parent[nowNode] = prevNode;

    foreach(int i in tree[nowNode]) {
        Search(i, nowNode);
    }
}

Search(0, 0);

StringBuilder sb = new StringBuilder();

for (int i = 1; i < N; i++) {
    sb.AppendLine((parent[i]+1).ToString());
}

Console.Write(sb);
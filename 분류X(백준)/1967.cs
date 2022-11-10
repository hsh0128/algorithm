int n = int.Parse(Console.ReadLine());

string[] inputs;
List<KeyValuePair<int, int>>[] tree = new List<KeyValuePair<int, int>>[n];

for (int i = 0; i < n; i++) {
    tree[i] = new List<KeyValuePair<int, int>>();
}

int first, second, length;

for (int i = 0; i < n - 1; i++) {
    inputs = Console.ReadLine().Split(' ');

    first = int.Parse(inputs[0]) - 1;
    second = int.Parse(inputs[1]) - 1;
    length = int.Parse(inputs[2]);

    tree[first].Add(new KeyValuePair<int, int>(second, length));
    tree[second].Add(new KeyValuePair<int, int>(first, length));
}

bool[] searched = new bool[n];

int maxLen = 0;
int maxPivot = 0;

void search(int nowIndex, int nowLength) {
    searched[nowIndex] = true;

    if (nowLength > maxLen) {
        maxLen = nowLength;
        maxPivot = nowIndex;
    }

    foreach(KeyValuePair<int, int> i in tree[nowIndex]) {
        if (searched[i.Key]) continue;

        search(i.Key, i.Value + nowLength);
    }
}

search(0, 0);

searched = new bool[n];
maxLen = 0;

search(maxPivot, 0);

Console.WriteLine(maxLen);
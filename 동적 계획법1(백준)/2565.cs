SortedDictionary<int, int> D = new SortedDictionary<int, int>();
SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
List<int> sequence = new List<int>();

int answer = 0;
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++) {
    string[] input = Console.ReadLine().Split(' ');

    dict[int.Parse(input[0])] = int.Parse(input[1]);
}

foreach(KeyValuePair<int, int> i in dict) {
    sequence.Add(i.Value);
}

for (int i = 0; i < sequence.Count; i++) {
    int nowValue = sequence[i];

    int maxlen = 0;

    foreach(KeyValuePair<int, int> d in D) {
        if (d.Key >= nowValue) {
            break;
        }

        if (d.Value > maxlen) {
            maxlen = d.Value;
        }
    }

    maxlen += 1;

    if (!D.ContainsKey(nowValue) || D[nowValue] < maxlen) {
        D[nowValue] = maxlen;
        if (answer < maxlen) {
            answer = maxlen;
        }
    }
}

Console.WriteLine(n - answer);
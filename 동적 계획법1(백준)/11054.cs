SortedDictionary<int, int> ascSeq = new SortedDictionary<int, int>();
SortedDictionary<int, int> descSeq = new SortedDictionary<int, int>();
int maxlen = 0;

int N = int.Parse(Console.ReadLine());

int[] oriSeq = new int[N];

string[] inputs = Console.ReadLine().Split(' ');

for (int i = 0; i < N; i++) {
    oriSeq[i] = int.Parse(inputs[i]);
}

for (int i = 0; i < N; i++) {
    int currentValue = oriSeq[i];

    int longest = 0;

    foreach(KeyValuePair<int, int> j in ascSeq.Reverse()) {
        if (j.Key <= currentValue) {
            break;
        }

        if (longest < j.Value) {
            longest = j.Value;
        }
    }

    foreach(KeyValuePair<int, int> j in descSeq.Reverse()) {
        if (j.Key <= currentValue) {
            break;
        }

        if (longest < j.Value) {
            longest = j.Value;
        }
    }

    longest += 1;

    if (!descSeq.ContainsKey(currentValue) || descSeq[currentValue] < longest) {
        descSeq[currentValue] = longest;

        if (longest > maxlen) {
            maxlen = longest;
        } 
    }

    longest = 0;

    foreach(KeyValuePair<int,int> j in ascSeq) {
        if (j.Key >= currentValue) {
            break;
        }

        if (longest < j.Value) {
            longest = j.Value;
        }
    }

    longest += 1;

    if (!ascSeq.ContainsKey(currentValue) || ascSeq[currentValue] < longest) {
        ascSeq[currentValue] = longest;

        if (longest > maxlen) {
            maxlen = longest;
        }
    }
}

Console.WriteLine(maxlen);
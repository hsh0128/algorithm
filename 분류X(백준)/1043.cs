List<int> initialKnownPeople = new List<int>();
HashSet<int> knownPeople = new HashSet<int>();
List<List<int>> party = new List<List<int>>();

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

bool[] searched = new bool[N+1];

List<SortedSet<int>> connection = new List<SortedSet<int>>();

for (int i = 0; i < N; i++) {
    connection.Add(new SortedSet<int>());
}

inputs = Console.ReadLine().Split(' ');

for (int i = 1; i < inputs.Length; i++) {
    initialKnownPeople.Add(int.Parse(inputs[i]));
    knownPeople.Add(int.Parse(inputs[i]));
}

int nowval;

for (int i = 0; i < M; i++) {
    List<int> cache = new List<int>();

    inputs = Console.ReadLine().Split(' ');

    for (int j = 1; j < inputs.Length; j++) {
        nowval = int.Parse(inputs[j]);

        foreach(int k in cache) {
            connection[nowval - 1].Add(k);
            connection[k - 1].Add(nowval);
        }
        cache.Add(nowval);
    }

    party.Add(cache);
}

void AddSearch(int index) {
    if (searched[index]) return;

    knownPeople.Add(index);
    searched[index] = true;

    foreach(int i in connection[index - 1]) {
        AddSearch(i);
    }
}

foreach(int i in initialKnownPeople) {
    AddSearch(i);
}

int answer = 0;
bool flag;

for (int i = 0; i < party.Count; i++) {
    flag = true;

    foreach(int j in party[i]) {
        if (knownPeople.Contains(j)) {
            flag = false;
            break;
        }
    }

    if (flag) answer += 1;
}

Console.WriteLine(answer);
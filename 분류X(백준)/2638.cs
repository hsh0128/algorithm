string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

bool[,] map = new bool[N,M];
int cheeseCnt = 0, cache;

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < M; j++) {
        cache = int.Parse(inputs[j]);

        if (cache == 1) {
            cheeseCnt += 1;
            map[i, j] = true;
        }
    }
}

bool[,] searched;
Dictionary<KeyValuePair<int, int>, int> cheeseAirCnt;

void dfs(int x, int y) {
    if (searched[x, y]) return;

    if (map[x, y]) {
        if (!cheeseAirCnt.ContainsKey(new KeyValuePair<int, int>(x, y))) cheeseAirCnt.Add(new KeyValuePair<int, int>(x, y), 0);

        cheeseAirCnt[new KeyValuePair<int, int>(x, y)] += 1;

        return;
    }

    searched[x, y] = true;

    if (x > 0) dfs(x - 1, y);
    if (y > 0) dfs(x, y - 1);
    if (x < N - 1) dfs(x + 1, y);
    if (y < M - 1) dfs(x, y + 1);
}

int answer = 0;

while(cheeseCnt > 0) {
    searched = new bool[N, M];
    cheeseAirCnt = new Dictionary<KeyValuePair<int, int>, int>();

    for (int i = 0; i < M; i++) {
        dfs(0, i);
        dfs(N - 1, i);
    }

    for (int i = 0; i < N; i++) {
        dfs(i, 0);
        dfs(i, M - 1);
    }

    foreach(KeyValuePair<KeyValuePair<int, int>, int> i in cheeseAirCnt) {
        if (i.Value >= 2) {
            map[i.Key.Key, i.Key.Value] = false;
            cheeseCnt -= 1;
        }
    }

    answer += 1;
}

Console.WriteLine(answer);
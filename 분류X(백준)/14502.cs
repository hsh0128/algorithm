string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

int[,] map = new int[N, M];
int space = 0;
int tempAnswer, answer = -1;
KeyValuePair<int, int>[] nowWalls;
bool[,] searched;

List<KeyValuePair<int, int>> virusPositions = new List<KeyValuePair<int, int>>();

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < M; j++) {
        map[i, j] = int.Parse(inputs[j]);
        if (map[i, j] == 0) space += 1;
        if (map[i, j] == 2) virusPositions.Add(new KeyValuePair<int, int>(i, j));
    }
}

int[] tempArr = new int[0];

searchWalls(0, tempArr);

void virusCountingRecur(int x, int y) {
    if (x < 0 || x >= N) return;
    if (y < 0 || y >= M) return;
    if (searched[x, y]) return;
    if (map[x, y] == 1) return;
    if (nowWalls.Contains(new KeyValuePair<int, int>(x, y))) return;

    searched[x, y] = true;
    if (map[x, y] == 0) tempAnswer -= 1;

    virusCountingRecur(x + 1, y);
    virusCountingRecur(x - 1, y);
    virusCountingRecur(x, y + 1);
    virusCountingRecur(x, y - 1);
}

void virusCounting(int[] walls) {
    nowWalls = new KeyValuePair<int, int>[3];

    for (int i = 0; i < 3; i++) {
        nowWalls[i] = new KeyValuePair<int, int>(walls[i] / 10, walls[i] % 10);
    }

    searched = new bool[N, M];
    tempAnswer = space;

    foreach(KeyValuePair<int, int> i in virusPositions) {
        virusCountingRecur(i.Key, i.Value);
    }

    if (tempAnswer > answer) {
        answer = tempAnswer;
    }
}

void searchWalls(int now, int[] nowArr) {
    int nowLen = nowArr.Count();
    int nowX = now / 10;
    int nowY = now % 10;

    if (nowLen == 3) {
        virusCounting(nowArr);
        return;
    }

    if (nowX >= N) return;
    if (nowY >= M) {
        searchWalls((nowX + 1) * 10, nowArr);
        return;
    }

    searchWalls(now + 1, nowArr);

    if (map[nowX, nowY] != 0) return;

    int[] newArr = new int[nowLen + 1];

    for (int i = 0; i < nowLen; i++) {
        newArr[i] = nowArr[i];
    }

    newArr[nowLen] = now;

    searchWalls(now + 1, newArr);
}

Console.WriteLine(answer - 3);
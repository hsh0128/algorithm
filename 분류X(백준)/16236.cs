int N = int.Parse(Console.ReadLine());

int[,] field = new int[N,N];

int cache;
int originX = -1, originY = -1;

for (int i = 0; i < N; i++) {
    string[] inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < N; j++) {
        cache = int.Parse(inputs[j]);

        field[i,j] = cache;

        if (cache == 9) {
            originX = i;
            originY = j;
            field[i,j] = 0;
        }
    }
}

int answer = 0;

void search(int size, int ateCnt, int startX, int startY) {
    int minlen = 9999999, minX = -1, minY = -1;
    int cacheLen;

    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
            if (field[i,j] == 0) continue;
            if (field[i,j] >= size) continue;

            cacheLen = BFS(i, j, startX, startY, size);

            if (cacheLen > 0 && cacheLen < minlen) {
                minlen = cacheLen;
                minX = i;
                minY = j;
            }
        }
    }

    if (minlen == 9999999) return;

    ateCnt += 1;
    if (ateCnt == size) {
        size += 1;
        ateCnt = 0;
    }

    field[minX, minY] = 0;
    answer += minlen;
    search(size, ateCnt, minX, minY);
}

search(2, 0, originX, originY);

int BFS(int startX, int startY, int targetX, int targetY, int size) {
    bool[,] searched = new bool[N,N];
    List<KeyValuePair<int, int>> searching = new List<KeyValuePair<int, int>>();
    List<KeyValuePair<int, int>> nextSearch = new List<KeyValuePair<int, int>>();
    int count = 0;

    searching.Add(new KeyValuePair<int, int>(startX, startY));
    searched[startX, startY] = true;

    do {
        nextSearch.Clear();

        foreach(KeyValuePair<int, int> i in searching) {
            if (Math.Abs(targetX - i.Key) + Math.Abs(targetY - i.Value) <= 1) {
                return count + 1;
            }

            if (i.Key - 1 >= 0 && !searched[i.Key - 1, i.Value] && field[i.Key - 1, i.Value] <= size) {
                nextSearch.Add(new KeyValuePair<int, int>(i.Key - 1, i.Value));
                searched[i.Key - 1, i.Value] = true;
            }
            if (i.Key + 1 <= N - 1 && !searched[i.Key + 1, i.Value] && field[i.Key + 1, i.Value] <= size) {
                nextSearch.Add(new KeyValuePair<int, int>(i.Key + 1, i.Value));
                searched[i.Key + 1, i.Value] = true;
            }
            if (i.Value - 1 >= 0 && !searched[i.Key, i.Value - 1] && field[i.Key, i.Value - 1] <= size) {
                nextSearch.Add(new KeyValuePair<int, int>(i.Key, i.Value - 1));
                searched[i.Key, i.Value - 1] = true;
            }
            if (i.Value + 1 <= N - 1 && !searched[i.Key, i.Value + 1] && field[i.Key, i.Value + 1] <= size) {
                nextSearch.Add(new KeyValuePair<int, int>(i.Key, i.Value + 1));
                searched[i.Key, i.Value + 1] = true;
            }
        }

        searching = nextSearch.Select(num => new KeyValuePair<int, int>(num.Key, num.Value)).ToList();
        count += 1;
    } while(nextSearch.Count > 0);

    return -1;
}

Console.WriteLine(answer);
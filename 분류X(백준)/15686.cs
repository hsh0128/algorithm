string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

List<KeyValuePair<int, int>> home = new List<KeyValuePair<int, int>>();
List<KeyValuePair<int, int>> chicken = new List<KeyValuePair<int, int>>();

int cache;

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < N; j++) {
        cache = int.Parse(inputs[j]);

        if (cache == 1) {
            home.Add(new KeyValuePair<int, int>(i, j));
        } else if (cache == 2) {
            chicken.Add(new KeyValuePair<int, int>(i, j));
        }
    }
}

int chickenCnt = chicken.Count;
int homeCnt = home.Count;

int[,] lengths = new int[chicken.Count, home.Count];

for (int i = 0; i < chickenCnt; i++) {
    for (int j = 0; j < homeCnt; j++) {
        cache = Math.Abs(chicken[i].Key - home[j].Key) + Math.Abs(chicken[i].Value - home[j].Value);

        lengths[i,j] = cache;
    }
}

int answer = 100000;

int GetChickenLengths(int[] targetArr) {
    int[] distances = new int[homeCnt];

    foreach(int i in targetArr) {
        for (int j = 0; j < homeCnt; j++) {
            if (distances[j] == 0 || distances[j] > lengths[i, j]) {
                distances[j] = lengths[i, j];
            }
        }
    }

    int ret = 0;

    foreach(int i in distances) {
        ret += i;
    }

    return ret;
}

void recursive(int[] nowarray, int nowIdx) {

    if (nowarray[M - 1] != -1) {
        cache = GetChickenLengths(nowarray);

        if (answer > cache) answer = cache;

        return;
    }

    if (nowIdx == chickenCnt) {
        return;
    }

    int[] firstArr = new int[M], secondArr = new int[M];

    nowarray.CopyTo(firstArr, 0);

    recursive(firstArr, nowIdx + 1);

    nowarray.CopyTo(secondArr, 0);

    for (int i = 0; i < M; i++) {
        if (secondArr[i] == -1) {
            secondArr[i] = nowIdx;
            break;
        }
    }

    recursive(secondArr, nowIdx + 1);
}

int[] temp = new int[M];

for (int i = 0; i < M; i++) {
    temp[i] = -1;
}

recursive(temp, 0);

Console.WriteLine(answer);
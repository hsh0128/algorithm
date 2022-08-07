List<int> woods = new List<int>();

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
long M = long.Parse(inputs[1]);

int MAX = 0, cache;

inputs = Console.ReadLine().Split(' ');

for (int i = 0; i < N; i++) {
    cache = int.Parse(inputs[i]);

    if (cache > MAX) MAX = cache;

    woods.Add(cache);
}

woods.Sort(delegate(int x, int y) {
    return y - x;
});


long GetLength(int m) {
    long nowSum = 0;
    int cnt = 0;

    foreach(int i in woods) {
        if (i <= m) break;

        nowSum += (long)(i - m);
        cnt += 1;
    }

    return nowSum;
}

long nowSumLength = 0;
int nowPivot = MAX, nowSearchLen = MAX / 2;
bool foundAnswer = false;
int answer;

while(true) {
    nowSumLength = GetLength(nowPivot);

    if (nowSumLength >= M) {
        nowPivot += nowSearchLen;

        if (nowSearchLen > 1)
            nowSearchLen /= 2;
        else {
            foundAnswer = true;
        }

        continue;
    }

    if (foundAnswer) {
        answer = nowPivot - 1;
        break;
    }

    nowPivot -= nowSearchLen;
    if (nowSearchLen > 1)
        nowSearchLen /= 2;
}

Console.WriteLine(answer);
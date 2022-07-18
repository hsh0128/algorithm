List<long> length = new List<long>();

long CountOfCable(long minLen) {
    long nowCnt, cnt = 0;

    foreach(long i in length) {
        nowCnt = 1;

        while (i / nowCnt >= minLen) {
            nowCnt += 1;
        }

        cnt += nowCnt - 1;
    }

    return cnt;
}

string[] inputs = Console.ReadLine().Split(' ');

int K = int.Parse(inputs[0]);
int N = int.Parse(inputs[1]);

int maxLen = 0, cache;

for (int i = 0; i < K; i++) {
    cache = int.Parse(Console.ReadLine());

    if (cache > maxLen) maxLen = cache;

    length.Add(cache);
}

long nowLen = (long)maxLen;
long searchWidth = nowLen;
long nowCnt = CountOfCable(nowLen);
bool foundAnswer = false;

while (true) {
    if (searchWidth > 1)
        searchWidth /= 2;

    if (nowCnt >= N) {
        if (searchWidth == 1) {
            foundAnswer = true;
        }

        nowLen += searchWidth;

        nowCnt = CountOfCable(nowLen);

        continue;
    }

    if (nowCnt < N) {
        if (foundAnswer) {
            Console.WriteLine(nowLen - 1);
            break;
        }

        nowLen -= searchWidth;

        nowCnt = CountOfCable(nowLen);

        continue;
    }
}
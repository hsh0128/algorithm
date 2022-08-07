int N = int.Parse(Console.ReadLine());
int len = int.Parse(Console.ReadLine());

string str = Console.ReadLine();

int cacheLen = 0;
int sumCache;
int answer = 0;

for (int i = 0; i < len; i++) {
    if (str[i] == 'I' && cacheLen % 2 == 0) {
        cacheLen += 1;
    } else if (str[i] == 'O' && cacheLen % 2 == 1) {
        cacheLen += 1;
    } else {
        sumCache = ((cacheLen - 1) / 2) - N + 1 > 0 ? ((cacheLen - 1) / 2) - N + 1 : 0;
        answer += sumCache;
        cacheLen = 0;

        if (str[i] == 'I') {
            cacheLen += 1;
        }
    }
}

sumCache = ((cacheLen - 1) / 2) - N + 1 > 0 ? ((cacheLen - 1) / 2) - N + 1 : 0;
answer += sumCache;

Console.WriteLine(answer);
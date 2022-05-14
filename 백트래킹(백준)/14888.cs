int MAX = -1000000001, MIN = 1000000001;

int N = int.Parse(Console.ReadLine());

string[] inputString = Console.ReadLine().Split(' ');
string[] inputCalculateString = Console.ReadLine().Split(' ');


int[] A = new int[N];
int[] inputCalculator = new int[4];

for (int i = 0; i < N; i++) {
    A[i] = int.Parse(inputString[i]);
}

for (int i = 0; i < 4; i++) {
    inputCalculator[i] = int.Parse(inputCalculateString[i]);
}

recursive(A[0], 1, inputCalculator[0], inputCalculator[1], inputCalculator[2], inputCalculator[3]);

Console.WriteLine(MAX);
Console.WriteLine(MIN);

void recursive(int nowVal, int nowIndex, int plusCnt, int minusCnt, int mulCnt, int divCnt) {
    if (nowIndex == N) {
        if (nowVal > MAX) {
            MAX = nowVal;
        }

        if (nowVal < MIN) {
            MIN = nowVal;
        }

        return;
    }

    if (plusCnt > 0) {
        recursive(nowVal + A[nowIndex], nowIndex + 1, plusCnt - 1, minusCnt, mulCnt, divCnt);
    }

    if (minusCnt > 0) {
        recursive(nowVal - A[nowIndex], nowIndex + 1, plusCnt, minusCnt - 1, mulCnt, divCnt);
    }

    if (mulCnt > 0) {
        recursive(nowVal * A[nowIndex], nowIndex + 1, plusCnt, minusCnt, mulCnt - 1, divCnt);
    }

    if (divCnt > 0) {
        recursive(nowVal / A[nowIndex], nowIndex + 1, plusCnt, minusCnt, mulCnt, divCnt - 1);
    }
}
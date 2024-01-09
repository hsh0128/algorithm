StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int C = int.Parse(inputs[1]);

int[] X = new int[N];

for (int i = 0; i < N; i++) {
    X[i] = int.Parse(sr.ReadLine());
}

Array.Sort(X);

bool Check(int len) {
    int remainWIFI = C - 1;
    int remainLen = len;

    for (int i = 1; i < N; i++) {
        remainLen -= (X[i] - X[i - 1]);

        if (remainLen <= 0) {
            remainWIFI -= 1;
            remainLen = len;

            if (remainWIFI == 0) return true;
        }
    }

    return false;
} 

int Search(int min, int max) {
    if (min == max) return min;
    if (min + 1 == max) {
        if (Check(max)) return max;

        return min;
    }

    int mid = (min + max) / 2;

    if (Check(mid)) return Search(mid, max);

    return Search(min, mid - 1);
}

int answer = Search(0, X[N - 1] - X[0]);

sw.WriteLine(answer);

sr.Close();
sw.Close();
string[] inputs = Console.ReadLine().Split(' ');

int n = int.Parse(inputs[0]);
int m = int.Parse(inputs[1]);

if (m > n / 2) m = n - m;

int[] Convert(int number) {
    int[] ret = new int[31];

    for (int i = 0; i < 31; i++) {
        ret[i] = number % 10;
        number /= 10;
    }

    return ret;
}

int[] Add(int[] a, int[] b) {
    bool upper = false;
    int cache;
    int[] ret = new int[31];

    for (int i = 0; i < 31; i++) {
        cache = a[i] + b[i];
        if (upper) cache += 1;

        ret[i] = cache % 10;

        if (cache >= 10) upper = true;
        else upper = false;
    }

    return ret;
}

int[,][] D = new int[n + 1, n + 1][];

int[] recursive(int first, int second) {
    if (first == second || second == 0) return Convert(1);
    if (second == 1) return Convert(first);
    if (D[first, second] != null) return D[first, second];

    D[first, second] = Add(recursive(first - 1, second), recursive(first - 1, second - 1));

    return D[first, second];
}

int[] answer = recursive(n, m);
bool flag = true;

for (int i = 30; i >= 0; i--) {
    if (flag && answer[i] == 0) continue;

    flag = false;
    Console.Write(answer[i]);
}

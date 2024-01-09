StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());
int k = int.Parse(sr.ReadLine());

int Count(int bound) {
    int lastNum = Math.Min(bound, N);
    int ret = 0;

    for (int i = 1; i <= lastNum; i++) {
        ret += Math.Min(bound / i, N);
    }

    return ret;
}

int Search(int left, int right) {
    if (left == right) return left;
    if (left + 1 == right) {
        if (Count(left) >= k) return left;

        return right;
    }

    int mid = (left + right) / 2;

    int cnt = Count(mid);

    if (cnt >= k) return Search(left, mid);

    return Search(mid + 1, right);
}

sw.WriteLine(Search(1, k));

sr.Close();
sw.Close();
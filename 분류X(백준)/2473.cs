StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

string[] inputs = sr.ReadLine().Split(' ');

long[] solutions = new long[N];

for (int i = 0; i < N; i++) {
    solutions[i] = long.Parse(inputs[i]);
}

Array.Sort(solutions);

int Search(int start, int end, long solValue) {
    if (start == end) return start;
    if (start + 1 == end) {
        if (Math.Abs(solutions[start] + solValue) < Math.Abs(solutions[end] + solValue)) return start;
        else return end; 
    }
    int mid = (start + end) / 2;

    long leftVal = Math.Abs(solValue + solutions[mid - 1]);
    long rightVal = Math.Abs(solValue + solutions[mid + 1]);
    long midVal = Math.Abs(solValue + solutions[mid]);

    if (midVal < leftVal && midVal < rightVal) return mid;
    else if (leftVal < rightVal) return Search(start, mid - 1, solValue);
    else return Search(mid + 1, end, solValue);
}

long minimum = long.MaxValue, ans1 = 0, ans2 = 0, ans3 = 0;
long nowSol;
int nowIdx;

for (int i = 0; i < N - 2; i++) {
    for (int j = i + 1; j < N - 1; j++) {
        nowSol = solutions[i] + solutions[j];
        nowIdx = Search(j + 1, N - 1, nowSol);

        if (Math.Abs(nowSol + solutions[nowIdx]) < minimum) {
            minimum = Math.Abs(nowSol + solutions[nowIdx]);

            ans1 = solutions[i];
            ans2 = solutions[j];
            ans3 = solutions[nowIdx];
        }
    }
}

sw.Write(ans1);
sw.Write(' ');
sw.Write(ans2);
sw.Write(' ');
sw.Write(ans3);

sr.Close();
sw.Close();
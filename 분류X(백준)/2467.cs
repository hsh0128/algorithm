StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

string[] inputs = sr.ReadLine().Split(' ');
List<int> solutions = new List<int>();

for (int i = 0; i < N; i++) {
    solutions.Add(int.Parse(inputs[i]));
}

int BinarySearch(int start, int end, int startValue) {
    if (start > end) return end;
    if (start == end) return start;
    if (start + 1 == end) {
        int s = Math.Abs(startValue + solutions[start]);
        int e = Math.Abs(startValue + solutions[end]);

        if (s < e) return start;
        else return end;
    }

    int mid = (start + end) / 2;

    int downSum = Math.Abs(startValue + solutions[mid - 1]);
    int nowSum = Math.Abs(startValue + solutions[mid]);
    int upSum = Math.Abs(startValue + solutions[mid + 1]);

    if (nowSum < downSum && nowSum < upSum) return mid;
    else if (downSum < upSum) return BinarySearch(start, mid - 1, startValue);
    else return BinarySearch(mid + 1, end, startValue);
}

int nowIdx, cache, answer = int.MaxValue;

KeyValuePair<int, int> answerNumbers = new KeyValuePair<int, int>(solutions[0], solutions[1]);

for (int i = 0; i < N; i++) {
    nowIdx = BinarySearch(0, N - 1, solutions[i]);

    if (nowIdx < 0) nowIdx = 0;

    if (nowIdx != i) cache = solutions[i] + solutions[nowIdx];
    else {
        if (nowIdx == 0) {
            cache = solutions[i] + solutions[nowIdx + 1];
            nowIdx += 1;
        }
        else if (nowIdx == N - 1) {
            cache = solutions[i] + solutions[nowIdx - 1];
            nowIdx -= 1;
        }
        else {
            if (Math.Abs(solutions[i] + solutions[nowIdx - 1]) > Math.Abs(solutions[i] + solutions[nowIdx + 1])) {
                cache = solutions[i] + solutions[nowIdx + 1];
                nowIdx += 1;
            }
            else {
                cache = solutions[i] + solutions[nowIdx - 1];
                nowIdx -= 1;
            }
        }
    }

    if (Math.Abs(answer) > Math.Abs(cache)) {
        answer = cache;
        if (solutions[i] > solutions[nowIdx]) answerNumbers = new KeyValuePair<int, int>(solutions[nowIdx], solutions[i]);
        else answerNumbers = new KeyValuePair<int, int>(solutions[i], solutions[nowIdx]);
    }
}

sw.Write(answerNumbers.Key);
sw.Write(' ');
sw.Write(answerNumbers.Value);

sr.Close();
sw.Close();
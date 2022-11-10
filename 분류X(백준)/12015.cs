StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

string[] inputs = sr.ReadLine().Split(' ');
List<int> D = new List<int>();
int nowVal, nowIdx;

D.Add(int.Parse(inputs[0]));

int replaceableIdx(int startIdx, int endIdx, int targetValue) {
    if (startIdx > endIdx) {
        return startIdx;
    } 

    if (startIdx == endIdx) {
        if (targetValue < D[startIdx]) return startIdx;
        else if (targetValue == D[startIdx]) return -1;
        else return startIdx + 1;
    }

    int mid = (startIdx + endIdx) / 2;

    if (D[mid] == targetValue) return -1;

    else if (D[mid] > targetValue) return replaceableIdx(startIdx, mid - 1, targetValue);

    else return replaceableIdx(mid + 1, endIdx, targetValue);
}

for (int i = 1; i < N; i++) {
    nowVal = int.Parse(inputs[i]);

    nowIdx = replaceableIdx(0, D.Count - 1, nowVal);

    if (nowIdx == -1) {
        continue;
    }

    if (nowIdx == D.Count) {
        D.Add(nowVal);
        continue;
    }

    D[nowIdx] = nowVal;
}

sw.WriteLine(D.Count);

sr.Close();
sw.Close();
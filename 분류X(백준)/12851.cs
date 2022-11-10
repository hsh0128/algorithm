StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int K = int.Parse(inputs[1]);

int MAXINT = Math.Max(N, K * 2);
bool[] searched = new bool[MAXINT + 1];
int step = 1, answerCnt = 0;

void Search(List<int> nowSearch) {
    bool foundAnswer = false;
    List<int> nextSearch = new List<int>();

    foreach(int i in nowSearch) {
        if (i + 1 == K) {
            foundAnswer = true;
            answerCnt += 1;
        }
        if (i - 1 == K) {
            foundAnswer = true;
            answerCnt += 1;
        }
        if (i * 2 == K) {
            foundAnswer = true;
            answerCnt += 1;
        }

        if (i + 1 < MAXINT && !searched[i + 1] && !foundAnswer) {
            nextSearch.Add(i + 1);
        }
        if (i - 1 >= 0 && !searched[i - 1] && !foundAnswer) {
            nextSearch.Add(i - 1);
        }
        if (i * 2 < MAXINT && !searched[i * 2] && !foundAnswer) {
            nextSearch.Add(i * 2);
        }
    }

    if (foundAnswer) return;

    foreach(int i in nextSearch) {
        searched[i] = true;
    }

    step += 1;
    Search(nextSearch);
}

if (N == K) {
    sw.WriteLine(0);
    sw.WriteLine(1);
} else {
    List<int> temp = new List<int>();
    temp.Add(N);

    Search(temp);

    sw.WriteLine(step);
    sw.WriteLine(answerCnt);
}

sr.Close();
sw.Close();
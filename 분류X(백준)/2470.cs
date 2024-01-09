StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

string[] inputs = sr.ReadLine().Split(' ');
int[] solutions = new int[N];

for (int i = 0; i < N; i++) {
    solutions[i] = int.Parse(inputs[i]);
}

Array.Sort(solutions);

int start = 0, last = N - 1, minimum = int.MaxValue, answerStart = solutions[N - 1], answerLast = solutions[0];

while(start != last) {
    int nowSum = solutions[last] + solutions[start];

    if (Math.Abs(nowSum) < minimum) {
        minimum = Math.Abs(nowSum);
        answerLast = solutions[last];
        answerStart = solutions[start];
    }

    if (nowSum > 0) {
        last -= 1;
    } else if (nowSum < 0) {
        start += 1;
    } else {
        break;
    }
}

sw.Write(answerStart);
sw.Write(' ');
sw.Write(answerLast);

sr.Close();
sw.Close();
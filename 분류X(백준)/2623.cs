using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

int[] count = new int[N + 1];
Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();

for (int i = 1; i <= N; i++) {
    edges.Add(i, new List<int>());
}

int nowInt, prevInt, it;
for (int i = 0; i < M; i++) {
    inputs = sr.ReadLine().Split(' ');

    it = int.Parse(inputs[0]);
    prevInt = -1;

    for (int j = 1; j <= it; j++) {
        nowInt = int.Parse(inputs[j]);

        if (prevInt == -1) {
            prevInt = nowInt;
            continue;
        }

        if (edges[prevInt].Contains(nowInt)) {
            prevInt = nowInt;
            continue;
        }

        edges[prevInt].Add(nowInt);
        count[nowInt] += 1;

        prevInt = nowInt;
    }
}

StringBuilder sb = new StringBuilder();
Queue<int> q = new Queue<int>();
int answerCnt = 0;

for (int i = 1; i <= N; i++) {
    if (count[i] == 0) {
        q.Enqueue(i);
    }
}

while(q.Count() > 0) {
    nowInt = q.Dequeue();

    sb.AppendLine(nowInt.ToString());
    answerCnt += 1;

    foreach(int i in edges[nowInt]) {
        count[i] -= 1;

        if (count[i] == 0) q.Enqueue(i);
    }
}

if (answerCnt == N) sw.Write(sb);
else sw.Write(0);

sr.Close();
sw.Close();
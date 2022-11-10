using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string first = sr.ReadLine();
string second = sr.ReadLine();

int A = first.Length;
int B = second.Length;

int[,] D = new int[A + 1,B + 1];
int f, s;

for (int i = 0; i < A; i++) {
    for (int j = 0; j < B; j++) {
        f = i + 1;
        s = j + 1;

        if (first[i] == second[j]) {
            D[f, s] = Math.Max(D[f - 1, s - 1] + 1, Math.Max(D[f - 1, s], D[f, s - 1]));
        } else {
            D[f, s] = Math.Max(D[f - 1, s - 1], Math.Max(D[f - 1, s], D[f, s - 1]));
        }
    }
}

Stack<char> answerStack = new Stack<char>();

void Search(int x, int y) {
    if (D[x, y] == 0) return;

    if (D[x - 1, y] == D[x, y]) {
        Search(x - 1, y);
        return;
    }

    if (D[x, y - 1] == D[x, y]) {
        Search(x, y - 1);
        return;
    }

    answerStack.Push(first[x - 1]);
    Search(x - 1, y - 1);
}

sw.WriteLine(D[A, B]);

if (D[A, B] > 0) {
    StringBuilder sb = new StringBuilder();

    Search(A, B);

    while(answerStack.Count > 0) {
        sb.Append(answerStack.Pop());
    }

    sw.Write(sb);
}

sr.Close();
sw.Close();
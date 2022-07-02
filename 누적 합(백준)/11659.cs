using System.Text;

string[] inputmn = Console.ReadLine().Split(' ');

List<int> answer = new List<int>();

int N = int.Parse(inputmn[0]);
int M = int.Parse(inputmn[1]);

int[] S = new int[N];

string[] inputs = Console.ReadLine().Split(' ');

int cache;

for (int i = 0; i < N; i++) {
    cache = int.Parse(inputs[i]);

    if (i == 0) {
        S[i] = cache;
    } else {
        S[i] = cache + S[i-1];
    }
}

for (int i = 0; i < M; i++) {
    string[] inputIJ = Console.ReadLine().Split(' ');

    int I = int.Parse(inputIJ[0]);
    int J = int.Parse(inputIJ[1]);

    if (I == 1) {
        answer.Add(S[J-1]);
    } else {
        answer.Add(S[J-1] - S[I - 2]);
    }
}

StringBuilder sb = new StringBuilder();

foreach(int i in answer) {
    sb.AppendLine(i.ToString());
}

Console.Write(sb);
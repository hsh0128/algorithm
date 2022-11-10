using System.Text;

Dictionary<string, string> memo = new Dictionary<string, string>();

string input;
string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    memo.Add(inputs[0], inputs[1]);
}

StringBuilder sb = new StringBuilder();

for (int i = 0; i < M; i++) {
    input = Console.ReadLine();
    sb.AppendLine(memo[input]);
}

Console.Write(sb);
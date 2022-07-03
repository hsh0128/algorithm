using System.Text;

string input = Console.ReadLine();

int len = input.Length;

int[,] Sum = new int[len,26];

for (int i = 0; i < input.Length; i++) {
    int currnet = (int)input[i] - 97;

    for (int j = 0; j < 26; j++) {
        if (i > 0)
            Sum[i, j] = Sum[i-1,j];

        if (j == currnet) {
            Sum[i,j] += 1;
        }
    }
}

int N = int.Parse(Console.ReadLine());

char cacheChar;
int index, l, r, answer;

StringBuilder sb = new StringBuilder();

for (int i = 0; i < N; i++) {
    string[] inputs = Console.ReadLine().Split();

    cacheChar = inputs[0][0];
    index = (int)cacheChar - 97;

    l = int.Parse(inputs[1]);
    r = int.Parse(inputs[2]);

    if (l > 0) {
        answer = Sum[r,index] - Sum[l-1,index];
    } else {
        answer = Sum[r,index];
    }

    sb.AppendLine(answer.ToString());
}

Console.Write(sb);
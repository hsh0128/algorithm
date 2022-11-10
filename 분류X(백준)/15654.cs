using System.Text;

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

int[] numbers = new int[N];

inputs = Console.ReadLine().Split(' ');

for (int i = 0; i < N; i++) {
    numbers[i] = int.Parse(inputs[i]);
}

Array.Sort(numbers);
StringBuilder sb = new StringBuilder();

void Print(int[] nowSequence) {
    int nowLength = nowSequence.Count();

    if (nowLength == M) {
        for (int i = 0; i < M; i++) {
            sb.Append(nowSequence[i]);
            if (i != M - 1) sb.Append(' ');
        }
        sb.Append('\n');
        return;
    }

    foreach(int number in numbers) {
        if (nowSequence.Contains(number)) continue;

        int[] newSequence = new int[nowLength + 1];
        for (int i = 0; i < nowLength; i++) {
            newSequence[i] = nowSequence[i];
        }
        newSequence[nowLength] = number;

        Print(newSequence);
    }
}

int[] temp = new int[0];
Print(temp);

Console.Write(sb);
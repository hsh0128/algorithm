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

void Search(int[] sequence) {
    int seqLength = sequence.Count();
    if (seqLength == M) {
        for (int i = 0; i < M; i++) {
            sb.Append(sequence[i].ToString());

            if (i != M - 1) sb.Append(' ');
            else sb.Append('\n');
        }

        return;
    }

    foreach(int i in numbers) {
        if (seqLength != 0 && i < sequence[seqLength - 1]) continue;

        int[] newSeq = new int[seqLength + 1];

        for (int j = 0; j < seqLength; j++) {
            newSeq[j] = sequence[j];
        }
        newSeq[seqLength] = i;
        Search(newSeq);
    }
}

int[] temp = new int[0];
Search(temp);

Console.Write(sb);
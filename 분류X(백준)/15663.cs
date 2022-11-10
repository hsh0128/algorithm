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

void Search(int[] indexes) {
    int seqLength = indexes.Count();

    if (seqLength == M) {
        for (int i = 0; i < M; i++) {
            sb.Append(numbers[indexes[i]]);
            if (i != M - 1) sb.Append(' ');
            else sb.Append('\n');
        }
        return;
    }

    int cache = -1;

    for (int i = 0; i < N; i++) {
        int[] newIndexes = new int[seqLength + 1];

        if (indexes.Contains(i)) continue;
        if (numbers[i] == cache) continue;

        cache = numbers[i];

        for (int j = 0; j < seqLength; j++) {
            newIndexes[j] = indexes[j];
        }
        newIndexes[seqLength] = i;

        Search(newIndexes);
    }
}

int[] temp = new int[0];
Search(temp);

Console.Write(sb);
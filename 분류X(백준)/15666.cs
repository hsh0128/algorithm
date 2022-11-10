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

void Search(int[] nowSeq) {
    int length = nowSeq.Count();

    if (length == M) {
        for (int i = 0; i < length; i++) {
            sb.Append(nowSeq[i].ToString());
            if (i != length - 1) sb.Append(' ');
        }
        sb.Append('\n');

        return;
    }

    int prevInt = 0;

    foreach(int i in numbers) {
        if (length > 0 && nowSeq[length - 1] > i) continue;
        if (i == prevInt) continue;

        prevInt = i;
        int[] temp = new int[length + 1];

        for (int j = 0; j < length; j++) {
            temp[j] = nowSeq[j];
        }

        temp[length] = i;

        Search(temp);
    }
}

int[] tem = new int[0];

Search(tem);

Console.Write(sb);
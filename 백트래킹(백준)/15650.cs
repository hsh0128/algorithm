using System.Text;

string[] inputs = Console.ReadLine().Split(' ');

List<List<int>> answer = new List<List<int>>();
List<int> usable = new List<int>();
StringBuilder sb = new StringBuilder();

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

for (int i = 1; i <= N; i++) {
    usable.Add(i);
}

void recursive(List<int> current, int remain) {
    if (remain == 0) {
        answer.Add(current);
        return;
    }

    if (current.Count > 0 && current[current.Count - 1] == usable[usable.Count - 1]) {
        return;
    }

    List<int> temp;

    foreach(int i in usable) {
        if (current.Count != 0 && i <= current[current.Count - 1]) {
            continue;
        }

        temp = current.ToList<int>();
        temp.Add(i);
        recursive(temp, remain - 1);
    }
}

recursive(new List<int>(), M);

for (int i = 0; i < answer.Count; i++) {
    for (int j = 0; j < answer[i].Count; j++) {
        sb.Append(answer[i][j]);

        if (j != answer[i].Count - 1) {
            sb.Append(' ');
        }
    }
    sb.Append('\n');
}

Console.Write(sb);
using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

string[] inputs = sr.ReadLine().Split(' ');
int[] seq = new int[N];

for (int i = 0; i < N; i++) {
    seq[i] = int.Parse(inputs[i]);
}

int M = int.Parse(sr.ReadLine());
int S, E;

StringBuilder sb = new StringBuilder();

Dictionary<int, int> odd = new Dictionary<int, int>();
Dictionary<int, int> even = new Dictionary<int, int>();

for (int i = 0; i < M; i++) {
    inputs = sr.ReadLine().Split(' ');

    S = int.Parse(inputs[0]) - 1;
    E = int.Parse(inputs[1]) - 1;

    int center = (S + E) / 2;
    int length = E - S;

    if (length % 2 == 0) {
        if (even.ContainsKey(center) && even[center] >= length) {
            sb.AppendLine("1");
            continue;
        }
    } else {
        if (odd.ContainsKey(center) && odd[center] >= length) {
            sb.AppendLine("1");
            continue;
        }
    }


    bool flag = true;

    int cnt = (length + 1) / 2;

    for (int j = 0; j < cnt; j++) {
        if (seq[S + j] != seq[E - j]) {
            flag = false;
            break;
        }
    }

    if (flag) {
        sb.AppendLine("1");

        if (length % 2 == 0) {
            if (!even.ContainsKey(center)) even.Add(center, 0);

            if (even[center] < length) even[center] = length;
        }
        else {
            if (!odd.ContainsKey(center)) odd.Add(center, 0);

            if (odd[center] < length) odd[center] = length;
        }
    }
    else sb.AppendLine("0");
}

sw.Write(sb);

sr.Close();
sw.Close();
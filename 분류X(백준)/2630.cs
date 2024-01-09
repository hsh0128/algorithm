StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

bool[,] paper = new bool[N, N];
string[] inputs;

for (int i = 0; i < N; i++) {
    inputs = sr.ReadLine().Split(' ');

    for (int j = 0; j < N; j++) {
        if (inputs[j][0] == '1') paper[i, j] = true;
    }
}

KeyValuePair<int, int> recursive(int startX, int startY, int len) {
    if (len == 1) {
        if (paper[startX, startY]) return new KeyValuePair<int, int>(0, 1);
        else return new KeyValuePair<int, int>(1, 0);
    }

    bool flag = true;
    bool compBool = paper[startX, startY];

    for (int i = 0; i < len; i++) {
        if (!flag) break;

        for (int j = 0; j < len; j++) {
            if (paper[i + startX, j + startY] != compBool) {
                flag = false;
                break;
            }
        }
    }

    if (flag) {
        if (paper[startX, startY]) return new KeyValuePair<int, int>(0, 1);
        else return new KeyValuePair<int, int>(1, 0);
    }

    int white = 0, blue = 0;

    KeyValuePair<int, int> num;

    for (int i = 0; i < 4; i++) {
        num = recursive(startX + (len / 2) * (i / 2), startY + (len / 2) * (i % 2), len / 2);

        white += num.Key;
        blue += num.Value;
    }

    return new KeyValuePair<int, int>(white, blue);
}

KeyValuePair<int, int> answer = recursive(0, 0, N);

sw.WriteLine(answer.Key);
sw.WriteLine(answer.Value);

sr.Close();
sw.Close();
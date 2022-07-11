Dictionary<int, int> answer = new Dictionary<int, int>();

answer[-1] = 0;
answer[0] = 0;
answer[1] = 0;

int N = int.Parse(Console.ReadLine());

int[,] paper = new int[N,N];

void CalculateCnt(int startX, int startY, int length) {
    int num = -2;
    bool flag = true;

    for (int i = 0; i < length; i++) {
        for (int j = 0; j < length; j++) {
            if (num == -2) {
                num = paper[startX + i, startY + j];
            } else if (num != paper[startX + i, startY + j]) {
                flag = false;
                break;
            }
        }
    }

    if (flag) {
        answer[num] += 1;
        return;
    }

    int newlen = length / 3;

    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) {
            CalculateCnt(startX + newlen * i, startY + newlen * j, newlen);
        }
    }
}

for (int i = 0; i < N; i++) {
    string[] inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < N; j++) {
        paper[i,j] = int.Parse(inputs[j]);
    }
}

CalculateCnt(0, 0, N);

Console.WriteLine(answer[-1]);
Console.WriteLine(answer[0]);
Console.WriteLine(answer[1]);
int N = int.Parse(Console.ReadLine());

bool[,] wall = new bool[N,N];
string[] input;
int cache, answer = 0;

for (int i = 0; i < N; i++) {
    input = Console.ReadLine().Split(' ');
    for (int j  = 0; j < N; j++) {
        cache = int.Parse(input[j]);
        if (cache == 1) wall[j, i] = true;
    }
}

void search(int nowX, int nowY, int prevPipeType) {
    if (nowX == N - 1 && nowY == N - 1) {
        answer += 1;
        return;
    }

    for (int i = 0; i < 2; i++) {
        if (prevPipeType != 2 && i != prevPipeType) continue;
        
        if (i == 0) {
            if (nowX + 1 >= N) continue;
            if (wall[nowX + 1, nowY]) continue;

            search(nowX + 1, nowY, 0);
        } else {
            if (nowY + 1 >= N) continue;
            if (wall[nowX, nowY + 1]) continue;

            search(nowX, nowY + 1, 1);
        }
    }

    if (nowX + 1 >= N || nowY + 1 >= N) return;
    if (wall[nowX + 1, nowY]) return;
    if (wall[nowX, nowY + 1]) return;
    if (wall[nowX + 1, nowY + 1]) return;

    search(nowX + 1, nowY + 1, 2);
}

search(1, 0, 0);

Console.WriteLine(answer);
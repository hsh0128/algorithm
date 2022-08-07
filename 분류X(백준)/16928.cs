bool[] visited = new bool[101];

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

Dictionary<int, int> ladder = new Dictionary<int, int>();
Dictionary<int, int> snake = new Dictionary<int, int>();

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    ladder.Add(int.Parse(inputs[0]), int.Parse(inputs[1]));
}

for (int j = 0; j < M; j++) {
    inputs = Console.ReadLine().Split(' ');

    snake.Add(int.Parse(inputs[0]), int.Parse(inputs[1]));
}

int answer = -1;

int cache;

void BFS(List<int> currentSearch, int nowDepth) {
    List<int> nextSearch = new List<int>();

    foreach(int i in currentSearch) {
        if (visited[i]) continue;

        visited[i] = true;

        for(int j = 1; j <= 6; j++) {
            if (ladder.ContainsKey(i + j)) {
                cache = ladder[i + j];

                if (cache == 100) {
                    answer = nowDepth + 1;
                    return;
                }

                nextSearch.Add(cache);
            } else if (snake.ContainsKey(i + j)) {
                nextSearch.Add(snake[i + j]);
            } else {
                cache = i + j;

                if (cache == 100) {
                    answer = nowDepth + 1;
                    return;
                }

                nextSearch.Add(i + j);
            }
        }
    }

    BFS(nextSearch, nowDepth + 1);
}

List<int> initial = new List<int>();
initial.Add(1);

BFS(initial, 0);

Console.WriteLine(answer);
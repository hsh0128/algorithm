List<KeyValuePair<int,int>> emptys = new List<KeyValuePair<int, int>>();

int[][] board = new int[9][];
int[] numbers = {1,2,3,4,5,6,7,8,9};

for (int i = 0; i < 9; i++) {
    board[i] = new int[9];
}

Dictionary<int, int> recursive(int it, Dictionary<int, int> filled) {
    if (it == emptys.Count) {
        return filled;
    }

    int x = emptys[it].Key;
    int y = emptys[it].Value;

    List<int> candidates = new List<int>(numbers);

    // 가로/세로 검사
    for (int i = 0; i < 9; i++) {
        if (board[x][i] == 0 && i < y) {
            candidates.Remove(filled[10*x + i]);
        } else {
            candidates.Remove(board[x][i]);
        }

        if (board[i][y] == 0 && i < x) {
            candidates.Remove(filled[10*i + y]);
        } else {
            candidates.Remove(board[i][y]);
        }
    }

    // 내부 칸 검사
    int startX = (x / 3) * 3;
    int startY = (y / 3) * 3;

    for (int i = startX; i < startX + 3; i++) {
        for (int j = startY; j < startY + 3; j++) {
            if (board[i][j] == 0 && filled.ContainsKey(10 * i + j)) {
                candidates.Remove(filled[10*i + j]);
            } else {
                candidates.Remove(board[i][j]);
            }
        }
    }

    foreach(int i in candidates) {
        Dictionary<int, int> tempFill = new Dictionary<int, int>(filled);

        tempFill.Add(10*x+y, i);

        Dictionary<int, int> test = recursive(it + 1, tempFill);

        if (test != null) {
            return test;
        }
    }

    return null;
}

int cache;

for (int i = 0; i < 9; i++) {
    string[] inputs = Console.ReadLine().Split(' ');
    
    for (int j = 0; j < 9; j++) {
        cache = int.Parse(inputs[j]);

        if (cache == 0) {
            emptys.Add(new KeyValuePair<int, int>(i, j));
        }

        board[i][j] = cache;
    }
}

Dictionary<int, int> answer = recursive(0, new Dictionary<int, int>());

for (int i = 0; i < 9; i++) {
    for (int j = 0; j < 9; j++) {
        if (board[i][j] == 0) {
            Console.Write(answer[10*i+j]);
            Console.Write(' ');

            continue;
        }

        Console.Write(board[i][j]);
        Console.Write(' ');
    }
    Console.Write('\n');
}
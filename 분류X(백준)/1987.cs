StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int R = int.Parse(inputs[0]);
int C = int.Parse(inputs[1]);

char[,] board = new char[R,C];
string input;

for (int i = 0; i < R; i++) {
    input = sr.ReadLine();

    for (int j = 0; j < C; j++) {
        board[i, j] = input[j];
    }
}

int answer = 1;

void Search(int nowR, int nowC, int len, bool[] alphabets) {
    if (answer < len) {
        answer = len;
    }

    bool top = true, down = true, left = true, right = true;

    if (nowC + 1 >= C || alphabets[board[nowR, nowC + 1] - 'A']) {
        down = false;
    }

    if (nowC - 1 < 0 || alphabets[board[nowR, nowC - 1] - 'A']) {
        top = false;
    }

    if (nowR - 1 < 0 || alphabets[board[nowR - 1, nowC] - 'A']) {
        left = false;
    }

    if (nowR + 1 >= R || alphabets[board[nowR + 1, nowC] - 'A']) {
        right = false;
    }

    if (down) {
        bool[] newAlphabet = new bool[27];
        for (int i = 0; i < 27; i++) {
            if (alphabets[i]) newAlphabet[i] = true;
        }
        newAlphabet[board[nowR, nowC + 1] - 'A'] = true;

        Search(nowR, nowC + 1, len + 1, newAlphabet);
    }

    if (top) {
        bool[] newAlphabet = new bool[27];
        for (int i = 0; i < 27; i++) {
            if (alphabets[i]) newAlphabet[i] = true;
        }
        newAlphabet[board[nowR, nowC - 1] - 'A'] = true;

        Search(nowR, nowC - 1, len + 1, newAlphabet);
    }

    if (left) {
        bool[] newAlphabet = new bool[27];
        for (int i = 0; i < 27; i++) {
            if (alphabets[i]) newAlphabet[i] = true;
        }
        newAlphabet[board[nowR - 1, nowC] - 'A'] = true;

        Search(nowR - 1, nowC, len + 1, newAlphabet);
    }

    if (right) {
        bool[] newAlphabet = new bool[27];
        for (int i = 0; i < 27; i++) {
            if (alphabets[i]) newAlphabet[i] = true;
        }
        newAlphabet[board[nowR + 1, nowC] - 'A'] = true;
    
        Search(nowR + 1, nowC, len + 1, newAlphabet);
    }
}

bool[] cacheAlphabet = new bool[27];
cacheAlphabet[board[0, 0] - 'A'] = true;

Search(0, 0, 1, cacheAlphabet);

sw.WriteLine(answer);

sr.Close();
sw.Close();
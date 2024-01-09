StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');
string input;

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);
int K = int.Parse(inputs[2]);

bool[,] board = new bool[N, M];
int[,] blackLeftTop = new int[N, M];
int[,] whiteLeftTop = new int[N, M];

for (int i = 0; i < N; i++) {
    input = sr.ReadLine();

    for (int j = 0; j < M; j++) {
        if (input[j] == 'W') board[i, j] = true;
    }
}

for (int i = 0; i < N; i++) {
    for (int j = 0; j < M; j++) {
        int blackSum = 0, whiteSum = 0;

        if (board[i, j]) {
            if ((i + j) % 2 == 0) whiteSum += 1;
            else blackSum += 1;
        }
        else {
            if ((i + j) % 2 == 0) blackSum += 1;
            else whiteSum += 1;
        }

        if (i > 0) {
            blackSum += blackLeftTop[i - 1, j];
            whiteSum += whiteLeftTop[i - 1, j];
        }
        if (j > 0) {
            blackSum += blackLeftTop[i, j - 1];
            whiteSum += whiteLeftTop[i, j - 1];
        }
        if (i > 0 && j > 0) {
            blackSum -= blackLeftTop[i - 1, j - 1];
            whiteSum -= whiteLeftTop[i - 1, j - 1];
        }

        blackLeftTop[i, j] = blackSum;
        whiteLeftTop[i, j] = whiteSum;
    }
}

int answer = int.MaxValue;
for (int i = K - 1; i < N; i++) {
    for (int j = K - 1; j < M; j++) {
        int white = 0, black = 0;

        white = whiteLeftTop[i, j];
        black = blackLeftTop[i, j];

        if (i - K >= 0) {
            white -= whiteLeftTop[i - K, j];
            black -= blackLeftTop[i - K, j];
        }
        if (j - K >= 0) {
            white -= whiteLeftTop[i, j - K];
            black -= blackLeftTop[i, j - K];
        }
        if (i - K >= 0 && j - K >= 0) {
            white += whiteLeftTop[i - K, j - K];
            black += blackLeftTop[i - K, j - K];
        }
        
        if (white < answer) answer = white;
        if (black < answer) answer = black;
    }
}

sw.WriteLine(answer);

sr.Close();
sw.Close();
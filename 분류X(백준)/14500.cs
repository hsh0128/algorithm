int[,] tetromino = new int[19,8] { { 0, 0, 0, 1, 0, 2, 0, 3 }, { 0, 0, 1, 0, 2, 0, 3, 0 }, { 0, 0, 1, 0, 0, 1, 1, 1 }, { 0, 0, 1, 0, 2, 0, 2, 1 },
{ 0, 1, 1, 1, 2, 1, 2, 0 }, { 0, 0, 1, 0, 0, 1, 0, 2 }, { 0, 0, 0, 1, 0, 2, 1, 2 }, { 0, 0, 0, 1, 1, 1, 2, 1 },
{ 0, 0, 1, 0, 2, 0, 0, 1 }, { 1, 0, 1, 1, 1, 2, 0, 2 }, { 1, 0, 1, 1, 1, 2, 0, 0 }, { 0, 0, 0, 1, 1, 1, 1, 2 },
{ 1, 0, 1, 1, 0, 1, 0, 2 }, { 0, 1, 1, 1, 1, 0, 2, 0 }, { 0, 0, 1, 0, 1, 1, 2, 1 }, { 0, 1, 1, 1, 1, 0, 1, 2 },
{ 0, 0, 1, 0, 1, 1, 2, 0 }, { 0, 0, 0, 1, 0, 2, 1, 1 }, { 0, 1, 1, 0, 1, 1, 2, 1 } };

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

int[,] field = new int[N,M];

for(int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');
    
    for (int j = 0; j < M; j++) {
        field[i,j] = int.Parse(inputs[j]);
    }
}

int localSum, maxSum = 0;
bool inturrupted;

for (int i = 0; i < N; i++) {
    for (int j = 0; j < M; j++) {
        for (int k = 0; k < 19; k++) {
            localSum = 0;
            inturrupted = false;

            for (int l = 0; l < 8; l += 2) {
                if (tetromino[k, l] + i > N - 1 || tetromino[k, l+1] + j > M - 1) {
                    inturrupted = true;
                    break;
                }

                localSum += field[i + tetromino[k, l], j + tetromino[k, l+1]];
            }

            if (!inturrupted && localSum > maxSum) {
                maxSum = localSum;
            }
        }
    }
}

Console.WriteLine(maxSum);
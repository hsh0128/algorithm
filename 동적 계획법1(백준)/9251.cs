int[,] D = new int[1002, 1002];

string A = Console.ReadLine();
string B = Console.ReadLine();

int alen = A.Length;
int blen = B.Length;

int answer = 0;

for(int i = 1; i <= alen; i++) {

    char currentA = A[i - 1];
    int currentMax = 0;

    for (int j = 1; j <= blen; j++) {
        if (currentMax < D[i-1,j]) {
            currentMax = D[i-1,j];
        }

        if (B[j - 1] == currentA) {
            currentMax = D[i - 1, j - 1] + 1;

            if (currentMax > answer) {
                answer = currentMax;
            }
        }

        D[i, j] = currentMax;
    }
}

Console.WriteLine(answer);
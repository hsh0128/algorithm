int N = int.Parse(Console.ReadLine());

int[,] rgbGrid = new int[N,N];
bool[,] rbGird = new bool[N,N];

string input;

for (int i = 0; i < N; i++) {
    input = Console.ReadLine();

    for (int j = 0; j < N; j++) {
        switch(input[j]) {
            case 'R':
                rgbGrid[i,j] = 1;
                rbGird[i,j] = false;
                break;
            case 'G':
                rgbGrid[i,j] = 2;
                rbGird[i,j] = false;
                break;
            case 'B':
                rgbGrid[i,j] = 3;
                rbGird[i,j] = true;
                break;
            default:
                break;
        }
    }
}

bool[,] searched = new bool[N,N];

void searchRGB(int color, int x, int y) {
    if (searched[x,y]) return;
    if (color != rgbGrid[x, y]) return;

    searched[x,y] = true;

    if (x > 0)
        searchRGB(color, x - 1, y);
    if (x < N - 1)
        searchRGB(color, x + 1, y);
    if (y > 0)
        searchRGB(color, x, y - 1);
    if (y < N - 1)
        searchRGB(color, x, y + 1);
}

void searchRB(bool color, int x, int y) {
    if (searched[x, y]) return;
    if (color != rbGird[x, y]) return;

    searched[x, y] = true;

    if (x > 0)
        searchRB(color, x - 1, y);
    if (x < N - 1)
        searchRB(color, x + 1, y);
    if (y > 0)
        searchRB(color, x, y - 1);
    if (y < N - 1)
        searchRB(color, x, y + 1);
}

int answer1 = 0;
int answer2 = 0;

for(int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
        if (searched[i,j]) continue;

        answer1 += 1;
        searchRGB(rgbGrid[i,j], i, j);
    }
}

Array.Clear(searched);

for (int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
        if (searched[i,j]) continue;

        answer2 += 1;
        searchRB(rbGird[i,j], i, j);
    }
}

Console.Write(answer1.ToString() + " " + answer2.ToString());
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');
string input;

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

int redX = 0, redY = 0, blueX = 0, blueY = 0;

int[,] deltaPos = {{0, -1}, {-1, 0}, {0, 1}, {1, 0}};
int[,] board = new int[N, M];

for (int i = 0; i < N; i++) {
    input = sr.ReadLine();

    for (int j = 0; j < M; j++) {
        if (input[j] == '#') board[i, j] = 1;
        else if (input[j] == 'O') board[i, j] = 2;
        else if (input[j] == 'R') {
            redX = i;
            redY = j;
        }
        else if (input[j] == 'B') {
            blueX = i;
            blueY = j;
        }
    }
}

int answer = -1;

HashSet<Tuple<int, int, int, int>> searched = new HashSet<Tuple<int, int, int, int>>();

void MoveMarble(int deltaX, int deltaY, ref int moveX, ref int moveY) {
    while (true) {
        if (board[moveX + deltaX, moveY + deltaY] == 1) break;
        if (board[moveX + deltaX, moveY + deltaY] == 2) {
            moveX = 0;
            moveY = 0;
            break;
        }
        moveX += deltaX;
        moveY += deltaY;
    }
}

void MoveMarbleReferedOther(int deltaX, int deltaY, int refX, int refY, ref int moveX, ref int moveY) {
    while(true) {
        if (board[moveX + deltaX, moveY + deltaY] == 1) break;
        if (moveX + deltaX == refX && moveY + deltaY == refY) break;
        if (board[moveX + deltaX, moveY + deltaY] == 2) {
            moveX = 0;
            moveY = 0;
            break;
        }
        moveX += deltaX;
        moveY += deltaY;
    }
}

void Search(List<Tuple<int, int, int, int>> nowSearches, int depth) {
    if (depth > 9) return;

    List<Tuple<int, int, int, int>> nextSearch = new List<Tuple<int, int, int, int>>();

    foreach(Tuple<int, int, int, int> nowSearch in nowSearches) {
        int rx, ry, bx, by, dx, dy;

        for (int i = 0; i < 4; i++) {
            rx = nowSearch.Item1;
            ry = nowSearch.Item2;
            bx = nowSearch.Item3;
            by = nowSearch.Item4;

            dx = deltaPos[i, 0];
            dy = deltaPos[i, 1];

            bool startBlue = true;

            switch(i) {
                case 0:
                    if (ry < by) startBlue = false;
                    break;
                case 1:
                    if (rx < bx) startBlue = false;
                    break;
                case 2:
                    if (ry > by) startBlue = false;
                    break;
                case 3:
                    if (rx > bx) startBlue = false;
                    break;
            }

            if (startBlue) {
                MoveMarble(dx, dy, ref bx, ref by);
                if (bx == 0 && by == 0) continue;

                MoveMarbleReferedOther(dx, dy, bx, by, ref rx, ref ry);
                if (rx == 0 && ry == 0) {
                    answer = depth + 1;
                    return;
                }
            } else {
                MoveMarble(dx, dy, ref rx, ref ry);
                MoveMarbleReferedOther(dx, dy, rx, ry, ref bx, ref by);

                if (bx == 0 && by == 0) continue;

                if (rx == 0 && ry == 0) {
                    answer = depth + 1;
                    return;
                }
            }

            if (searched.Contains(new Tuple<int, int, int, int>(rx, ry, bx, by))) continue;

            searched.Add(new Tuple<int, int, int, int>(rx, ry, bx, by));
            nextSearch.Add(new Tuple<int, int, int, int>(rx, ry, bx, by));
        }
    }

    if (nextSearch.Count == 0) return;

    Search(nextSearch, depth + 1);
}

List<Tuple<int, int, int, int>> temp = new List<Tuple<int, int, int, int>>();
temp.Add(new Tuple<int, int, int, int>(redX, redY, blueX, blueY));

Search(temp, 0);

sw.WriteLine(answer);

sr.Close();
sw.Close();
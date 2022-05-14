using System.Text;

bool[,] board = new bool[6561,6561];

StringBuilder sb = new StringBuilder();

void recursive(int n, int index, int startX, int startY) {
    if (index == 4) {
        return;
    }

    if (n == 1) {
        board[startX, startY] = true;

        return;
    }

    for (int i = 0; i < 9; i++) {
        recursive(n / 3, i, startX + (n / 3) * (i / 3), startY + (n / 3) * (i % 3));
    }
}

int N = int.Parse(Console.ReadLine());

recursive(N, 0, 0, 0);

for (int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
        if (board[i,j]) {
            sb.Append('*');
        } else {
            sb.Append(' ');
        }
    }

    sb.Append('\n');
}

Console.Write(sb);
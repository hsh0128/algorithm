string[] inputs = Console.ReadLine().Split(' ');

int R = int.Parse(inputs[0]);
int C = int.Parse(inputs[1]);
int T = int.Parse(inputs[2]);

int[,] A = new int[C, R];

int firstpos = -1, secondpos = -1;

for (int i = 0; i < R; i++) {
    inputs = Console.ReadLine().Split(' ');
    
    for (int j = 0; j < C; j++) {
        A[j, i] = int.Parse(inputs[j]);

        if (A[j, i] == -1 && firstpos == -1) {
            firstpos = i;
            secondpos = i + 1;
        }
    }
}

int[,] diffusion() {
    int[,] diffuse = new int[C, R];

    for (int i = 0; i < R; i++) {
        for (int j = 0; j < C; j++) {
            if (A[j, i] <= 0) continue;

            if (j > 0 && A[j - 1, i] != -1) {
                diffuse[j - 1, i] += A[j, i] / 5;
                diffuse[j, i] -= A[j, i] / 5;
            }
            if (j < C - 1 && A[j + 1, i] != -1) {
                diffuse[j + 1, i] += A[j, i] / 5;
                diffuse[j, i] -= A[j, i] / 5;
            }
            if (i > 0 && A[j, i - 1] != -1) {
                diffuse[j, i - 1] += A[j, i] / 5;
                diffuse[j, i] -= A[j, i] / 5;
            }
            if (i < R - 1 && A[j, i + 1] != -1) {
                diffuse[j, i + 1] += A[j, i] / 5;
                diffuse[j, i] -= A[j, i] / 5;
            }
        }
    }

    return diffuse;
}

for (int i = 0; i < T; i++) {
    int[,] diffusionDelta = diffusion();

    for (int j = 0; j < R; j++) {
        for (int k = 0; k < C; k++) {
            A[k, j] += diffusionDelta[k, j];
        }
    }

    
    A[0, firstpos - 1] = 0;

    for (int j = firstpos - 1; j > 0; j--) {
        A[0, j] = A[0, j - 1];
    }

    for (int j = 0; j < C - 1; j++) {
        A[j, 0] = A[j + 1, 0];
    }

    for (int j = 0; j < firstpos; j++) {
        A[C - 1, j] = A[C - 1, j + 1];
    }

    for (int j = C - 1; j > 1; j--) {
        A[j, firstpos] = A[j - 1, firstpos];
    }

    A[1, firstpos] = 0;


    A[0, secondpos + 1] = 0;

    for (int j = secondpos + 1; j < R - 1; j++) {
        A[0, j] = A[0, j + 1];
    }

    for (int j = 0; j < C - 1; j++) {
        A[j, R - 1] = A[j + 1, R - 1];
    }

    for (int j = R - 1; j > secondpos; j--) {
        A[C - 1, j] = A[C - 1, j - 1];
    }

    for (int j = C - 1; j > 1; j--) {
        A[j, secondpos] = A[j - 1, secondpos];
    }

    A[1, secondpos] = 0;
}

int answer = 0;

for (int i = 0; i < R; i++) {
    for (int j = 0; j < C; j++) {
        if (A[j, i] > 0) answer += A[j, i];
    }
}

Console.WriteLine(answer);
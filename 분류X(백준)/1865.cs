StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int TC = int.Parse(sr.ReadLine());

for (int i = 0; i < TC; i++) {
    string[] inputs = sr.ReadLine().Split(' ');

    int N = int.Parse(inputs[0]);
    int M = int.Parse(inputs[1]);
    int W = int.Parse(inputs[2]);

    int[,] D = new int[N,N];

    for (int j = 0; j < N; j++) {
        for (int k = 0; k < N; k++) {
            if (j != k) D[j, k] = 9999999;
        }
    }

    int S, E, T;

    for (int j = 0; j < M; j++) {
        inputs = sr.ReadLine().Split(' ');

        S = int.Parse(inputs[0]) - 1;
        E = int.Parse(inputs[1]) - 1;
        T = int.Parse(inputs[2]);

        if (D[S, E] > T) D[S, E] = T;
        if (D[E, S] > T) D[E, S] = T;
    }

    for (int j = 0; j < W; j++) {
        inputs = sr.ReadLine().Split(' ');

        S = int.Parse(inputs[0]) - 1;
        E = int.Parse(inputs[1]) - 1;
        T = -int.Parse(inputs[2]);

        if (D[S, E] > T) D[S, E] = T;
    }

    for (int j = 0; j < N; j++) {
        for (int k = 0; k < N; k++) {
            for (int l = 0; l < N; l++) {
                if (D[k, l] > D[k, j] + D[j, l]) {
                    D[k, l] = D[k, j] + D[j, l];
                }
            }
        }
    }

    bool answer = false;

    for (int j = 0; j < N; j++) {
        if (D[j, j] < 0) {
            answer = true;
            break;
        }
    }

    if (answer) sw.WriteLine("YES");
    else sw.WriteLine("NO");
}

sr.Close();
sw.Close();
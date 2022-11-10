using System.Text;

StringBuilder sb = new StringBuilder();

int T = int.Parse(Console.ReadLine());
int n, nowMax, resultMax;
string[] inputs;

for (int i = 0; i < T; i++) {
    n = int.Parse(Console.ReadLine());
    int[,] s = new int[n, 2];
    int[,] D = new int[n, 2];

    inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < n; j++) {
        s[j, 0] = int.Parse(inputs[j]);
    }

    inputs = Console.ReadLine().Split(' ');

    for (int j = 0; j < n; j++) {
        s[j, 1] = int.Parse(inputs[j]);
    }

    D[0, 0] = s[0, 0];
    D[0, 1] = s[0, 1];

    if (n == 1) {
        sb.AppendLine(Math.Max(D[0, 0], D[0, 1]).ToString());
        continue;
    }

    D[1, 0] = D[0, 1] + s[1, 0];
    D[1, 1] = D[0, 0] + s[1, 1];

    for (int j = 2; j < n; j++) {
        for (int k = 0; k < 2; k++) {
            nowMax = D[j - 1, 1 - k];

            nowMax = nowMax < D[j - 2, 0] ? D[j - 2, 0] : nowMax;
            nowMax = nowMax < D[j - 2, 1] ? D[j - 2, 1] : nowMax;

            D[j, k] = nowMax + s[j, k];
        }
    }

    resultMax = D[n - 1, 0];

    resultMax = resultMax < D[n - 1, 1] ? D[n - 1, 1] : resultMax;
    resultMax = resultMax < D[n - 2, 0] ? D[n - 2, 0] : resultMax;
    resultMax = resultMax < D[n - 2, 1] ? D[n - 2, 1] : resultMax;

    sb.AppendLine(resultMax.ToString());
}

Console.Write(sb);
using System.Text;

int gcd(int a, int b) {
    if (b > a) {
        int temp = a;
        a = b;
        b = temp;
    }
    if (b == 0) return a;

    return gcd(b, a % b);
}

int T = int.Parse(Console.ReadLine());

string[] inputs;
int M, N, x, y, nowGCD, targetDelta, nowDelta, answer, nowX, nowY, LCM;

StringBuilder sb = new StringBuilder();

for (int i = 0; i < T; i++) {
    inputs = Console.ReadLine().Split(' ');

    M = int.Parse(inputs[0]);
    N = int.Parse(inputs[1]);
    x = int.Parse(inputs[2]);
    y = int.Parse(inputs[3]);

    nowGCD = gcd(M, N);
    LCM = N * M / nowGCD;
    targetDelta = x - y;

    if (Math.Abs(targetDelta) % nowGCD != 0) {
        sb.AppendLine("-1");
        continue;
    }

    if (M == N && x != y) {
        sb.AppendLine("-1");
        continue;
    }

    nowX = 1;
    nowY = 1;
    answer = 1;

    while(true) {
        if (nowX == x && nowY == y) {
            sb.AppendLine(answer.ToString());
            break;
        }

        if (answer > LCM) {
            sb.AppendLine("-1");
            break;
        }

        nowDelta = nowX - nowY;

        if (nowDelta == targetDelta) {
            nowX += 1;
            if (nowX > M) nowX -= M;

            nowY += 1;
            if (nowY > N) nowY -= N;

            answer += 1;
            
            continue;
        }

        int nextPlus = M - nowX > N - nowY ? N - nowY + 1 : M - nowX + 1;

        if (nextPlus <= 0) nextPlus = 1;

        nowX += nextPlus;
        if (nowX > M) nowX -= M;

        nowY += nextPlus;
        if (nowY > N) nowY -= N;

        answer += nextPlus;
    }
}

Console.Write(sb);
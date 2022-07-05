using System.Text;

int CalculateGCD(int a, int b) {
    if (a < 0) {
        Console.WriteLine("ERROR");
        return -1;
    }
    if (b < 0) {
        Console.WriteLine("ERROR");
        return -1;
    }

    if (a < b) {
        int cache = a;
        a = b;
        b = cache;
    }

    if (b == 0) {
        return a;
    }

    return CalculateGCD(a - b, b);
}

List<int> numbers = new List<int>();

int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++) {
    numbers.Add(int.Parse(Console.ReadLine()));
}

numbers.Sort(delegate(int x, int y) {
    return x - y;
});

bool gcdIsEmpty = true;
int nowgcd = -1;
int current;

for (int i = N - 1; i >= 1; i--) {
    for (int j = i - 1; j >= 0; j--) {
        current = numbers[i] - numbers[j];

        if (gcdIsEmpty) {
            nowgcd = current;
            gcdIsEmpty = false;
            continue;
        }

        nowgcd = CalculateGCD(nowgcd, current);
    }
}

StringBuilder sb = new StringBuilder();

for (int i = 2; i <= nowgcd; i++) {
    if (nowgcd % i == 0) {
        sb.AppendLine(i.ToString());
    }
}

Console.Write(sb);
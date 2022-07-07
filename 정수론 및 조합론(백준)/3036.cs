using System.Text;

int CalculateGCD(int a, int b) {
    if (b > a) {
        int cache = a;
        a = b;
        b = cache;
    }

    if (b == 0) {
        return a;
    }

    return CalculateGCD(a % b, b);
}

int N = int.Parse(Console.ReadLine());

string[] inputs = Console.ReadLine().Split(' ');

StringBuilder sb = new StringBuilder();

int firstRing = int.Parse(inputs[0]);
int currentRing;
int currentGCD;

for (int i = 1; i < N; i++) {
    currentRing = int.Parse(inputs[i]);

    currentGCD = CalculateGCD(firstRing, currentRing);

    sb.AppendLine((firstRing / currentGCD).ToString() + "/" + (currentRing / currentGCD).ToString());
}

Console.Write(sb);
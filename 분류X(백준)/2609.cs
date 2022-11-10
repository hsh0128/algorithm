string[] inputs = Console.ReadLine().Split(' ');

int calculateGCD(int a, int b) {
    if (a < b) {
        int temp = b;
        b = a;
        a = temp;
    }

    if (b == 0) return a;

    return calculateGCD(b, a % b);
}

int n = int.Parse(inputs[0]);
int m = int.Parse(inputs[1]);

int gcd = calculateGCD(n, m);

Console.WriteLine(gcd);
Console.WriteLine(n * m / gcd);
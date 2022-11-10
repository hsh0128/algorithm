string[] inputs = Console.ReadLine().Split(' ');

long A = long.Parse(inputs[0]);
long B = long.Parse(inputs[1]);
long C = long.Parse(inputs[2]);

long pow(long a, long b) {
    if (b == 0) return 1;
    if (b == 1) return a % C;

    if (b % 2 == 0) {
        long cache = pow(a, b / 2);
        return (cache * cache) % C;
    }

    return ((a % C) * pow(a, b - 1) % C) % C;
}

Console.WriteLine(pow(A, B));
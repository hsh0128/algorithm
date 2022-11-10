int N = int.Parse(Console.ReadLine());

int[] D = new int[10007];

int recursive(int remain) {
    if (remain < 0) return 0;
    if (remain == 0) return 1;

    if (D[remain] == 0) D[remain] = ((recursive(remain - 2) * 2) % 10007 + recursive(remain - 1) % 10007) % 10007;

    return D[remain];
}

Console.WriteLine(recursive(N));
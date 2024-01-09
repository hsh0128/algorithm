StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

int[] D = new int[N + 1];

int fib(int num) {
    D[1] = 1;
    D[2] = 1;

    for (int i = 3; i <= num; i++) {
        D[i] = D[i - 1] + D[i - 2];
    }

    return D[num];
}

sw.Write(fib(N));
sw.Write(' ');
sw.Write(N - 2);

sr.Close();
sw.Close();
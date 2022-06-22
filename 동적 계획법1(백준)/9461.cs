ulong[] D = new ulong[101];
int cache;

D[1] = 1;
D[2] = 1;
D[3] = 1;
D[4] = 2;
D[5] = 2;

int T = int.Parse(Console.ReadLine());

Queue<ulong> answer = new Queue<ulong>();

for (int i = 0; i < T; i++) {
    cache = int.Parse(Console.ReadLine());

    answer.Enqueue(getLength(cache));
}

ulong getLength(int n) {
    if (D[n] != 0) {
        return D[n];
    }

    D[n] = getLength(n - 1) + getLength(n - 5);

    return D[n];
}

foreach(ulong a in answer) {
    Console.WriteLine(a);
}
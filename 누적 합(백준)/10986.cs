string[] inputmn = Console.ReadLine().Split(' ');

int N = int.Parse(inputmn[0]);
int M = int.Parse(inputmn[1]);

Dictionary<int, int> D = new Dictionary<int, int>();

string[] inputs = Console.ReadLine().Split(' ');

int cache, previousSum;

cache = int.Parse(inputs[0]);
cache %= M;
D[cache] = 1;
previousSum = cache;

for (int i = 1; i < N; i++) {
    cache = int.Parse(inputs[i]);
    cache += previousSum;
    cache %= M;

    if (!D.ContainsKey(cache)) {
        D[cache] = 1;
    } else {
        D[cache] += 1;
    }

    previousSum = cache;
}

long answer = 0;

foreach(KeyValuePair<int, int> i in D) {
    if (i.Key == 0) {
        answer += (long)i.Value;
    }

    answer += (long)i.Value * (long)(i.Value - 1) / 2;
}

Console.WriteLine(answer);
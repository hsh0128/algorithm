List<long> path = new List<long>();
List<long> cities = new List<long>();

int N = int.Parse(Console.ReadLine());

string[] inputs = Console.ReadLine().Split();

for (int i = 0; i < N - 1; i++) {
    path.Add(long.Parse(inputs[i]));
}

inputs = Console.ReadLine().Split();

for (int i = 0; i < N; i++) {
    cities.Add(long.Parse(inputs[i]));
}

long minCost = cities[0];
long answer = 0;

for (int i = 0; i < N - 1; i++) {
    if (minCost > cities[i]) {
        minCost = cities[i];
    }

    answer += (path[i] * minCost);
}

Console.WriteLine(answer);
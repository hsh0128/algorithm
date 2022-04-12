// float는 부정확한 경우가 많다. double을 사용하기!
using System;

List<int> numbers = new List<int>();
List<int> maxUnique = new List<int>();
Dictionary<int, int> unique = new Dictionary<int, int>();

int cache, maxCount = 0;
double sum = 0, meanCache;
int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++) {
    cache = int.Parse(Console.ReadLine());

    numbers.Add(cache);
    sum += (double)cache;
    if (unique.ContainsKey(cache)) {
        unique[cache] += 1;
    } else {
        unique.Add(cache, 1);
    }
}

foreach(KeyValuePair<int, int> i in unique) {
    if (i.Value > maxCount) {
        maxUnique.Clear();
        maxUnique.Add(i.Key);
        maxCount = i.Value;
        continue;
    }
    if (i.Value == maxCount) {
        maxUnique.Add(i.Key);
        continue;
    }
}

numbers.Sort();
maxUnique.Sort();

meanCache = Math.Round(sum / (double)N);

if (meanCache == -0) {
    meanCache = 0;
}

Console.WriteLine(meanCache);
Console.WriteLine(numbers[N/2]);
if (maxUnique.Count() > 1) {
    Console.WriteLine(maxUnique[1]);
} else {
    Console.WriteLine(maxUnique[0]);
}
Console.WriteLine(numbers[N-1] - numbers[0]);
using System.Collections.Generic;

List<int> answer = new List<int>();

int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++) {
    answer.Add(int.Parse(Console.ReadLine()));
}

answer.Sort();

foreach(int i in answer) {
    Console.WriteLine(i);
}
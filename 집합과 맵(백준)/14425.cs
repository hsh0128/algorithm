SortedSet<string> mySet = new SortedSet<string>();
int answer = 0;
string tempString;

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int M = int.Parse(inputs[1]);

for (int i = 0; i < N; i++) {
    mySet.Add(Console.ReadLine());
}

for (int i = 0; i < M; i++) {
    tempString = Console.ReadLine();

    if (mySet.Contains(tempString)) {
        answer += 1;
    }
}

Console.WriteLine(answer);
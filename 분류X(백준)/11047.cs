Stack<int> A = new Stack<int>();

string[] inputs = Console.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int K = int.Parse(inputs[1]);

int cache;

for (int i = 0; i < N; i++) {
    cache = int.Parse(Console.ReadLine());
    A.Push(cache);
}

int sum = 0, answer = 0;

while(sum < K) {
    cache = A.Pop();

    while(sum + cache <= K) {
        sum += cache;
        answer += 1;
    }
}

Console.WriteLine(answer);
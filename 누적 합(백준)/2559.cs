List<int> numbers = new List<int>();

string[] inputnk = Console.ReadLine().Split(' ');

int N = int.Parse(inputnk[0]);
int K = int.Parse(inputnk[1]);

string[] inputs = Console.ReadLine().Split(' ');

int current;

int MAX = -10000000;
int currentSum = 0;

for (int i = 0; i < N; i++) {
    current = int.Parse(inputs[i]);
    
    numbers.Add(current);

    currentSum += current;

    if (i + 1 == K) {
        MAX = currentSum;
    }

    if (i >= K) {
        currentSum -= numbers[i - K];

        if (currentSum > MAX) {
            MAX = currentSum;
        }
    }
}

Console.WriteLine(MAX);
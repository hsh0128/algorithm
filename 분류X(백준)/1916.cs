StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int N = int.Parse(sr.ReadLine());
int M = int.Parse(sr.ReadLine());

int[,] D = new int[N,N];
int first, second, length;
string[] inputs;

for (int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
        D[i, j] = 100000001;
    }
}

for (int i = 0; i < M; i++) {
    inputs = sr.ReadLine().Split(' ');

    first = int.Parse(inputs[0]) - 1;
    second = int.Parse(inputs[1]) - 1;
    length = int.Parse(inputs[2]);

    if (D[first,second] > length)
        D[first, second] = length;
}

int targetStart, targetDest;

inputs = sr.ReadLine().Split(' ');

targetStart = int.Parse(inputs[0]) - 1;
targetDest = int.Parse(inputs[1]) - 1;

bool[] searched = new bool[N];
searched[targetStart] = true;

while(true) {
    int minIndex = -1;
    int minValue = 100000001;

    for (int i = 0; i < N; i++) {
        if (searched[i]) continue;

        if (D[targetStart, i] < minValue) {
            minIndex = i;
            minValue = D[targetStart, i];
        }
    }

    if (minIndex == -1) break;

    for (int i = 0; i < N; i++) {
        if (minIndex == i) continue;
        

        if (D[targetStart, minIndex] + D[minIndex, i] < D[targetStart, i]) {
            D[targetStart, i] = D[targetStart, minIndex] + D[minIndex, i];
        }
    }
    searched[minIndex] = true;
}


sw.WriteLine(D[targetStart, targetDest]);

sr.Close();
sw.Close();
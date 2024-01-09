StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int A = int.Parse(inputs[0]);
int B = int.Parse(inputs[1]);

HashSet<int> setA = new HashSet<int>();
inputs = sr.ReadLine().Split(' ');

for (int i = 0; i < A; i++) {
    setA.Add(int.Parse(inputs[i]));
}

HashSet<int> setB = new HashSet<int>();
inputs = sr.ReadLine().Split(' ');

for (int i = 0; i < B; i++) {
    setB.Add(int.Parse(inputs[i]));
}

int answer = 0;

foreach(int i in setA) {
    if (!setB.Contains(i)) answer += 1;
}

foreach(int i in setB) {
    if (!setA.Contains(i)) answer += 1;
}

sw.WriteLine(answer);

sr.Close();
sw.Close();
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int S = int.Parse(inputs[1]);

int[] seq = new int[N];
inputs = sr.ReadLine().Split(' '); 

for (int i = 0; i < N; i++) {
    seq[i] = int.Parse(inputs[i]);
}

int start = 0, end = 0, answer = int.MaxValue, nowSum = 0;

while(true) {
    if (nowSum >= S) {
        if (answer > end - start) answer = end - start;

        nowSum -= seq[start];
        start += 1;
    } else {
        if (end == N) break;

        nowSum += seq[end];
        end += 1;
    }
}

if (answer == int.MaxValue) sw.WriteLine("0");
else sw.WriteLine(answer);

sr.Close();
sw.Close();
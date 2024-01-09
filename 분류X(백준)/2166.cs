StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

List<KeyValuePair<double, double>> points = new List<KeyValuePair<double, double>>();
string[] inputs;

for (int i = 0; i < N; i++) {
    inputs = sr.ReadLine().Split(' ');

    points.Add(new KeyValuePair<double, double>(double.Parse(inputs[0]), double.Parse(inputs[1])));
}

double answer = 0;

for (int i = 2; i < N; i++) {
    KeyValuePair<double, double> vecA, vecB;

    vecA = new KeyValuePair<double, double>(points[i - 1].Key - points[0].Key, points[i - 1].Value - points[0].Value);
    vecB = new KeyValuePair<double, double>(points[i].Key - points[0].Key, points[i].Value - points[0].Value);

    double size = vecA.Key * vecB.Value - vecA.Value * vecB.Key;

    answer += size / 2;
}

answer = Math.Abs(answer);

sw.WriteLine(answer.ToString("0.0"));

sr.Close();
sw.Close();
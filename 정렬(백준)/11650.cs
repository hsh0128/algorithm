using System.Text;

List<KeyValuePair<int, int> > points = new List<KeyValuePair<int, int>>();
string[] inputs;
StringBuilder sb = new StringBuilder();

int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    points.Add(new KeyValuePair<int, int>(int.Parse(inputs[0]), int.Parse(inputs[1])));
}

points.Sort(delegate (KeyValuePair<int, int> x, KeyValuePair<int, int> y) {
    if (x.Key == y.Key)
        return x.Value - y.Value;
    return x.Key - y.Key;
});

for (int i = 0; i < points.Count; i++) {
    sb.Append(points[i].Key);
    sb.Append(' ');
    sb.Append(points[i].Value);
    sb.Append('\n');
}

Console.Write(sb);
using System.Text;

// Key: age, Value: index
List<KeyValuePair<int, int> > members = new List<KeyValuePair<int, int>>();
List<string> names = new List<string>();
string[] inputs;
StringBuilder sb = new StringBuilder();

int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    members.Add(new KeyValuePair<int, int>(int.Parse(inputs[0]), i));
    names.Add(inputs[1]);
}

members.Sort(delegate (KeyValuePair<int, int> x, KeyValuePair<int, int> y) {
    if (x.Key == y.Key)
        return x.Value - y.Value;
    return x.Key - y.Key;
});

for (int i = 0; i < members.Count; i++) {
    sb.Append(members[i].Key);
    sb.Append(' ');
    sb.Append(names[members[i].Value]);
    sb.Append('\n');
}

Console.Write(sb);
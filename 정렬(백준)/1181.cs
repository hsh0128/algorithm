using System.Text;

List<string> words = new List<string>();
string cache;
StringBuilder sb = new StringBuilder();

int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++) {
    cache = Console.ReadLine();

    if (!words.Contains(cache))
        words.Add(cache);
}

words.Sort(delegate (string x, string y) {
    if (x.Length == y.Length)
        return String.Compare(x, y);
    return x.Length - y.Length;
});

for (int i = 0; i < words.Count; i++) {
    sb.AppendLine(words[i]);
}

Console.Write(sb);
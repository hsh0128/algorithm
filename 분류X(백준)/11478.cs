StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string S = sr.ReadLine();

int len = S.Length;
string sub;
HashSet<string> set = new HashSet<string>();

for (int i = 0; i < len; i++) {
    for (int j = i; j < len; j++) {
        sub = S.Substring(i, j - i + 1);

        if (!set.Contains(sub)) set.Add(sub);
    }
}

sw.WriteLine(set.Count);

sr.Close();
sw.Close();
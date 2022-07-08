using System.Text;

Dictionary<string, int> clothes = new Dictionary<string, int>();
StringBuilder sb = new StringBuilder();

int T = int.Parse(Console.ReadLine());
int n;
string[] cache;
int answer;

for (int i = 0; i < T; i++) {
    clothes.Clear();
    answer = 1;

    n = int.Parse(Console.ReadLine());

    for (int j = 0; j < n; j++) {
        cache = Console.ReadLine().Split(' ');

        if (!clothes.ContainsKey(cache[1])) {
            clothes[cache[1]] = 1;
        } else {
            clothes[cache[1]] += 1;
        }
    }

    foreach(KeyValuePair<string, int> k in clothes) {
        answer *= k.Value + 1;
    }
    answer -= 1;

    sb.AppendLine(answer.ToString());
}

Console.Write(sb);
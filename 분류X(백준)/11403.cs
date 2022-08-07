using System.Text;

int N = int.Parse(Console.ReadLine());

string[] inputs;

List<int>[] connection = new List<int>[N];

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');
    connection[i] = new List<int>();

    for (int j = 0; j < N; j++) {
        if (inputs[j] == "1") {
            connection[i].Add(j);
        }
    }
}



bool[] visited = new bool[N];

void search(List<int> nowSearch) {
    List<int> nextSearch = new List<int>();

    foreach(int i in nowSearch) {
        foreach(int j in connection[i]) {
            if (visited[j]) continue;

            visited[j] = true;
            nextSearch.Add(j);
        }
    }

    if (nextSearch.Count > 0)
        search(nextSearch);
}

StringBuilder sb = new StringBuilder();

for (int i = 0; i < N; i++) {
    Array.Clear(visited);

    List<int> startarr = new List<int>();
    startarr.Add(i);
    
    search(startarr);

    for (int j = 0; j < N; j++) {
        if (visited[j]) sb.Append('1');
        else sb.Append('0');

        if (j == N - 1) sb.Append('\n');
        else sb.Append(' ');
    }
}

Console.Write(sb);
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int T = int.Parse(sr.ReadLine());

for (int i = 0; i < T; i++) {
    int N = int.Parse(sr.ReadLine());

    string[] inputs = sr.ReadLine().Split(' ');

    List<int> numbers = new List<int>();
    Dictionary<int, List<int>> connection = new Dictionary<int, List<int>>();
    int[] counts = new int[N + 1];

    for (int j = 1; j <= N; j++) {
        connection.Add(j, new List<int>());
    }

    for (int j = 0; j < N; j++) {
        int now = int.Parse(inputs[j]);

        foreach(int num in numbers) {
            connection[num].Add(now);
            counts[now] += 1;
        }
        numbers.Add(now);
    }

    int M = int.Parse(sr.ReadLine());

    int first, second;

    for (int j = 0; j < M; j++) {
        inputs = sr.ReadLine().Split(' ');

        first = int.Parse(inputs[0]);
        second = int.Parse(inputs[1]);

        if (connection[first].Contains(second)) {
            connection[first].Remove(second);
            connection[second].Add(first);

            counts[first] += 1;
            counts[second] -= 1;
        } else {
            connection[second].Remove(first);
            connection[first].Add(second);

            counts[second] += 1;
            counts[first] -= 1;
        }
    }

    PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
    List<int> answers = new List<int>();
    bool overlapped = false;

    for (int j = 1; j <= N; j++) {
        if (counts[j] == 0) pq.Enqueue(j, j);
    }

    while(pq.Count > 0) {
        if (pq.Count != 1) {
            overlapped = true;
            break;
        }

        int now = pq.Dequeue();

        answers.Add(now);

        if (!connection.ContainsKey(now)) continue;

        foreach(int num in connection[now]) {
            counts[num] -= 1;

            if (counts[num] == 0) {
                pq.Enqueue(num, num);
            }
        }
    }

    if (overlapped) {
        sw.WriteLine("?");
    }
    else if (answers.Count != N) {
        sw.WriteLine("IMPOSSIBLE");
    } else {
        foreach(int num in answers) {
            sw.Write(num);
            sw.Write(' ');
        }
        sw.Write('\n');
    }
}

sr.Close();
sw.Close();
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int T = int.Parse(sr.ReadLine());
string[] inputs;

for (int i = 0; i < T; i++) {
    int n = int.Parse(sr.ReadLine());
    int count = n;

    int[] s = new int[n];
    int[] depth = new int[n];
    bool[] searched = new bool[n];
    inputs = sr.ReadLine().Split(' ');

    for (int j = 0; j < n; j++) {
        s[j] = int.Parse(inputs[j]) - 1;
    }

    for (int j = 0; j < n; j++) {
        if (searched[j]) continue;

        int nowNode = j;
        int nowDepth = 0;
        HashSet<int> path = new HashSet<int>();

        while(true) {
            nowDepth += 1;

            if (path.Contains(nowNode)) {
                count -= (nowDepth - depth[nowNode]);
                break;
            }

            if (searched[nowNode]) break;

            path.Add(nowNode);
            searched[nowNode] = true;
            depth[nowNode] = nowDepth;

            nowNode = s[nowNode];
        }
    }

    sw.WriteLine(count);
}

sr.Close();
sw.Close();
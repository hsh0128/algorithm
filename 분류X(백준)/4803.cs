StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs;
int caseIdx = 0;

while(true) {
    caseIdx += 1;
    inputs = sr.ReadLine().Split(' ');

    int N = int.Parse(inputs[0]);
    int M = int.Parse(inputs[1]);

    if (N == 0 && M == 0) break;

    Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();

    for (int i = 0; i < N; i++) {
        edges.Add(i, new List<int>());
    }

    for (int i = 0; i < M; i++) {
        inputs = sr.ReadLine().Split(' ');

        int first = int.Parse(inputs[0]) - 1;
        int second = int.Parse(inputs[1]) - 1;

        edges[first].Add(second);
        edges[second].Add(first);
    }

    int answer = 0;
    bool[] searched = new bool[N];

    bool Search(int prevIdx, int nowIdx) {
        if (searched[nowIdx]) return false;

        searched[nowIdx] = true;
        bool flag = true;

        foreach(int i in edges[nowIdx]) {
            if (i == prevIdx) continue;

            if (!Search(nowIdx, i)) flag = false;
        }

        return flag;
    }

    for (int i = 0; i < N; i++) {
        if (searched[i]) continue;

        bool isTree = Search(-1, i);

        if (isTree) answer += 1;
    }

    if (answer >= 2) {
        sw.WriteLine(string.Format("Case {0}: A forest of {1} trees.", caseIdx, answer));
    } else if (answer == 1) {
        sw.WriteLine(string.Format("Case {0}: There is one tree.", caseIdx));
    } else {
        sw.WriteLine(string.Format("Case {0}: No trees.", caseIdx));
    }
}

sr.Close();
sw.Close();
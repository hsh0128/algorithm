StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

int[,] D = new int[N,N];
string[] inputs;

for (int i = 0; i < N; i++) {
    inputs = sr.ReadLine().Split(' ');

    for (int j = 0; j < N; j++) {
        D[i, j] = int.Parse(inputs[j]);
    }
}

int answer = int.MaxValue;

void Search(int idx, bool[] isStartTeam, int startTeamCount) {
    if (idx == N) {
        if (startTeamCount != N / 2) return;

        List<int> startTeam = new List<int>();
        List<int> linkTeam = new List<int>();
        int startScore = 0, linkScore = 0;

        for (int i = 0; i < N; i++) {
            if (isStartTeam[i]) {
                foreach(int j in startTeam) {
                    startScore += D[j, i];
                    startScore += D[i, j];
                }

                startTeam.Add(i);
            }
            else {
                foreach(int j in linkTeam) {
                    linkScore += D[j, i];
                    linkScore += D[i, j];
                }

                linkTeam.Add(i);
            }
        }

        if (answer > Math.Abs(startScore - linkScore)) answer = Math.Abs (startScore - linkScore);

        return;
    }

    bool[] path1 = new bool[idx + 1];
    bool[] path2 = new bool[idx + 1];

    for (int i = 0; i < idx; i++) {
        path1[i] = isStartTeam[i];
        path2[i] = isStartTeam[i];
    }
    path2[idx] = true;

    Search(idx + 1, path1, startTeamCount);
    Search(idx + 1, path2, startTeamCount + 1);
}

Search(0, new bool[0], 0);

sw.WriteLine(answer);

sr.Close();
sw.Close();
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] inputs = sr.ReadLine().Split(' ');

int N = int.Parse(inputs[0]);
int K = int.Parse(inputs[1]);

int MAXINT = Math.Max(N, K * 2);
bool[] searched = new bool[MAXINT + 1];
int step = 0;

void Search(List<int> nowSearch) {
    List<int> nextSearch = new List<int>();

    foreach(int i in nowSearch) {
        if (i == K) return;

        int temp = i - 1;

        while(true) {
            if (temp < 0) break;
            if (temp > MAXINT) break;
            if (searched[temp]) break;

            nextSearch.Add(temp);
            searched[temp] = true;
            temp *= 2;
        }

        temp = i + 1;

        while(true) {
            if (temp < 0) break;
            if (temp > MAXINT) break;
            if (searched[temp]) break;

            nextSearch.Add(temp);
            searched[temp] = true;
            temp *= 2;
        }
    }

    step += 1;
    Search(nextSearch);
}

List<int> temp = new List<int>();

int temp2 = N;

while(true) {
    if (temp2 < 0) break;
    if (temp2 > MAXINT) break;
    if (searched[temp2]) break;
    
    temp.Add(temp2);
    searched[temp2] = true;
    temp2 *= 2;
}

Search(temp);

sw.WriteLine(step);

sr.Close();
sw.Close();
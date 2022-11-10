StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

bool[] searched = new bool[N + 1];
int answer = 0;
List<int> answerPath = new List<int>();

void Search(List<KeyValuePair<int, List<int>>> nowSearch) {
    List<KeyValuePair<int, List<int>>> nextSearch = new List<KeyValuePair<int, List<int>>>();

    foreach(KeyValuePair<int, List<int>> i in nowSearch) {
        if (i.Key == 1) {
            foreach(int j in i.Value) {
                answerPath.Add(j);
            }
            return;
        }

        if (i.Key % 3 == 0 && !searched[i.Key / 3]) {
            searched[i.Key / 3] = true;
            
            List<int> path = new List<int>();
            foreach(int j in i.Value) {
                path.Add(j);
            }
            path.Add(i.Key / 3);

            nextSearch.Add(new KeyValuePair<int, List<int>>(i.Key / 3, path));
        }
        if (i.Key % 2 == 0 && !searched[i.Key / 2]) {
            searched[i.Key / 2] = true;

            List<int> path = new List<int>();
            foreach(int j in i.Value) {
                path.Add(j);
            }
            path.Add(i.Key / 2);

            nextSearch.Add(new KeyValuePair<int, List<int>>(i.Key / 2, path));
        }
        if (i.Key > 1 && !searched[i.Key - 1]) {
            searched[i.Key - 1] = true;

            List<int> path = new List<int>();
            foreach(int j in i.Value) {
                path.Add(j);
            }
            path.Add(i.Key - 1);

            nextSearch.Add(new KeyValuePair<int, List<int>>(i.Key - 1, path));
        }
    }

    answer += 1;
    Search(nextSearch);
}

List<KeyValuePair<int, List<int>>> temp = new List<KeyValuePair<int, List<int>>>();
List<int> tempPath = new List<int>();
tempPath.Add(N);

temp.Add(new KeyValuePair<int, List<int>>(N, tempPath));
searched[N] = true;

Search(temp);

sw.WriteLine(answer);
int answerLen = answerPath.Count();
for (int i = 0; i < answerLen; i++) {
    sw.Write(answerPath[i]);
    if (i != answerLen - 1) sw.Write(' ');
}

sr.Close();
sw.Close();
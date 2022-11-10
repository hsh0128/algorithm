using System.Text;

int N = int.Parse(Console.ReadLine());
string input;

bool[,] map = new bool[N,N];
bool[,] searched = new bool[N,N];

for (int i = 0; i < N; i++) {
    input = Console.ReadLine();

    for (int j = 0; j < N; j++) {
        if (input[j] == '1') {
            map[i,j] = true;
        }
    }
}

int count = 0, answerCnt;
List<int> answers = new List<int>();

for (int i = 0; i < N; i++) {
    for (int j = 0; j < N; j++) {
        if (map[i,j] && !searched[i,j]) {
            count += 1;

            List<KeyValuePair<int, int>> nowSearch = new List<KeyValuePair<int, int>>();
            nowSearch.Add(new KeyValuePair<int, int>(i,j));
            searched[i,j] = true;
            answerCnt = 1;

            while(nowSearch.Count > 0) {
                List<KeyValuePair<int, int>> nextSearch = new List<KeyValuePair<int, int>>();

                foreach(KeyValuePair<int, int> k in nowSearch) {
                    if (k.Key > 0 && map[k.Key - 1, k.Value] && !searched[k.Key - 1, k.Value]) {
                        searched[k.Key - 1, k.Value] = true;
                        nextSearch.Add(new KeyValuePair<int, int>(k.Key - 1, k.Value));
                        answerCnt += 1;
                    }

                    if (k.Key < N - 1 && map[k.Key + 1, k.Value] && !searched[k.Key + 1, k.Value]) {
                        searched[k.Key + 1, k.Value] = true;
                        nextSearch.Add(new KeyValuePair<int, int>(k.Key + 1, k.Value));
                        answerCnt += 1;
                    }

                    if (k.Value > 0 && map[k.Key, k.Value - 1] && !searched[k.Key, k.Value - 1]) {
                        searched[k.Key, k.Value - 1] = true;
                        nextSearch.Add(new KeyValuePair<int, int>(k.Key, k.Value - 1));
                        answerCnt += 1;
                    }

                    if (k.Value < N - 1 && map[k.Key, k.Value + 1] && !searched[k.Key, k.Value + 1]) {
                        searched[k.Key, k.Value + 1] = true;
                        nextSearch.Add(new KeyValuePair<int, int>(k.Key, k.Value + 1));
                        answerCnt += 1;
                    }
                }

                nowSearch = nextSearch;
            }

            answers.Add(answerCnt);
        }
    }
}

StringBuilder sb = new StringBuilder();

sb.AppendLine(count.ToString());

answers.Sort();

foreach(int i in answers) {
    sb.AppendLine(i.ToString());
}

Console.Write(sb);
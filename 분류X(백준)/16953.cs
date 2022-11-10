string[] inputs = Console.ReadLine().Split(' ');

long A = long.Parse(inputs[0]);
long B = long.Parse(inputs[1]);

bool[] searched = new bool[B];

List<long> nowSearch = new List<long>();
nowSearch.Add(A);

int step = 1;
bool foundAnswer = false;

while(nowSearch.Count > 0) {
    List<long> nextSearch = new List<long>();

    foreach(long i in nowSearch) {
        if (foundAnswer) break;
        for (int j = 0; j < 2; j++) {
            if (foundAnswer) break;
            switch(j) {
                case 0:
                    if (i * 2 > B) continue;
                    if (i * 2 == B) {
                        foundAnswer = true;
                        continue;
                    }
                    if (searched[i * 2]) continue;

                    searched[i * 2] = true;
                    nextSearch.Add(i * 2);                    
                    break;
                case 1:
                    if (i * 10 + 1 > B) continue;
                    if (i * 10 + 1 == B) {
                        foundAnswer = true;
                        continue;
                    }
                    if (searched[i * 10 + 1]) continue;

                    searched[i * 10 + 1] = true;
                    nextSearch.Add(i * 10 + 1);
                    break;
            }
        }
        
    }

    step += 1;

    if (foundAnswer) break;

    nowSearch = nextSearch;
}

if (foundAnswer) Console.WriteLine(step);
else Console.WriteLine("-1");
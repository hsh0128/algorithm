string[] inputs = Console.ReadLine().Split(' ');

int M = int.Parse(inputs[0]);
int N = int.Parse(inputs[1]);
int H = int.Parse(inputs[2]);

int[,,] box = new int[M,N,H];
bool[,,] searched = new bool[M,N,H];

int cache, count = 0;

List<int[]> originPositions = new List<int[]>();

for (int i = 0; i < H; i++) {
    for (int j = 0; j < N; j++) {
        inputs = Console.ReadLine().Split(' ');

        for (int k = 0; k < M; k++) {
            cache = int.Parse(inputs[k]);

            if (cache == 0) {
                count += 1;
            } else if (cache == 1) {
                int[] chpos = new int[3];
                chpos[0] = k;
                chpos[1] = j;
                chpos[2] = i;
                originPositions.Add(chpos);
                searched[k,j,i] = true;
            }

            box[k,j,i] = cache;
        }
    }
}

List<int[]> nowSearch = originPositions;

int answer = 0, x, y, z;

while(nowSearch.Count > 0) {
    List<int[]> nextSearch = new List<int[]>();

    foreach(int[] i in nowSearch) {
        x = i[0];
        y = i[1];
        z = i[2];

        for (int j = 0; j < 6; j++) {
            x = i[0];
            y = i[1];
            z = i[2];

            switch(j) {
                case 0:
                    if (x == 0) continue;
                    x -= 1;
                    break;
                case 1:
                    if (x == M - 1) continue;
                    x += 1;
                    break;
                case 2:
                    if (y == 0) continue;
                    y -= 1;
                    break;
                case 3:
                    if (y == N - 1) continue;
                    y += 1;
                    break;
                case 4:
                    if (z == 0) continue;
                    z -= 1;
                    break;
                case 5:
                    if (z == H - 1) continue;
                    z += 1;
                    break;

            }

            if (!searched[x,y,z] && box[x,y,z] == 0) {
                searched[x,y,z] = true;
                int[] ch = new int[3];
                ch[0] = x;
                ch[1] = y;
                ch[2] = z;
                count -= 1;
                nextSearch.Add(ch);
            }
        }
    }

    answer += 1;
    nowSearch = nextSearch;
}

if (count > 0) Console.WriteLine(-1);
else Console.WriteLine(answer - 1);
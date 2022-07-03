// D[i,j] = D[i-1,j] + D[i,j-1] - D[i-1,j-1] + Current[i,j]
// Answer(x1,y1,x2,y2) = Sum[x2,y2] - Sum[x2,y1-1] - Sum[x1-1,y2] + Sum[x1-1,y1-1]

using System.Text;

string[] inputnm = Console.ReadLine().Split();

int N = int.Parse(inputnm[0]);
int M = int.Parse(inputnm[1]);

int[,] Sum = new int[N,N];

int current;

for (int i = 0; i < N; i++) {
    string[] cache = Console.ReadLine().Split(' ');

    for (int j = 0; j < N; j++) {
        current = int.Parse(cache[j]);

        if (i > 0) {
            current += Sum[i-1,j];
        }

        if (j > 0) {
            current += Sum[i, j-1];
        }

        if (i > 0 && j > 0) {
            current -= Sum[i-1,j-1];
        }

        Sum[i,j] = current;
    }
}

StringBuilder sb = new StringBuilder();

int x1, y1, x2, y2, answer;

for (int i = 0; i < M; i++) {
    string[] inputs = Console.ReadLine().Split(' ');

    x1 = int.Parse(inputs[0]);
    y1 = int.Parse(inputs[1]);
    x2 = int.Parse(inputs[2]);
    y2 = int.Parse(inputs[3]);

    answer = Sum[x2-1, y2-1];

    if (x1 > 1) {
        answer -= Sum[x1-2, y2-1];
    }

    if (y1 > 1) {
        answer -= Sum[x2-1, y1-2];
    }
    
    if (x1 > 1 && y1 > 1) {
        answer += Sum[x1-2, y1-2];
    }

    sb.AppendLine(answer.ToString());
 }

 Console.Write(sb);
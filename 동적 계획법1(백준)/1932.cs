int[,] D = new int[501,501];
bool[,] hasValue = new bool[501,501];

List<List<int>> triangle = new List<List<int>>();

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++) {
    string[] inputs = Console.ReadLine().Split(' ');

    List<int> temp = new List<int>();

    foreach(string input in inputs) {
        temp.Add(int.Parse(input));
    }

    triangle.Add(temp);
}

int getMax(int depth, int index) {
    if (hasValue[depth, index]) {
        return D[depth, index];
    }

    if (depth == n - 1) {
        return triangle[depth][index];
    }

    D[depth, index] = Math.Max(getMax(depth + 1, index) + triangle[depth][index], getMax(depth + 1, index + 1) + triangle[depth][index]);
    hasValue[depth, index] = true;

    return D[depth, index];
}

Console.WriteLine(getMax(0, 0));
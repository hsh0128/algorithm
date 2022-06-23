int n = int.Parse(Console.ReadLine());

int[] arr = new int[n];
int[] compArr = new int[n];

string[] inputs = Console.ReadLine().Split(' ');

int cnt = 0;

foreach(string input in inputs) {
    arr[cnt] = int.Parse(input);
    cnt++;
}

compArr[0] = arr[0];

for (int i = 1; i < n; i++) {
    compArr[i] = Math.Max(arr[i], compArr[i - 1] + arr[i]);
}

Console.WriteLine(compArr.Max());
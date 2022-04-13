using System.Collections.Generic;

List<int> digits = new List<int>();

int N = int.Parse(Console.ReadLine());

while(N > 0) {
    digits.Add(N % 10);
    N /= 10;
}

digits.Sort(delegate(int x, int y) {
    return y - x;
});

foreach(int i in digits) {
    Console.Write(i);
}
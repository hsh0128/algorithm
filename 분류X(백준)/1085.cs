string[] inputs = Console.ReadLine().Split(' ');

int x = int.Parse(inputs[0]);
int y = int.Parse(inputs[1]);
int w = int.Parse(inputs[2]);
int h = int.Parse(inputs[3]);

int min1 = Math.Min(Math.Abs(x - w), Math.Abs(y - h));
int min2 = Math.Min(x, y);

Console.WriteLine(Math.Min(min1, min2));
using System.Text;

int Pow(int number, int pownum) {
    int ret = 1;

    for (int i = 0; i < pownum; i++) {
        ret *= number;
    }

    return ret;
}

int Command(char type, int number) {
    int cache, lastValue;

    switch(type) {
        case 'D':
            return (number * 2) % 10000;
        case 'S':
            if (number == 0) return 9999;
            else return number - 1;
        case 'L':
            lastValue = number / 1000;
            cache = number * 10;
            cache %= 10000;
            return cache + lastValue;
        case 'R':
            lastValue = number % 10;
            cache = number / 10;
            cache += (lastValue * 1000);
            return cache;
        default:
            return 0;
    }
}

int T = int.Parse(Console.ReadLine());
string[] inputs;
int A, B;
bool[] searched = new bool[10000];

StringBuilder sb = new StringBuilder();

void Search(Dictionary<int, string> prior) {
    Dictionary<int, string> res = new Dictionary<int, string>();

    int keyCache;
    string valueCache;

    foreach(KeyValuePair<int, string> i in prior) {
        // D
        keyCache = Command('D', i.Key);
        valueCache = i.Value + "D";

        if (keyCache == B) {
            sb.AppendLine(valueCache);
            return;
        } else if (!searched[keyCache]) {
            res.Add(keyCache, valueCache);
            searched[keyCache] = true;
        }

        // S
        keyCache = Command('S', i.Key);
        valueCache = i.Value + "S";

        if (keyCache == B) {
            sb.AppendLine(valueCache);
            return;
        } else if (!searched[keyCache]) {
            res.Add(keyCache, valueCache);
            searched[keyCache] = true;
        }

        // L
        keyCache = Command('L', i.Key);
        valueCache = i.Value + "L";

        if (keyCache == B) {
            sb.AppendLine(valueCache);
            return;
        } else if (!searched[keyCache]) {
            res.Add(keyCache, valueCache);
            searched[keyCache] = true;
        }

        // R
        keyCache = Command('R', i.Key);
        valueCache = i.Value + "R";

        if (keyCache == B) {
            sb.AppendLine(valueCache);
            return;
        } else if (!searched[keyCache]) {
            res.Add(keyCache, valueCache);
            searched[keyCache] = true;
        }
    }

    Search(res);
}

for (int i = 0; i < T; i++) {
    inputs = Console.ReadLine().Split(' ');
    A = int.Parse(inputs[0]);
    B = int.Parse(inputs[1]);

    Array.Clear(searched);

    Dictionary<int, string> temp = new Dictionary<int, string>();
    temp.Add(A, "");

    Search(temp);
}

Console.Write(sb);
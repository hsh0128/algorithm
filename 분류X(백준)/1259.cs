using System.Text;

string input = Console.ReadLine();

StringBuilder sb = new StringBuilder();

int it, lastIdx;
bool flag;

while(input != "0") {
    lastIdx = input.Length - 1;
    it = input.Length / 2;
    flag = true;

    for (int i = 0; i < it; i++) {
        if (input[i] != input[lastIdx - i]) {
            flag = false;
            break;
        }
    }
    
    if (flag)
        sb.AppendLine("yes");
    else
        sb.AppendLine("no");

    input = Console.ReadLine();
}

Console.Write(sb);
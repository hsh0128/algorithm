using System.Text;

Queue<char> alphabet = new Queue<char>();
Stack<char> operators = new Stack<char>();

string input = Console.ReadLine();
StringBuilder sb = new StringBuilder();
char nowChar;

void PopAlphabet() {
    foreach(char i in alphabet) {
        sb.Append(i);
    }

    alphabet.Clear();
}

for (int i = 0; i < input.Length; i++) {
    nowChar = input[i];

    switch(nowChar) {
        case '+':
        case '-':
            PopAlphabet();
            while(operators.Count > 0 && (operators.Peek() == '+' || operators.Peek() == '-' || operators.Peek() == '*' || operators.Peek() == '/')) {
                sb.Append(operators.Pop());
            }
            operators.Push(nowChar);
            break;
        case '*':
        case '/':
            if (operators.Count <= 0 || operators.Peek() == '+' || operators.Peek() == '-') {
                operators.Push(nowChar);
                break;
            }
            PopAlphabet();
            while(operators.Count > 0 && (operators.Peek() == '*' || operators.Peek() == '/')) {
                sb.Append(operators.Pop());
            }
            operators.Push(nowChar);
            break;
        case '(':
            operators.Push(nowChar);
            break;
        case ')':
            PopAlphabet();
            while(operators.Count > 0 && (operators.Peek() != '(')) {
                sb.Append(operators.Pop());
            }
            operators.Pop();
            break;
        default:
            alphabet.Enqueue(nowChar);
            break;
    }
}

PopAlphabet();

foreach(char i in operators) {
    sb.Append(i);
}

Console.Write(sb);
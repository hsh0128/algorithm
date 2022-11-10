using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

Stack<char> answerStack = new Stack<char>();

string targetStr = sr.ReadLine();
string bombStr = sr.ReadLine();
int targetLen = targetStr.Length;
int bombLen = bombStr.Length;

char nowChar, cacheChar;

for (int i = 0; i < targetLen; i++) {
    nowChar = targetStr[i];
    answerStack.Push(nowChar);

    if (nowChar == bombStr[bombLen - 1]) {
        Stack<char> tempStack = new Stack<char>();
        bool refund = false;

        for (int j = bombLen - 1; j >= 0; j--) {
            if (answerStack.Count() == 0) {
                refund = true;
                break;
            }

            cacheChar = answerStack.Pop();
            tempStack.Push(cacheChar);

            if (bombStr[j] != cacheChar) {
                refund = true;
                break;
            }
        }

        if (refund) {
            foreach(char c in tempStack) {
                answerStack.Push(c);
            }
        }
    }
}

if (answerStack.Count() == 0) {
    sw.WriteLine("FRULA");
} else {
    StringBuilder sb = new StringBuilder();

    Stack<char> newStack = new Stack<char>();

    foreach(char c in answerStack) {
        newStack.Push(c);
    }

    foreach(char c in newStack) {
        sb.Append(c);
    }

    sw.Write(sb);
}

sr.Close();
sw.Close();
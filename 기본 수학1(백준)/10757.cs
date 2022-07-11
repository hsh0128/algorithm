string[] inputs = Console.ReadLine().Split(' ');

string A = inputs[0];
string B = inputs[1];

int alen = A.Length;
int blen = B.Length;

int minlen = Math.Min(alen, blen);
int maxlen = Math.Max(alen, blen);

string reversedAnswer = "";

bool upNextDigit = false;
int currentDigit;

for (int i = 0; i < minlen; i++) {
    int cura = int.Parse(A[alen - 1 - i].ToString());
    int curb = int.Parse(B[blen - 1 - i].ToString());

    currentDigit = cura + curb;

    if (upNextDigit) currentDigit += 1;

    upNextDigit = false;

    if (currentDigit >= 10) {
        currentDigit -= 10;
        upNextDigit = true;
    }

    reversedAnswer += currentDigit.ToString();
}

bool isAlen = alen > blen;
int currentIndex = minlen;

int haveToAdd;

while (maxlen > currentIndex) {
    haveToAdd = 0;

    if (isAlen && alen > currentIndex) {
        haveToAdd = int.Parse(A[alen - 1 - currentIndex].ToString());
    }

    if (!isAlen && blen > currentIndex) {
        haveToAdd = int.Parse(B[blen - 1 - currentIndex].ToString());
    }

    if (upNextDigit) haveToAdd += 1;

    upNextDigit = false;

    if (haveToAdd >= 10) {
        haveToAdd -= 10;
        upNextDigit = true;
    }

    currentIndex += 1;
    reversedAnswer +=  haveToAdd.ToString();
}

if (upNextDigit) {
    reversedAnswer += "1";
}

char[] arr = reversedAnswer.ToArray();

Array.Reverse(arr);

string answer = new string(arr);

Console.WriteLine(answer);
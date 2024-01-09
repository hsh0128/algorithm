StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());

List<int> primeNumbers = new List<int>();

bool isPrime(int number) {
    bool ret = true;
    
    for (int i = 2; i * i <= number; i++) {
        if (number % i == 0) {
            ret = false;
            break;
        }
    }


    return ret;
}

for (int i = 2; i <= N; i++) {
    if (isPrime(i)) primeNumbers.Add(i);
}

int startPoint = 0, endPoint = 0, nowSum = 2, answer = 0;

if (N == 1) {
    sw.WriteLine(0);
} else {
    while(true) {
        if (nowSum < N) {
            endPoint += 1;

            if (endPoint >= primeNumbers.Count) break;

            nowSum += primeNumbers[endPoint];
        } else if (nowSum > N) {
            nowSum -= primeNumbers[startPoint];
            startPoint += 1;
        } else {
            answer += 1;
            endPoint += 1;

            if (endPoint >= primeNumbers.Count) break;

            nowSum += primeNumbers[endPoint];
        }
    }

    sw.WriteLine(answer);
}

sr.Close();
sw.Close();
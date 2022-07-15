long n = long.Parse(Console.ReadLine());

long[,] A = new long[2,2];

A[0,0] = 1;
A[1,0] = 1;
A[0,1] = 1;
A[1,1] = 0;

long[,] MatMul(long[,] a, long[,] b) {
    long[,] retMat = new long[2,2];

    for (int i = 0; i < 2; i++) {
        for (int j = 0; j < 2; j++) {
            long cache = 0;

            for (int k = 0; k < 2; k++) {
                cache += (a[i, k] * b[k, j]) % 1000000007;
                cache %= 1000000007;
            }

            retMat[i,j] = cache;
        }
    }

    return retMat;
}

long[,] CalcuateMat(long current) {
    if (current == 1) {
        return A;
    }

    if (current % 2 == 0) {
        long[,] half = CalcuateMat(current / 2);
        return MatMul(half, half);
    }

    return MatMul(A, CalcuateMat(current - 1));
}

long[,] answermat = CalcuateMat(n);

Console.WriteLine(answermat[1,0]);
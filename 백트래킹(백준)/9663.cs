int N;

int recursive(List<int> queenPos) {
    int nowRow = queenPos.Count;

    if (nowRow == N) {
        return 1;
    }

    int temp = 0;

    for (int i = 0; i < N; i++) {
        // 가로 체크
        if (queenPos.Contains(i)) {
            continue;
        }

        bool flag = false;

        // 대각선 체크
        for (int j = 0; j < nowRow; j++) {
            if (queenPos[j] - (nowRow - j) == i) {
                flag = true;
                break;
            }

            if (queenPos[j] + (nowRow - j) == i) {
                flag = true;
                break;
            }
        }

        if (flag) {
            continue;
        }

        // 값 복사
        List<int> tempList = queenPos.ToList();
        tempList.Add(i);

        temp += recursive(tempList);
    }

    return temp;
}

N = int.Parse(Console.ReadLine());

int answer = recursive(new List<int>());

Console.WriteLine(answer);
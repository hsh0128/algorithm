using System.Text;

int N = int.Parse(Console.ReadLine());

List<int> seq = new List<int>();

int nowIdx, temp;
bool minflag;

seq.Add(0);

for (int i = 0; i < N; i++) {
    seq.Add(int.Parse(Console.ReadLine()));

    nowIdx = i + 1;

    while(nowIdx > 1) {
        if (seq[nowIdx] < seq[nowIdx / 2]) {
            temp = seq[nowIdx];
            seq[nowIdx] = seq[nowIdx / 2];
            seq[nowIdx / 2] = temp;
        } else {
            break;
        }
        nowIdx /= 2;
    }
}

StringBuilder sb = new StringBuilder();

for (int i = N; i > 0; i--) {
    sb.AppendLine(seq[1].ToString());

    temp = seq[1];
    seq[1] = seq[i];
    seq[i] = temp;

    nowIdx = 1;

    while(true) {
        if (nowIdx * 2 + 1 < i) {
            minflag = seq[nowIdx * 2] < seq[nowIdx * 2 + 1];
            
            if (minflag) {
                if (seq[nowIdx] > seq[nowIdx * 2]) {
                    temp = seq[nowIdx];
                    seq[nowIdx] = seq[nowIdx * 2];
                    seq[nowIdx * 2] = temp;

                    nowIdx *= 2;
                    continue;
                } else {
                    break;
                }
            } else {
                if (seq[nowIdx] > seq[nowIdx * 2 + 1]) {
                    temp = seq[nowIdx];
                    seq[nowIdx] = seq[nowIdx * 2 + 1];
                    seq[nowIdx * 2 + 1] = temp;

                    nowIdx *= 2;
                    nowIdx += 1;
                    continue;
                } else {
                    break;
                }
            }
        } else if (nowIdx * 2 < i) {
            if (seq[nowIdx] > seq[nowIdx * 2]) {
                temp = seq[nowIdx];
                seq[nowIdx] = seq[nowIdx * 2];
                seq[nowIdx * 2] = temp;

                nowIdx *= 2;
                continue;
            } else {
                break;
            }
        } else {
            break;
        }
    }
}

Console.Write(sb);
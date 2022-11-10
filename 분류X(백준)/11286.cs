using System.Text;

SortedDictionary<int, KeyValuePair<int, int>> numbers = new SortedDictionary<int, KeyValuePair<int, int>>();

int N = int.Parse(Console.ReadLine());
int input, absoluteInput;

StringBuilder sb = new StringBuilder();

for (int i = 0; i < N; i++) {
    input = int.Parse(Console.ReadLine());
    absoluteInput = input > 0 ? input : -input;

    if (input > 0) {
        if (!numbers.ContainsKey(absoluteInput)) {
            numbers.Add(absoluteInput, new KeyValuePair<int, int>(0, 0));
        }

        numbers[absoluteInput] = new KeyValuePair<int, int>(numbers[absoluteInput].Key + 1, numbers[absoluteInput].Value);
    } else if (input < 0) {
        if (!numbers.ContainsKey(absoluteInput)) {
            numbers.Add(absoluteInput, new KeyValuePair<int, int>(0, 0));
        }

        numbers[absoluteInput] = new KeyValuePair<int, int>(numbers[absoluteInput].Key, numbers[absoluteInput].Value + 1);
    } else {
        if (numbers.Count == 0) {
            sb.AppendLine(0.ToString());
            continue;
        }

        foreach(KeyValuePair<int, KeyValuePair<int, int>> num in numbers) {
            if (num.Value.Value > 0) {
                sb.AppendLine((-num.Key).ToString());
                numbers[num.Key] = new KeyValuePair<int, int>(num.Value.Key, num.Value.Value - 1);

                if (numbers[num.Key].Key == 0 && numbers[num.Key].Value == 0) {
                    numbers.Remove(num.Key);
                }

                break;
            }

            sb.AppendLine((num.Key).ToString());
            numbers[num.Key] = new KeyValuePair<int, int>(num.Value.Key - 1, num.Value.Value);

            if (numbers[num.Key].Key == 0) {
                numbers.Remove(num.Key);
            }

            break;
        }
    }
}

Console.Write(sb);
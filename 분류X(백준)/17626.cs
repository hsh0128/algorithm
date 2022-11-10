// 이렇게 탐색하지 않고 아래서부터 4부터 메모하면서 정방향 탐색하면(점점 늘려감) 더 빨리 답을 구할 수 있음

List<int> nowSearch = new List<int>();

int n = int.Parse(Console.ReadLine());

int maxSearch = (int)Math.Sqrt((double)n);

int cnt = 1, cache;
bool found = false;

nowSearch.Add(0);

while(true) {
    List<int> nextSearch = new List<int>();

    foreach(int i in nowSearch) {
        if (found) break;

        for (int j = 1; j <= maxSearch; ++j) {
            cache = i + j * j;

            if (cache == n) {
                Console.WriteLine(cnt);
                found = true;
                break;
            }

            if (cache > n) {
                break;
            }

            nextSearch.Add(cache);
        }
    }

    if (found) break;
    nowSearch = nextSearch;
    cnt += 1;
}
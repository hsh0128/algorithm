#include <iostream>
#include <vector>

using namespace std;

vector<vector<int> > people;
vector<int> answer;

int main(void) {
	vector<int> temp;
	int N, fir, sec;

	cin.tie(NULL);
	ios_base::sync_with_stdio(false);

	cin >> N;

	for (int i = 0; i < N; i++) {
		cin >> fir >> sec;

		temp.clear();
		temp.push_back(fir);
		temp.push_back(sec);

		people.push_back(temp);
		answer.push_back(1);
	}

	for (int i = 0; i < people.size(); i++) {
		for (int j = i; j < people.size(); j++) {
			if (people[i][0] < people[j][0] && people[i][1] < people[j][1]) {
				answer[i]++;
				continue;
			}

			if (people[j][0] < people[i][0] && people[j][1] < people[i][1]) {
				answer[j]++;
			}
		}
	}

	for (int i = 0; i < answer.size(); i++) {
		cout << answer[i] << ' ';
	}

	return 0;
}
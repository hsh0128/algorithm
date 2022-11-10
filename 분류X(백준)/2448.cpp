#include <iostream>

using namespace std;

string star[3072];

int main() {
    cin.tie(NULL);
    ios_base::sync_with_stdio(false);

    int N, space = 6, distance;
    string refString, resultString;

    cin >> N;

    star[0] = "*";
    star[1] = "* *";
    star[2] = "*****";

    for (int i = 3; i < N; ++i) {
        if (i == space) {
            space *= 2;
        }

        refString = star[i - space / 2];

        distance = space - refString.length();

        star[i] = refString;

        for (int j = 0; j < distance; ++j) {
            star[i] += " ";
        }

        star[i] += refString;
    }

    for (int i = 0; i < N; i++) {
        resultString = "";

        for (int j = 0; j < N - 1 - i; ++j) {
            resultString += " ";
        }

        resultString += star[i];

        for (int j = 0; j < N - 1 - i; ++j) {
            resultString += " ";
        }

        cout << resultString << '\n';
    }
}
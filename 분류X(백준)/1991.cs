using System.Text;

Dictionary<char, KeyValuePair<char, char>> tree = new Dictionary<char, KeyValuePair<char, char>>();

int N = int.Parse(Console.ReadLine());

string[] inputs;

for (int i = 0; i < N; i++) {
    inputs = Console.ReadLine().Split(' ');

    tree.Add(inputs[0][0], new KeyValuePair<char, char>(inputs[1][0], inputs[2][0]));
}

StringBuilder sb = new StringBuilder();

void preorder(char nowNode) {
    if (nowNode == '.') return;

    sb.Append(nowNode);
    preorder(tree[nowNode].Key);
    preorder(tree[nowNode].Value);
}

void inorder(char nowNode) {
    if (nowNode == '.') return;

    inorder(tree[nowNode].Key);
    sb.Append(nowNode);
    inorder(tree[nowNode].Value);
}

void postorder(char nowNode) {
    if (nowNode == '.') return;

    postorder(tree[nowNode].Key);
    postorder(tree[nowNode].Value);
    sb.Append(nowNode);
}

preorder('A');
sb.Append('\n');
inorder('A');
sb.Append('\n');
postorder('A');

Console.Write(sb);
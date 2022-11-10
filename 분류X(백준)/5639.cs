using System.Text;

Dictionary<int, KeyValuePair<int, int>> tree = new Dictionary<int, KeyValuePair<int, int>>();

int root = -1;
int cache;

void addNode(int nowNode, int addNodeValue) {
    if (nowNode > addNodeValue) {
        if (tree[nowNode].Key == -1) {
            tree[nowNode] = new KeyValuePair<int, int>(addNodeValue, tree[nowNode].Value);
            tree.Add(addNodeValue, new KeyValuePair<int, int>(-1, -1));
            return;
        }

        addNode(tree[nowNode].Key, addNodeValue);
    } else {
        if (tree[nowNode].Value == -1) {
            tree[nowNode] = new KeyValuePair<int, int>(tree[nowNode].Key, addNodeValue);
            tree.Add(addNodeValue, new KeyValuePair<int, int>(-1, -1));
            return;
        }

        addNode(tree[nowNode].Value, addNodeValue);
    }
}

while(true) {
    string input = Console.ReadLine();
    if (input == "" || input == null) break;
    cache = int.Parse(input);

    if (tree.Count() == 0) {
        root = cache;
        tree.Add(root, new KeyValuePair<int, int>(-1, -1));
        continue;
    }

    addNode(root, cache);
}

StringBuilder sb = new StringBuilder();

void Search(int nowNode) {
    if (nowNode == -1) return;
    
    Search(tree[nowNode].Key);
    Search(tree[nowNode].Value);
    sb.AppendLine(nowNode.ToString());
}

Search(root);

Console.Write(sb);
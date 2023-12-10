using day8;

// Part 1

Dictionary<string, Node<string>> cache = [];

string[] lines = System.IO.File.ReadAllLines(@"./input");

char[] directions = lines[0].Trim().Select(x => x).ToArray();

foreach (string line in lines[2..]) {
    string[] nodeData = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
    string[] children = nodeData[1].Replace("(","").Replace(")","").Split(',', StringSplitOptions.RemoveEmptyEntries);

    Node<string> node = new(nodeData[0].Trim())
    {
        Left = new(children[0].Trim()),
        Right = new(children[1].Trim())
    };

    cache[node.Value] = node;
}

long stepCounter = 0;

Node<string> current = cache["AAA"];

while (current.Value != "ZZZ") {
    current = directions[stepCounter % directions.Length] switch
    {
        'L' => cache[current.Left.Value],
        'R' => cache[current.Right.Value],
        _ => throw new InvalidDataException(),
    };
    stepCounter++;
}

Console.WriteLine(stepCounter);

// Part 2 -- need to redo

List<Node<string>> current_nodes = cache.Where(kv => kv.Key.EndsWith('A')).Select(kv => kv.Value).ToList();
stepCounter = 0;

while (!current_nodes.All(node => node.Value.EndsWith('Z'))) {
    for (int i = 0; i < current_nodes.Count; i++) {
        current_nodes[i] = directions[stepCounter % directions.Length] switch
        {
            'L' => cache[current_nodes[i].Left.Value],
            'R' => cache[current_nodes[i].Right.Value],
            _ => throw new InvalidDataException(),
        };
    }
    stepCounter++;
}

Console.WriteLine(stepCounter);
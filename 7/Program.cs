using day7;

// Part 1

List <Hand> hands = new();

foreach (string line in System.IO.File.ReadLines(@"./input")) {
    Console.WriteLine(line);
    var splitLines = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    hands.Add(new Hand(splitLines[0], long.Parse(splitLines[1])));
}

hands.Sort();

Console.WriteLine(hands.Select((hand, index) => hand.getScore() * (index+1)).Sum());

// Part 2
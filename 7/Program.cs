using System.Runtime.InteropServices;
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

List <Hand> hands2 = new();

foreach (string line in System.IO.File.ReadLines(@"./input")) {
    Console.WriteLine(line);
    var splitLines = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    hands2.Add(new Hand(splitLines[0], long.Parse(splitLines[1]), true));
}

hands2.Sort();

var hands3 = hands2.Select(x => x.getHand().Contains('J') ? x : null).ToList();

Console.WriteLine(hands2.Select((hand, index) => hand.getScore() * (index+1)).Sum());
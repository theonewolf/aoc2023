// Part 1

List<List<long>> sequences = [];

foreach (string line in System.IO.File.ReadLines(@"./input")) {
    sequences.Add(line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToList());
}

List<long> predictions = [];
foreach (var sequence in sequences) {
    List<List<long>> rounds = [sequence];

    // Easy bug here if you check for sum to 0, it is possible that a sequence of positive and negative
    // integers sum to 0 --> but all diffs are not 0 yet.
    while (!rounds.Last().All(x => x == 0)) {
        rounds.Add(rounds.Last().Zip(rounds.Last().Skip(1), (x, y) => y - x).ToList());
    }

    rounds.Reverse();
    long curVal = 0;

    foreach (var round in rounds) {
        curVal = round.Last() + curVal;
    }

    predictions.Add(curVal);
}

Console.WriteLine(predictions.Sum());
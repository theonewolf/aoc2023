// Part 1

List<long> card_values = new();

foreach (string line in System.IO.File.ReadLines(@"./input")) {
    var data = line.Split(":")[1];
    var numbers =  data.Split("|");

    var winning_numbers = new HashSet<long>(numbers[0].Split(" ", options: StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)));
    var my_numbers = new HashSet<long>(numbers[1].Split(" ", options: StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)));
    
    int winning_counter = 0;
    int score = 0;
    
    foreach (var number in my_numbers) {
        if (winning_numbers.Contains(number)) {
            winning_counter++;
            score = score == 0 ? 1 : score * 2;
        }
    }

    card_values.Add(score);
}

Console.WriteLine(card_values.Sum());

// Part 2


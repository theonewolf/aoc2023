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

var raw_data = System.IO.File.ReadAllLines(@"./input");
List<long> win_counts = new(new long[raw_data.Count()]);;
List<long> card_copies = Enumerable.Repeat((long)1, raw_data.Count()).ToList();

int line_counter = 0;
foreach (string line in raw_data) {
    var data = line.Split(":")[1];
    var numbers =  data.Split("|");

    var winning_numbers = new HashSet<long>(numbers[0].Split(" ", options: StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)));
    var my_numbers = new HashSet<long>(numbers[1].Split(" ", options: StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)));
    
    int winning_counter = 0;
    
    foreach (var number in my_numbers) {
        if (winning_numbers.Contains(number)) {
            winning_counter++;
        }
    }
    win_counts[line_counter] = winning_counter;
    line_counter++;
}

for (int i = 0; i < card_copies.Count(); i++) {
    var wins = win_counts[i];
    var copies = card_copies[i];

    for (int j = 0; j < copies; j++) {
        for (int k = 0; k < wins; k++) {
            card_copies[i+1+k]++;
        }
    }
}

Console.WriteLine(card_copies.Sum());
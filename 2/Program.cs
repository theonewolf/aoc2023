// Part 1

int redMax = 12;
int greenMax = 13;
int blueMax = 14;

HashSet<int> allIDs = new();
HashSet<int> impossibleIDs = new();

foreach (string line in System.IO.File.ReadLines(@"./input")) {
    var data = line.Split(":");
    var id = int.Parse(data[0].Split(" ")[1]);
    allIDs.Add(id);
    var sessions = data[1].Split(";");

    foreach (var session in sessions) {
        var samples = session.Split(",");

        foreach (var sample in samples) {
            var splitSample = sample.Split(" ");
            int count = int.Parse(splitSample[1]);
            string color = splitSample[2];

            switch (color) {
                case "red":
                    if (count > redMax) {
                        impossibleIDs.Add(id);
                    }
                    break;
                case "green":
                    if (count > greenMax) {
                        impossibleIDs.Add(id);
                    }
                    break;
                case "blue":
                    if (count > blueMax) {
                        impossibleIDs.Add(id);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

Console.WriteLine("All IDs: " + string.Join(" ", allIDs));
Console.WriteLine("Impossible IDs: " + string.Join(" ", impossibleIDs));
Console.WriteLine("Impossible IDs Sum: " + impossibleIDs.Sum());
Console.WriteLine("Possible IDs: " + string.Join(" ", allIDs.Except(impossibleIDs)));
Console.WriteLine("Possible IDs Sum: " + allIDs.Except(impossibleIDs).Sum());

// Part 2

List<int> powers = new();

foreach (string line in System.IO.File.ReadLines(@"./input")) {
    var data = line.Split(":");
    var id = int.Parse(data[0].Split(" ")[1]);
    var sessions = data[1].Split(";");

    // A Game
    int minRed = 0;
    int minBlue = 0;
    int minGreen = 0;
    foreach (var session in sessions) {
        var samples = session.Split(",");

        foreach (var sample in samples) {
            var splitSample = sample.Split(" ");
            int count = int.Parse(splitSample[1]);
            string color = splitSample[2];

            switch (color) {
                case "red":
                    if (count > minRed) {
                        minRed = count;
                    }
                    break;
                case "green":
                    if (count > minGreen) {
                        minGreen = count;
                    }
                    break;
                case "blue":
                    if (count > minBlue) {
                        minBlue = count;
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    int power = minRed * minBlue * minGreen;

    powers.Add(power);
}

Console.WriteLine("All powers: " + string.Join(" ", powers));
Console.WriteLine("All powers sum: " + powers.Sum());
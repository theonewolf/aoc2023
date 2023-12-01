// Part 1

List<int> nums = new();

foreach (string line in System.IO.File.ReadLines(@"./input")) {
    int first = -1;
    int last = -1;

    foreach (char c in line) {
        if (char.IsDigit(c)) {
            if (first == -1) {
                first = int.Parse(c.ToString());
            }
            last = int.Parse(c.ToString());
        }
    }

    nums.Add(first * 10 + last);
}

Console.WriteLine(string.Join(" ", nums));
Console.WriteLine(nums.Sum());
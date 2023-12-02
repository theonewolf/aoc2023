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

Console.WriteLine(nums.Sum());

// Part 2
List<int> nums2 = new();

foreach (string line in System.IO.File.ReadLines(@"./input")) {
    int first = -1;
    int last = -1;

    for (int i = 0; i < line.Length; i++) {
        if (char.IsDigit(line[i])) {
            if (first == -1) {
                first = int.Parse(line[i].ToString());
            }
            last = int.Parse(line[i].ToString());
            continue;
        }

        int number = line[i..] switch
        {
            string s when s.StartsWith("one") => 1,
            string s when s.StartsWith("two") => 2,
            string s when s.StartsWith("three") => 3,
            string s when s.StartsWith("four") => 4,
            string s when s.StartsWith("five") => 5,
            string s when s.StartsWith("six") => 6,
            string s when s.StartsWith("seven") => 7,
            string s when s.StartsWith("eight") => 8,
            string s when s.StartsWith("nine") => 9,
            _ => -1
        };

        if (number != -1) {
            if (first == -1) {
                first = number;
            }
            last = number;
        }
    }

    nums2.Add(first * 10 + last);
}

Console.WriteLine(nums2.Sum());
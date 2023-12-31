// Part 1

string[] lines = System.IO.File.ReadLines(@"./input").ToArray();
long[] times = lines[0].Split(":", StringSplitOptions.RemoveEmptyEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();
long[] distances = lines[1].Split(":", StringSplitOptions.RemoveEmptyEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();

var zipped = times.Zip(distances, (time, distance) => ( time, distance ));
List<long> total_win_methods = new();

foreach ((long time, long distance) in zipped)
{
    long win_methods = 0;

    for (long hold = 0; hold < time; hold++) {
        long boat_distance = hold * (time - hold);
        if (boat_distance > distance) {
            win_methods += 1;
        }
    }

    total_win_methods.Add(win_methods);
}

Console.WriteLine(total_win_methods.Aggregate(1L, (acc, val) => acc * val));

// Part 2

string[] lines2 = System.IO.File.ReadLines(@"./input2").ToArray();
long[] times2 = lines2[0].Split(":", StringSplitOptions.RemoveEmptyEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();
long[] distances2 = lines2[1].Split(":", StringSplitOptions.RemoveEmptyEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();

var zipped2 = times2.Zip(distances2, (time, distance) => ( time, distance ));
List<long> total_win_methods2 = new();

foreach ((long time, long distance) in zipped2)
{
    long win_methods = 0;

    for (long hold = 0; hold < time; hold++) {
        long boat_distance = hold * (time - hold);
        if (boat_distance > distance) {
            win_methods += 1;
        }
    }

    total_win_methods2.Add(win_methods);
}

Console.WriteLine(total_win_methods2.Aggregate(1L, (acc, val) => acc * val));
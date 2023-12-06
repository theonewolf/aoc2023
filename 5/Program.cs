using Day5;

// Part 1

//seed-to-soil map:
var seedToSoil = new Mapper();

//soil-to-fertilizer map:
var soilToFertilizer = new Mapper();;

//fertilizer-to-water map:
var fertilizerToWater = new Mapper();;

//water-to-light map:
var waterToLight  = new Mapper();;

//light-to-temperature map:
var lightToTemperature = new Mapper();;

//temperature-to-humidity map:
var temperatureToHumidity = new Mapper();;

//humidity-to-location map:
var humidityToLocation = new Mapper();;

long[]? seeds = null;
var currentMap = seedToSoil;

foreach (string line in File.ReadLines(@"./input")) {

    if (line == string.Empty) continue;

    if (char.IsDigit(line[0])) {
        currentMap.Add(new RangeMapper(line));
    }

    if (line.StartsWith("seeds:")) {
        var data = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
        seeds = data[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();
    }

    if (line.StartsWith("soil-to-fertilizer")) {
        currentMap = soilToFertilizer;
    }

    if (line.StartsWith("fertilizer-to-water")) {
        currentMap = fertilizerToWater;
    }

    if (line.StartsWith("water-to-light")) {
        currentMap = waterToLight;
    }

    if (line.StartsWith("light-to-temperature")) {
        currentMap = lightToTemperature;
    }

    if (line.StartsWith("temperature-to-humidity")) {
        currentMap = temperatureToHumidity;
    }

    if (line.StartsWith("humidity-to-location")) {
        currentMap = humidityToLocation;
    }
}

Console.WriteLine(seeds?
                                                    .Select(x => seedToSoil.Map(x))
                                                    .Select(x => soilToFertilizer.Map(x))
                                                    .Select(x=> fertilizerToWater.Map(x))
                                                    .Select(x => waterToLight.Map(x))
                                                    .Select(x => lightToTemperature.Map(x))
                                                    .Select(x => temperatureToHumidity.Map(x))
                                                    .Select(x => humidityToLocation.Map(x)).Min());


// Part 2

//seed-to-soil map:
long[]? seeds_pairs;
List<long> seeds2 = [];

foreach (string line in File.ReadLines(@"./input")) {
    if (line == string.Empty) continue;

    if (line.StartsWith("seeds:")) {
        var data = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
        seeds_pairs = data[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToArray();

        for (int i = 0; i < seeds_pairs.Length - 1; i += 2) {
            var seedStart = seeds_pairs[i];
            var seedStop = seeds_pairs[i+1];
            for (long j = seedStart; j < seedStart + seedStop; j++) {
                seeds2.Add(j);
            }
        }

    }

}

Console.WriteLine($"seeds2 Count: {seeds2.Count}");

Console.WriteLine(seeds2?
                                                    .Select(x => seedToSoil.Map(x))
                                                    .Select(x => soilToFertilizer.Map(x))
                                                    .Select(x=> fertilizerToWater.Map(x))
                                                    .Select(x => waterToLight.Map(x))
                                                    .Select(x => lightToTemperature.Map(x))
                                                    .Select(x => temperatureToHumidity.Map(x))
                                                    .Select(x => humidityToLocation.Map(x)).Min());
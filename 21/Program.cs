using AoC23;

Grid g = new();
int steps = 64;
int finalCount = 0;

foreach (string line in System.IO.File.ReadLines(@"./input")) {
    g.AddRow(line);
}

// For every S on the map,
// Try to take a step in any direction.  If you can, mark it with O
// Set the original O to a .

// Step 0: you start at S
g.SetPositions(g.GetPositionsS(), 'O');

while (steps > 0) {
    steps--;

    // Get all starting positions
    var starts = g.GetPositionsO();

    // Mark a step from each one
    finalCount = g.MarkAdjacent(starts, 'O', [.. "."]);

    // Debug
    Console.WriteLine($"--- Step {steps - 6} ---");

    // Debug
    Console.WriteLine(g);

    // Debug
    Console.WriteLine(g);
}

Console.WriteLine(finalCount);
Console.WriteLine(g.GetPositionsO().Count);
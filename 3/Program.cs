// Part 1

// Parse all grid numbers + symbols
HashSet<GridNumber> gridNumbers = new();
List<Symbol> symbols = new();

int row_index = 0;
foreach (string row in System.IO.File.ReadLines(@"./input")) {

    int x = -1;
    int y = -1;
    string data = "";

    int col_index = 0;

    // This isn't as elegant as I imagined, due to handling the end of the grid boundary on the right.
    // For each col in row
    foreach (var col in row) {
        switch (col) {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
                if (x < 0) {
                    x = col_index;
                }

                if (y < 0) {
                    y = row_index;
                }

                data += col;
                break;
            default:
                if (data != "") {
                    gridNumbers.Add(new GridNumber(x, y, data.Length, data, int.Parse(data)));
                    x = -1;
                    y = -1;
                    data = "";
                }

                if (col != '.') symbols.Add(new Symbol(col_index, row_index, col.ToString()));
                break;
        }

        col_index++;
    }

    // Numbers at the edge of the grid.
    if (data != "") {
        gridNumbers.Add(new GridNumber(x, y, data.Length, data, int.Parse(data)));
        x = -1;
        y = -1;
        data = "";
    }

    row_index++;
}

// Check for all symbols touching GridNumbers
HashSet<GridNumber> symbolsTouched = new();
HashSet<Symbol> gears = new();

foreach (var symbol in symbols) {
    foreach (var number in gridNumbers) {
        bool touched = false;
        // North
        if (number.Contains(symbol.Row, symbol.Col - 1)) {
            symbolsTouched.Add(number);
            touched = true;
        }

        // North-East
        if (number.Contains(symbol.Row + 1, symbol.Col - 1)) {
            symbolsTouched.Add(number);
            touched = true;
        }

        // East
        if (number.Contains(symbol.Row + 1, symbol.Col)) {
            symbolsTouched.Add(number);
            touched = true;
        }

        // South-East
        if (number.Contains(symbol.Row + 1, symbol.Col + 1)) {
            symbolsTouched.Add(number);
            touched = true;
        }

        // South
        if (number.Contains(symbol.Row, symbol.Col + 1)) {
            symbolsTouched.Add(number);
            touched = true;
        }

        // South-West
        if (number.Contains(symbol.Row - 1, symbol.Col + 1)) {
            symbolsTouched.Add(number);
            touched = true;
        }

        // West
        if (number.Contains(symbol.Row - 1, symbol.Col)) {
            symbolsTouched.Add(number);
            touched = true;
        }

        // North-West
        if (number.Contains(symbol.Row - 1, symbol.Col - 1)) {
            symbolsTouched.Add(number);
            touched = true;
        }

        //Part 2
        if (touched) {
            if (symbol.Data == "*") {
                symbol.AdjacentParts.Add(number.Value);
                if (symbol.AdjacentParts.Count >= 2) {
                    gears.Add(symbol);
                }
            }
        }
    }
}

// Part 1
Console.WriteLine(symbolsTouched.Select(x => x.Value).Sum());

// Part 2
Console.WriteLine(gears.Select(x => x.AdjacentParts.Aggregate((a, b) => a * b)).Sum());
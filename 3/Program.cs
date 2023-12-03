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

    row_index++;
}

// Check for all symbols touching GridNumbers
HashSet<GridNumber> symbolsTouched = new();

foreach (var symbol in symbols) {
    foreach (var number in gridNumbers) {
        // North
        if (number.Contains(symbol.Row, symbol.Col - 1)) {
            symbolsTouched.Add(number);
        }

        // North-East
        if (number.Contains(symbol.Row + 1, symbol.Col - 1)) {
            symbolsTouched.Add(number);
        }

        // East
        if (number.Contains(symbol.Row + 1, symbol.Col)) {
            symbolsTouched.Add(number);
        }

        // South-East
        if (number.Contains(symbol.Row + 1, symbol.Col + 1)) {
            symbolsTouched.Add(number);
        }

        // South
        if (number.Contains(symbol.Row, symbol.Col + 1)) {
            symbolsTouched.Add(number);
        }

        // South-West
        if (number.Contains(symbol.Row - 1, symbol.Col + 1)) {
            symbolsTouched.Add(number);
        }

        // West
        if (number.Contains(symbol.Row - 1, symbol.Col)) {
            symbolsTouched.Add(number);
        }

        // North-West
        if (number.Contains(symbol.Row - 1, symbol.Col - 1)) {
            symbolsTouched.Add(number);
        }
    }
}

Console.WriteLine(symbolsTouched.Select(x => x.Value).Sum());
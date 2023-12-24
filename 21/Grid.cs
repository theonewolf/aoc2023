namespace AoC23
{
    public class Grid
    {
        private readonly List<List<char>> _grid;
        private int _width;
        public int StartX { get; private set; }
        public int StartY { get; private set; }

        public Grid()
        {
            _grid = [];
        }

        public Grid(List<string> rows) : this()
        {
            foreach (string row in rows)
            {
                AddRow(row);
            }
        }

        public void AddRow(string row)
        {
            if (_grid.Count > 0 && row.Length != _width)
            {
                throw new ArgumentException("New row does not match the width of the original row.");
            }

            List<char> rowChars = new(row.ToCharArray());
            _grid.Add(rowChars);

            if (_grid.Count == 1)
            {
                _width = row.Length;
            }

            int startX = row.IndexOf('S');
            if (startX >= 0)
            {
                StartX = startX;
                StartY = _grid.Count - 1;
            }
        }

        public override string ToString()
        {
            var rows = _grid.ToList();
            var start = "";

            if (rows.Any())
            {
                start = $"StartX={StartX}, StartY={StartY} \n";
            }

            return start + string.Join("\n", rows.Select(row => string.Join(" ", row)));
        }

        public List<Tuple<int, int>> GetPositionsS()
        {
            return GetPositions('S');
        }

        public List<Tuple<int, int>> GetPositionsO()
        {
            return GetPositions('O');
        }

        private List<Tuple<int, int>> GetPositions(char ch)
        {
            var positions = new List<Tuple<int, int>>();
            for (int y = 0; y < _grid.Count; y++)
            {
                for (int x = 0; x < _grid[y].Count; x++)
                {
                    if (_grid[y][x] == ch)
                    {
                        positions.Add(new Tuple<int, int>(x, y));
                    }
                }
            }
            return positions;
        }

        public void SetPositions(List<Tuple<int, int>> positions, char ch)
        {
            foreach (var position in positions)
            {
                int x = position.Item1;
                int y = position.Item2;
                if (IsValidPosition(x, y)) _grid[y][x] = ch;
            }
        }

        public int MarkAdjacent(List<Tuple<int, int>> positions, char ch, List<char> possibleChars)
        {
            int count = 0;
            foreach (var position in positions)
            {
                int x = position.Item1;
                int y = position.Item2;
                if (IsValidPosition(x - 1, y) && possibleChars.Contains(_grid[y][x - 1]))
                {
                    _grid[y][x - 1] = ch; // West
                    count++;
                }
                if (IsValidPosition(x + 1, y) && possibleChars.Contains(_grid[y][x + 1]))
                {
                    _grid[y][x + 1] = ch; // East
                    count++;
                }
                if (IsValidPosition(x, y - 1) && possibleChars.Contains(_grid[y - 1][x]))
                {
                    _grid[y - 1][x] = ch; // North
                    count++;
                }
                if (IsValidPosition(x, y + 1) && possibleChars.Contains(_grid[y + 1][x]))
                {
                    _grid[y + 1][x] = ch; // South
                    count++;
                }
                _grid[y][x] = '.';
            }
            return count;
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < _width && y < _grid.Count;
        }
    }
}
namespace Day5
{
    public class Mapper
    {
        public List<RangeMapper> RangeMappers { get; private set; }

        public Mapper() {
            RangeMappers = new();
        }

        public void Add(RangeMapper map) {
            RangeMappers.Add(map);
        }

        public long Map(long value) {
            foreach (var mapper in RangeMappers) {
                if (mapper.Contains(value)) {
                    return mapper.Map(value);
                }
            }

            // Unmapped values map to themselves...
            return value;
        }
    }

    public class RangeMapper
    {
    public long SourceStart { get; private set; }
    public long DestinationStart { get; private set; }
    public long Range { get; private set; }

        public RangeMapper(long sourceStart, long destinationStart, long range)
        {
            SourceStart = sourceStart;
            DestinationStart = destinationStart;
            Range = range;
        }

        public RangeMapper(string input)
        {
            var numbers = input.Split(' ', options: StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length != 3)
            {
                throw new ArgumentException("Input string must contain exactly three numbers separated by spaces.");
            }

            if (!long.TryParse(numbers[0], out long destinationStart) ||
                !long.TryParse(numbers[1], out long sourceStart) ||
                !long.TryParse(numbers[2], out long range))
            {
                throw new ArgumentException("Input string must contain three valid integers.");
            }

            SourceStart = sourceStart;
            DestinationStart = destinationStart;
            Range = range;
        }

        public bool Contains(long value) {
            return value >= SourceStart && value <= SourceStart + Range;
        }

    public long Map(long value)
    {
            if (value >= SourceStart && value <= SourceStart + Range)
            {
                return DestinationStart + (value - SourceStart);
            }
            
            throw new ArgumentOutOfRangeException("Value is not within the source range.");
    }
    }
}
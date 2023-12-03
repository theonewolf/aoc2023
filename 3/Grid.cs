public class GridNumber
{
    public int Col { get; private set; }
    public int Row { get; private set; }
    public int Width { get; private set; }
    public string Data { get; private set; }
    public int Value { get; private set; }

    public GridNumber(int col, int row, int width, string data, int value)
    {
        Col = col;
        Row = row;
        Width = width;
        Data = data;
        Value = value;
    }

    public bool Contains(int row, int col) {
        return col >= Col &&
            col < Col + Width &&
            row == Row;
    }
    
    public override bool Equals(object obj)
    {
        if (obj is GridNumber other)
        {
            return Col == other.Col && Row == other.Row && Width == other.Width && Value == other.Value;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Col, Row, Width, Data, Value);
    }
}

public class Symbol
{
   public int Col { get; private set; }
   public int Row { get; private set; }
   public string Data { get; private set; }

   public Symbol(int col, int row, string data)
   {
       Col = col;
       Row = row;
       Data = data;
   }

   public override bool Equals(object obj)
   {
       if (obj is Symbol other)
       {
           return Col == other.Col && Row == other.Row && Data == other.Data;
       }
       return false;
   }

   public override int GetHashCode()
   {
       return HashCode.Combine(Col, Row, Data);
   }
}
namespace Abc.Aids;

[AttributeUsage(AttributeTargets.Property)]
public sealed class RandomAttribute(int min, int max) : Attribute
{
    public int Min { get; private set; } = min;
    public int Max { get; private set; } = max;
    public sbyte? Scale { get; private set; }
    public string Chars { get; private set; }
    public RandomAttribute(int min, int max, sbyte scale) : this(min, max) => Scale = scale;
    public RandomAttribute(int min, int max, string chars) : this(min, max) => Chars = chars;
    public object CreateValue(Type t)
    {
        t = Nullable.GetUnderlyingType(t) ?? t;
        if (t == typeof(string)) return GetRandom.String((byte)Min, (byte)Max, Chars);
        if (t == typeof(DateTime)) return GetRandom.DateTime(date(Min), date(Max));
        if (t == typeof(double)) return round(GetRandom.Double(Min, Max));
        if (t == typeof(decimal)) return round(GetRandom.Decimal(Min, Max));
        if (t == typeof(int)) return GetRandom.Int32(Min, Max);
        return GetRandom.Value(t);
    }
    private static DateTime date(int y) => DateTime.Now.AddYears(y);
    private double round(double d) => Scale.HasValue ? Math.Round(d, Scale.Value) : d;
    private decimal round(decimal d) => Scale.HasValue ? Math.Round(d, Scale.Value) : d;
}
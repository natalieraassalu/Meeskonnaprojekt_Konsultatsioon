using System.Reflection;

namespace Abc.Aids;

public static class GetRandom
{
    private static readonly Random r = Random.Shared;
    public static int Int32(int min = int.MinValue, int max = int.MaxValue)
    {
        if (min == max) return min;
        if (min > max) (min, max) = (max, min);
        return r.Next(min, max);
    }
    public static long Int64(long min = long.MinValue, long max = long.MaxValue)
    {
        if (min == max) return min;
        if (min > max) (min, max) = (max, min);
        return r.NextInt64(min, max);
    }
    public static double Double(double min = double.MinValue, double max = double.MaxValue)
    {
        if (min == max) return min;
        if (min > max) (min, max) = (max, min);
        return min + r.NextDouble() * (max - min);
    }
    public static sbyte Int8(sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue)
        => (sbyte)Int32(min, max);
    public static short Int16(short min = short.MinValue, short max = short.MaxValue)
        => (short)Int32(min, max);
    public static byte UInt8(byte min = byte.MinValue, byte max = byte.MaxValue)
        => (byte)Int32(min, max);
    public static ushort UInt16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue)
        => (ushort)Int32(min, max);
    public static uint UInt32(uint min = uint.MinValue, uint max = uint.MaxValue)
        => (uint)Int64(min, max);
    public static ulong UInt64(ulong min = ulong.MinValue, ulong max = ulong.MaxValue)
    {
        var minLong = (long)min - long.MaxValue;
        var maxLong = (long)max - long.MaxValue;
        return (ulong)(Int64(minLong, maxLong) + long.MaxValue);
    }
    public static float Float(float min = float.MinValue, float max = float.MaxValue)
        => (float)Double(min, max);
    public static decimal Decimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
        => (decimal)Double((double)min, (double)max);
    public static Guid Guid()
    {
        Span<byte> buffer = stackalloc byte[16];
        r.NextBytes(buffer);
        return new Guid(buffer);
    }
    public static TimeSpan TimeSpan(TimeSpan? min = null, TimeSpan? max = null)
    {
        var minTicks = min?.Ticks ?? System.TimeSpan.MinValue.Ticks;
        var maxTicks = max?.Ticks ?? System.TimeSpan.MaxValue.Ticks;
        var ticks = Int64(minTicks, maxTicks);
        return new TimeSpan(ticks);
    }
    public static DateTime DateTime(DateTime? min = null, DateTime? max = null)
    {
        var minTicks = min?.Ticks ?? System.DateTime.MinValue.Ticks;
        var maxTicks = max?.Ticks ?? System.DateTime.MaxValue.Ticks;
        var ticks = Int64(minTicks, maxTicks);
        return new DateTime(ticks);
    }
    public static bool Bool() => r.Next(2) == 0;
    public static char Char(char min = char.MinValue, char max = char.MaxValue)
        => (char)UInt16(min, max);
    public static string String(byte minLen = byte.MinValue, byte maxLen = (byte)sbyte.MaxValue,string chars= null)
    {
        var len = UInt8(minLen, maxLen);
        var s = new char[len];
        for (var i = 0; i < len; i++) s[i] = (chars is null)? Char('a', 'z') 
            : chars[UInt8(0,(byte)chars.Length)];
        return new string(s);
    }
    public static object Object(Type t, string[] exclude = null)
    {
        exclude = exclude ?? [];
        var x = Nullable.GetUnderlyingType(t);
        if (x is not null) t = x;
        var o = Activator.CreateInstance(t);
        foreach (var p in t.GetProperties())
        {
            if (!p.CanWrite) continue;
            if (p.PropertyType.IsArray) continue;
            if (exclude.Contains(p.Name)) continue;
            var randomAttribute = p.GetCustomAttribute<RandomAttribute>();
            var v = randomAttribute is not null
                ? randomAttribute.CreateValue(p.PropertyType)
                : isClass(p) ? Object(p.PropertyType) : Value(p.PropertyType);
            p.SetValue(o, v);
        }
        return o;
    }
    private static bool isClass(PropertyInfo p)
        => p.PropertyType.IsClass && p.PropertyType != typeof(string);
    public static object Value(Type t)
    {
        var x = Nullable.GetUnderlyingType(t);
        if (x is not null) t = x;
        if (t == typeof(string)) return String();
        if (t == typeof(char)) return Char();
        if (t == typeof(bool)) return Bool();
        if (t == typeof(DateTime)) return DateTime();
        if (t == typeof(decimal)) return Decimal();
        if (t == typeof(double)) return Double();
        if (t == typeof(float)) return Float();
        if (t == typeof(byte)) return UInt8();
        if (t == typeof(ushort)) return UInt16();
        if (t == typeof(uint)) return UInt32();
        if (t == typeof(ulong)) return UInt64();
        if (t == typeof(sbyte)) return Int8();
        if (t == typeof(short)) return Int16();
        if (t == typeof(int)) return Int32();
        if (t == typeof(long)) return Int64();
        //if (t == typeof(TimeSpan)) return TimeSpan();
        //if (t == typeof(Guid)) return Guid();
        return null;
    }
}

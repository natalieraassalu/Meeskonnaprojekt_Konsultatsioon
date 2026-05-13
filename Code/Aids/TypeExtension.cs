namespace Abc.Aids;
public static class TypeExtension
{
    public static bool IsBool(this Type t)=> toUnderlying(t) == typeof(bool);
    private static Type toUnderlying(Type t) => t is null ? null: Nullable.GetUnderlyingType(t) ?? t;

    public static bool IsDate(this Type t) => t == typeof(DateTime)||t==typeof(DateOnly);
    public static bool IsString(this Type t) => t == typeof(string);

    public static bool IsNumeric(this Type t)
    {
        if (t is null) return false;
        t =toUnderlying(t);
        return t == typeof(byte) || t == typeof(sbyte) ||
               t == typeof(short) || t == typeof(ushort) ||
               t == typeof(int) || t == typeof(uint) ||
               t == typeof(long) || t == typeof(ulong) ||
               t == typeof(float) || t == typeof(double) ||
               t == typeof(decimal);
    }
}


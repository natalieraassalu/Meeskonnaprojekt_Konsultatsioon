using Abc.Aids;
using Abc.Data.Common;
using System.Collections;
using System.Reflection;

namespace Abc.Shared.Code;

public static class MyGridAids
{
    public static bool Show(PropertyInfo p)
    {
        if (p is null) return false;
        if (p.Name == nameof(NamedEntity.Id)) return false;
        var t = p.PropertyType;
        if (t == typeof(string)) return true;
        if (typeof(IEnumerable).IsAssignableFrom(t)) return false;
        if (t.IsClass) return false;
        return true;
    }
    public static string Value(PropertyInfo p, object e)
    {
        var v = isSelect(p) ? getSelectValue(p, e) : p?.GetValue(e);
        return v?.ToString() ?? string.Empty;
    }
    private static bool isSelect(PropertyInfo p) => p?.GetCustomAttribute<SelectAttribute>() != null;
    private static object getSelectValue(PropertyInfo p, object e)
    {
        var a = p?.GetCustomAttribute<SelectAttribute>();
        var id = p?.GetValue(e) as Guid?;
        if (id is null) return null;
        var guid = id.Value;
        var t = a?.EntityType;
        var pi = e?.GetType().GetProperty(t.Name);
        var entity = pi?.GetValue(e);
        var name = a?.DisplayProperty;
        pi = (name is null) ? null : entity?.GetType().GetProperty(name);
        return pi?.GetValue(entity);
    }
}
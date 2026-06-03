using Abc.Aids;
using Abc.Data.Common;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Abc.Shared.Code;

public static class MyGridAids {
    // A property opts out of the auto-generated UI (editor, viewer and grid)

    public static bool IsHidden(PropertyInfo p)
        => p?.GetCustomAttribute<ScaffoldColumnAttribute>() is { Scaffold: false };
    public static bool Show(PropertyInfo p) {
        if (p is null) return false;
        if (IsHidden(p)) return false;
        if (p.Name == nameof(NamedEntity.Id)) return false;
        var t = p.PropertyType;
        if (t == typeof(string)) return true;
        if (typeof(IEnumerable).IsAssignableFrom(t)) return false;
        if (t.IsClass) return false;
        return true;
    }
    public static string Value(PropertyInfo p, object e) {
        var v = isSelect(p) ? getSelectValue(p, e) : p?.GetValue(e);
        if (v is DateTime dt) return dt.ToString("g");
        return v?.ToString() ?? string.Empty;
    }
    private static bool isSelect(PropertyInfo p) => p?.GetCustomAttribute<SelectAttribute>() != null;
    private static object getSelectValue(PropertyInfo p, object e) {
        var a = p?.GetCustomAttribute<SelectAttribute>();
        var id = p?.GetValue(e) as Guid?;
        if (id is null) return null;
        var t = a?.EntityType;
        if (t is null) return null;
        var pi = e?.GetType().GetProperty(t.Name) ?? findNavByType(e, t);
        var entity = pi?.GetValue(e);
        var name = a?.DisplayProperty;
        pi = (name is null) ? null : entity?.GetType().GetProperty(name);
        return pi?.GetValue(entity);
    }
    private static PropertyInfo findNavByType(object e, Type t) =>
        e?.GetType().GetProperties().FirstOrDefault(x => x.PropertyType == t);
}
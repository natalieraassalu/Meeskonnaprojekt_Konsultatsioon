using System.Reflection;

namespace Abc.Razor.Code;

public class RelatedList(PropertyInfo pi, IQueryable<object> items) {
    public string Name { get; } = pi.Name;
    public IQueryable<object> Items { get; } = items;
    public int Count => Items.Count();
    public PropertyInfo[] Properties => ItemType?.GetProperties() ?? [];
    public Type ItemType {
        get {
            var t = pi.PropertyType;
            if (t is null) return null;
            if (t.IsArray) return t.GetElementType();
            if (t.IsGenericType) return t.GetGenericArguments()[0];
            return null;
        }
    }
}
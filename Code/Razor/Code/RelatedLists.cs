using System.Collections;

namespace Abc.Razor.Code;

public class RelatedLists : List<RelatedList> {
    public RelatedLists(object o) {
        foreach (var p in o?.GetType().GetProperties() ?? []) {
            if (typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
                && isCollectionOfClasses(p.PropertyType)) {
                var items = (p.GetValue(o) as IEnumerable).Cast<object>();
                if (items is null) continue;
                Add(new RelatedList(p, items.AsQueryable()));
            }
        }
    }
    private static bool isCollectionOfClasses(Type t)
    {
        var e = t.IsGenericType ? t.GetGenericArguments()[0] : t.GetElementType();
        return e != null && e.IsClass && e != typeof(string);
    }
}
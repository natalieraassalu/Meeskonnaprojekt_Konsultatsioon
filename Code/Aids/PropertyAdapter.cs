
using System.Reflection;

namespace Abc.Aids;
public interface IPropertyAdapter
{
    public Type ItemType { get; }
    public object Item { get; } 
    PropertyInfo PropInfo { get; }
    public Type PropType { get;}
    public Type UnderlyingType { get; }
    object PropValue { get; }
    void SetValue(object value);
}
public sealed class PropertyAdapter(object item, string propName) : IPropertyAdapter
{
    public PropertyAdapter() : this(null, null) { }
    public Type ItemType => item?.GetType();
    public object Item => item;
    public PropertyInfo PropInfo => ItemType?.GetProperty(propName);
    public Type PropType => PropInfo?.PropertyType;
    public Type UnderlyingType => Nullable.GetUnderlyingType(PropType) ?? PropType;
    public object PropValue=> PropInfo?.GetValue(Item);
    public void SetValue(object value) => PropInfo?.SetValue(item, value);
}


namespace Abc.Aids;

[AttributeUsage(AttributeTargets.Property)]
public sealed class SelectAttribute(Type t, string displayProperty = null) : Attribute
{
    public SelectAttribute():this(null,null) {}
    public Type EntityType { get; } = t;
    public string DisplayProperty { get; } = string.IsNullOrWhiteSpace(displayProperty) ? "Name" : displayProperty;
}

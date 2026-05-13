using Abc.Aids;

namespace Abc.Tests.Aids;

[TestClass]
public class SelectAttributeTests : BaseTests<SelectAttribute>
{
    private string displayProperty;
    private Type entityType;
    private SelectAttribute o;
    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        displayProperty = GetRandom.String();
        entityType = GetRandom.Bool() ? typeof(string) :
            GetRandom.Bool() ? typeof(int) :
            GetRandom.Bool() ? typeof(double) :
            GetRandom.Bool() ? typeof(decimal) :
            GetRandom.Bool() ? typeof(float) :
            typeof(bool);
        o = new SelectAttribute(entityType, displayProperty);
    }
    [TestMethod] public void EntityTypeTest() => areEqual(entityType, o.EntityType);
    [TestMethod] public void DefaultEntityTypeTest() => areEqual(null, obj.EntityType);
    [TestMethod] public void DisplayPropertyTest() => areEqual(displayProperty, o.DisplayProperty);
    [TestMethod] public void DefaultDisplayPropertyTest() => areEqual("Name", obj.DisplayProperty);
    [TestMethod] public void HasAttributeUsageTest() =>
        Assert.IsNotEmpty(typeof(SelectAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false));
}
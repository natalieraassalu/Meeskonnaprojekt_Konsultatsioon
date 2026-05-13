using Abc.Aids;
using Abc.Razor.Components;
using Abc.Tests.Aids;

namespace Abc.Tests.Razor.Code;

[TestClass]
public class EditorAdapterTests : BaseTests<EditorAdapter>
{
    private class TestClass
    {
        public string Name { get; set; }
    }
    private TestClass o;
    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        o = new TestClass() { Name = GetRandom.String() };
        obj = new EditorAdapter(null, o, nameof(TestClass.Name));
    }
    [TestMethod] public void PropertyAdapterIsNotNullTest() => Assert.IsNotNull(obj.ad);
    [TestMethod]
    public void PropertyInfoTest()
    {
        areEqual(obj.ad.PropInfo, obj.PropInfo);
        areEqual(nameof(TestClass.Name), obj.PropInfo.Name);
    }
}
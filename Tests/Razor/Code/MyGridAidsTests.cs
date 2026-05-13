using Abc.Aids;
using Abc.Razor.Code;
using Abc.Tests.Aids;
using System.Reflection;
using Abc.Shared.Code;

namespace Abc.Tests.Razor.Code;

[TestClass]
public class MyGridAidsTests : TestAids
{
    private class TestClass
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        public object ObjectProperty { get; set; }
        public IEnumerable<int> EnumerableProperty { get; set; }
    }
    private TestClass o;
    [TestInitialize]
    public void TestInitialize()
    {
        type = typeof(MyGridAids);
        o = new TestClass
        {
            StringProperty = GetRandom.String(),
            IntProperty = GetRandom.Int32(),
            ObjectProperty = new object(),
            EnumerableProperty = [GetRandom.Int32(), GetRandom.Int32()]
        };
    }
    [DataRow(nameof(TestClass.StringProperty), true)]
    [DataRow(nameof(TestClass.IntProperty), true)]
    [DataRow(nameof(TestClass.ObjectProperty), false)]
    [DataRow(nameof(TestClass.EnumerableProperty), false)]
    [TestMethod]
    public void ShowTest(string name, bool show)
    {
        areEqual(show, MyGridAids.Show(getProp(name)));
    }
    private PropertyInfo getProp(string name) => typeof(TestClass).GetProperty(name);
    [TestMethod]
    public void ValueTest()
    {
        areEqual(o.StringProperty, MyGridAids.Value(getProp(nameof(TestClass.StringProperty)), o));
        areEqual(o.IntProperty.ToString(), MyGridAids.Value(getProp(nameof(TestClass.IntProperty)), o));
        areEqual(o.ObjectProperty.ToString(), MyGridAids.Value(getProp(nameof(TestClass.ObjectProperty)), o));
        areEqual(o.EnumerableProperty.ToString(), MyGridAids.Value(getProp(nameof(TestClass.EnumerableProperty)), o));
    }
    [TestMethod]
    public void ValueNullTest()
    {
        o = new TestClass();
        areEqual("", MyGridAids.Value(getProp(nameof(TestClass.StringProperty)), o));
        areEqual(o.IntProperty.ToString(), MyGridAids.Value(getProp(nameof(TestClass.IntProperty)), o));
        areEqual("", MyGridAids.Value(getProp(nameof(TestClass.ObjectProperty)), o));
        areEqual("", MyGridAids.Value(getProp(nameof(TestClass.EnumerableProperty)), o));
    }

}

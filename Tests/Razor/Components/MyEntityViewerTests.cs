namespace Abc.Tests.Razor.Components;

using Abc.Aids;
using Abc.Razor.Components;
using Abc.Tests.Aids;
using Bunit;

[TestClass]
public sealed class MyEntityViewerTests : BaseTests<MyEntityViewer>
{
    private sealed class SampleEntity
    {
        public string Name { get; set; }
        public int? Age { get; set; }
    }
    private MyEntityViewer o;
    private SampleEntity e;
    private TestContext c;

    [TestInitialize]
    override public void Initialize()
    {
        base.Initialize();
        e = new SampleEntity
        {
            Name = GetRandom.String(5, 10),
            Age = GetRandom.Int32(1, 100)
        };
        o = new MyEntityViewer { Entity = e };
        c = new TestContext();
    }
    [TestCleanup]
    public void Cleanup()
    {
        c.Dispose();
        c = null;
    }
    [TestMethod]
    public void EntityTest()
    {
        areEqual(null, obj.Entity);
        areSame(e, o.Entity);
    }
    [TestMethod]
    public void RenderMarkupTest()
    {
        var r = c.RenderComponent<MyEntityViewer>(p => p.Add(x => x.Entity, e));
        var labels = r.FindAll("dt").Select(x => x.TextContent).ToList();
        var values = r.FindAll("dd").Select(x => x.TextContent).ToList();
        areEqual(2, labels.Count);
        areEqual(2, values.Count);
        Assert.Contains("Name", labels);
        Assert.Contains("Age", labels);
        Assert.Contains(e.Name, values);
        Assert.Contains(e.Age.ToString(), values);
    }
    [TestMethod]
    public void RenderNullEntityTest()
    {
        var r = c.RenderComponent<MyEntityViewer>(p => p.Add(x => x.Entity, null));
        areEqual(0, r.FindAll("dt").Count);
        areEqual(0, r.FindAll("dd").Count);
    }
    [TestMethod]
    public void RenderNullValuesTest()
    {
        e = new SampleEntity();
        var r = c.RenderComponent<MyEntityViewer>(p => p.Add(x => x.Entity, e));
        areEqual(2, r.FindAll("dt").Count);
        areEqual(2, r.FindAll("dd").Count);
    }
}

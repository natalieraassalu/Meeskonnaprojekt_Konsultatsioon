
using Abc.Aids;
using Abc.Razor.Components;
using Abc.Tests.Aids;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using TestContext = Bunit.TestContext;

namespace Abc.Tests.Razor.Components;

[TestClass]
public sealed class MyPropertyEditorTests : BaseTests<MyPropertyEditor>
{
    private sealed class SampleEntity
    {
        public string Name { get; set; }
    }
    private MyPropertyEditor o;
    private SampleEntity e;
    private TestContext c;
    [TestInitialize]
    override public void Initialize()
    {
        base.Initialize();
        e = new SampleEntity { Name = GetRandom.String(5, 10) };
        o = new MyPropertyEditor { Item = e, PropertyName = nameof(SampleEntity.Name) };
        c = new TestContext();
    }
    [TestCleanup] public void Cleanup()
    {
        c.Dispose();
        c = null;
    }
    [TestMethod] public void ItemTest()
    {
        areEqual(null, obj.Item);
        areSame(e, o.Item);
    }
    [TestMethod] public void PropertyNameTest()
    {
        areEqual(string.Empty, obj.PropertyName);
        areEqual(nameof(SampleEntity.Name), o.PropertyName);
    }
    
    [TestMethod] public void RenderPropertyTest()
    {
        var r = c.RenderComponent<EditForm>(p => p
            .Add(x => x.Model, e)
            .Add(x => x.ChildContent, (_ => b => {
                b.OpenComponent<MyPropertyEditor>(0);
                b.AddAttribute(1, nameof(MyPropertyEditor.Item), e);
                b.AddAttribute(2, nameof(MyPropertyEditor.PropertyName), nameof(SampleEntity.Name));
                b.CloseComponent();
            })));
        var labels = r.FindAll("label").Select(x => x.TextContent).ToList();
        var inputs = r.FindAll("input");
        areEqual(1, labels.Count);
        areEqual(1, inputs.Count);
        Assert.Contains(nameof(SampleEntity.Name), labels);
    }
}
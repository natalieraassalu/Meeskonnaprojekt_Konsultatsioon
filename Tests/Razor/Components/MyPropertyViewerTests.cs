
using Abc.Aids;
using Abc.Razor.Components;
using Abc.Tests.Aids;
using Bunit;
using TestContext = Bunit.TestContext;

namespace Abc.Tests.Razor.Components;

[TestClass] public sealed class MyPropertyViewerTests : BaseTests<MyPropertyViewer>
{
    private MyPropertyViewer o;
    private string l;
    private string v;
    private TestContext c;

    [TestInitialize] override public void Initialize()
    {
        base.Initialize();
        l = GetRandom.String(5, 10);
        v = GetRandom.String(5, 10);
        o = new MyPropertyViewer { Label = l, Value = v };
        c = new TestContext();
    }
    [TestCleanup] public void Cleanup()
    {
        c.Dispose();
        c = null;
    }
    [TestMethod] public void LabelTest()
    {
        areEqual(string.Empty, obj.Label);
        areEqual(l, o.Label);
    }
    [TestMethod] public void ValueTest()
    {
        areEqual(null, obj.Value);
        areEqual(v, o.Value);
    }
    [TestMethod] public void RenderMarkupTest()
    {
        var r = c.RenderComponent<MyPropertyViewer>(p => p
            .Add(x => x.Label, l)
            .Add(x => x.Value, v));
        r.MarkupMatches($"<dl class=\"row\">" +
                        $"<dt class=\"col-sm-2\">{l}</dt>" +
                        $"<dd class=\"col-sm-10\">{v}</dd>" +
                        "</dl>");
    }
}
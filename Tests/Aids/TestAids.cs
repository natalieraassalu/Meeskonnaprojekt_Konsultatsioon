
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Reflection;
namespace Abc.Tests.Aids;

public abstract class TestAids<TClass>:TestAids where TClass : class, new()
{
    protected TClass obj;

    [TestInitialize] public virtual void Initialize() => type = typeof(TClass);

    protected const BindingFlags publicDeclared = BindingFlags.Public
                                                  | BindingFlags.Instance
                                                  | BindingFlags.DeclaredOnly
                                                  | BindingFlags.Static;

    protected static IEnumerable<string> getProperties() =>
        Abc.Aids.GetType.PropertyNames<TClass>(publicDeclared);

    protected static IEnumerable<string> getMethods()
        => Abc.Aids.GetType.MethodNames<TClass>(publicDeclared, false);

    protected void isProperty<T>(string name)
    {
        var p = typeof(TClass).GetProperty(name);
        Assert.IsNotNull(p, noProperty(name));
        Assert.AreEqual(typeof(T),p.PropertyType,wrongType<T>(name,p)) ;
    }

    private static string wrongType<T>(string name, PropertyInfo p)
    => $"Property {name} in class {typeof(TClass).Name} " +
               $"is of type {p.PropertyType.Name}, expected {typeof(T).Name}.";

    private static string noProperty(string name)
        => $"Property {name} not found in class {typeof(TClass).Name})";
}

public abstract class TestAids
{
    protected Type type { get; set; }

    [TestMethod]
    public void IsCorrectClassTest()
    {
        var className = type?.Name;
        var testClassName = GetType().Name;
        Assert.AreEqual(testClassName.Replace("Tests", ""), className);
    }

    public void areEqual<T>(T e, T a) => Assert.AreEqual(e, a);
    public void areSame(object e, object a) => Assert.AreSame(e, a);
}

using Abc.Aids;

namespace Abc.Tests.Aids;
[TestClass] public class TypeExtensionTests:TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(TypeExtension);
    [TestMethod] public void IsBoolTest()
    {
        Assert.IsTrue(TypeExtension.IsBool(typeof(bool)));
        Assert.IsTrue(typeof(bool).IsBool());
        Assert.IsFalse(TypeExtension.IsBool(typeof(string)));
    }
    [TestMethod] public void IsBoolNullableTest()
    {
        Assert.IsTrue(TypeExtension.IsBool(typeof(bool)));
    }
    [TestMethod] public void IsDateTest()
    {
        Assert.Inconclusive();
    }
    [TestMethod] public void IsStringTest() 
    {
        Assert.Inconclusive();
    }

    [DataRow(typeof(sbyte))]
    [DataRow(typeof(sbyte?))]
    [DataRow(typeof(byte))]
    [DataRow(typeof(byte?))]
    [DataRow(typeof(int))]
    [DataRow(typeof(uint?))]
    [DataRow(typeof(short))]
    [DataRow(typeof(short?))]
    [DataRow(typeof(ushort))]
    [DataRow(typeof(ushort?))]
    [DataRow(typeof(long))]
    [DataRow(typeof(long?))]
    [DataRow(typeof(ulong))]
    [DataRow(typeof(ulong?))]
    [DataRow(typeof(float))]
    [DataRow(typeof(float?))]
    [DataRow(typeof(double))]
    [DataRow(typeof(double?))]
    [DataRow(typeof(decimal))]
    [DataRow(typeof(decimal?))]
    [TestMethod] public void IsNumericTest(Type t)
    {
        Assert.IsTrue(TypeExtension.IsNumeric(t));
        Assert.IsTrue(t.IsNumeric());
    }
}
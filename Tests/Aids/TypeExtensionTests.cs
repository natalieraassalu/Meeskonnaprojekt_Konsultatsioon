using System;
using System.Collections.Generic;
using System.Text;
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
    [DataRow(typeof(int?))]
    [TestMethod] public void IsNumericTest(Type t)
    {
        Assert.IsTrue(TypeExtension.IsNumeric(t));
        Assert.IsTrue(t.IsNumeric());
    }
}
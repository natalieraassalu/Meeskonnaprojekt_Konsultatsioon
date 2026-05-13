
using Abc.Aids;
using Abc.Data.Common;

namespace Abc.Tests.Aids;

[TestClass] public sealed class GetRandomTests
{
    private const sbyte min = sbyte.MinValue;
    private const sbyte max = sbyte.MaxValue;

    [TestMethod] public void Int8Test()
    {
        var x = GetRandom.Int8(min, max);
        var y = GetRandom.Int8(min, max);
        for (var i = 0; i < 10; i++)
        {
            if (x != y) break;
            y = GetRandom.Int8(min, max);
        }
        Assert.AreNotEqual(x, y);
    }
    [TestMethod] public void Int16Test()
        => Assert.AreNotEqual(GetRandom.Int16(min, max), GetRandom.Int16(min, max));
    [TestMethod] public void Int32Test() 
        => Assert.AreNotEqual(GetRandom.Int32(min,max),GetRandom.Int32(min,max));
    [TestMethod] public void Int64Test()
        => Assert.AreNotEqual(GetRandom.Int64(min,max),GetRandom.Int64(min,max));
    [TestMethod] public void UInt8Test()
    {
        var x = GetRandom.UInt8(0, (byte)max);
        var y = GetRandom.UInt8(0, (byte)max);
        for (var i = 0; i < 10; i++)
        {
            if (x != y) break;
            y = GetRandom.UInt8(0, (byte)max);
        }
        Assert.AreNotEqual(x, y);
    }
    [TestMethod] public void UInt16Test()
        => Assert.AreNotEqual(GetRandom.UInt16(0,(ushort) max), GetRandom.UInt16(0, (ushort) max));
    [TestMethod] public void UInt32Test()
        => Assert.AreNotEqual(GetRandom.UInt32(0,(uint) max), GetRandom.UInt32(0, (uint)max));
    [TestMethod] public void UInt64Test()
        => Assert.AreNotEqual(GetRandom.UInt64(0, (ulong) max), GetRandom.UInt64(0, (ulong) max));
    [TestMethod] public void DoubleTest() 
        => Assert.AreNotEqual(GetRandom.Double(min, max), GetRandom.Double(min, max));
    [TestMethod] public void FloatTest()
        => Assert.AreNotEqual(GetRandom.Float(min, max), GetRandom.Float(min, max));
    [TestMethod] public void DecimalTest()
        => Assert.AreNotEqual(GetRandom.Decimal(min, max), GetRandom.Decimal(min, max));
    [TestMethod] public void StringTest()
        => Assert.AreNotEqual(GetRandom.String(0,(byte) max), GetRandom.String(0,(byte) max));
    [TestMethod] public void CharTest()
        => Assert.AreNotEqual(GetRandom.Char((char)0, (char)max), GetRandom.Char((char)0, (char)max));
    [TestMethod] public void BoolTest()
    {
        var x= GetRandom.Bool();
        bool y = GetRandom.Bool();
        for(var i = 0; i < 10; i++)
        {
            if (x != y) break;
            y = GetRandom.Bool();
        }
        Assert.AreNotEqual(x,y);
    }
    [TestMethod] public void DateTimeTest()
    {
        var minDate=DateTime.Now.AddYears(-50);
        var maxDate=DateTime.Now.AddYears(50);
        Assert.AreNotEqual(GetRandom.DateTime(minDate, maxDate), GetRandom.DateTime(minDate, maxDate));
    }
    [TestMethod] public void TimeSpanTest()
    {
        var minSpan = TimeSpan.FromTicks(DateTime.Now.AddYears(-100).Ticks);
        var maxSpan = TimeSpan.FromTicks(DateTime.Now.AddYears(100).Ticks);
        Assert.AreNotEqual(GetRandom.TimeSpan(minSpan, maxSpan), GetRandom.TimeSpan(minSpan, maxSpan));
    }
    [TestMethod] public void GuidTest()
        => Assert.AreNotEqual(GetRandom.Guid(), GetRandom.Guid());
    private class testClass:NamedEntity{}

    [TestMethod] public void ObjectTest()
    {
        var o1 = GetRandom.Object(typeof(testClass));
        var o2=GetRandom.Object(typeof(testClass));
        foreach(var p in typeof(testClass).GetProperties())
        {
            if (p.PropertyType.IsArray) continue;
            if (p.PropertyType == typeof(Guid)) continue;
            Assert.AreNotEqual(p.GetValue(o1), p.GetValue(o2));
        }
    }
}

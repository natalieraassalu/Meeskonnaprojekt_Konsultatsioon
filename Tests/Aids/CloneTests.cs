using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Tests.Aids;

[TestClass]
public sealed class CloneTests
{
    private class Address
    {
        public string City { get; set; }
    }

    private class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    private static Person person;

    [ClassInitialize] public static void ClassInitialize(TestContext context)
    {
        person = new Person
        {
            Name = "John Doe",
            Address = new Address
            {
                City = "New York"
            }
        };
    }

    private Person clone;
    [TestInitialize] public void TestInitialize() => clone = Abc.Aids.Clone.Object(person);
    [TestCleanup] public void TestCleanup() => clone = null;
    [TestMethod] public void CloneTest()=> Assert.AreNotSame(person, clone);
    [TestMethod] public void SamePersonNameTest()=>Assert.AreEqual(person.Name, clone.Name);
    [TestMethod]public void SameCityTest()=>Assert.AreEqual(person.Address.City, clone.Address.City);

    [TestMethod]
    public void ChangePersonNameText()
    {
        clone.Name = "Bla bla";
        Assert.AreEqual("John Doe", person.Name);
    }
    [TestMethod] public void NotSameAddressTest()=>Assert.AreNotSame(person.Address, clone.Address);

    [TestMethod]
    public void ChangeCityTest()
    {
        clone.Address.City = "Bla bla";
        Assert.AreEqual("New York", person.Address.City);
    }

    [TestMethod]
    public void ChangeAddressTest()
    {
        clone.Address = new Address { City = "Bla bla" };
        Assert.AreEqual("New York", person.Address.City);
    }



}

using Abc.Data.Consultation;
using Abc.Tests.Aids;

namespace Abc.Tests.Data;

[TestClass]
public sealed class UserTests : BaseTests<User>
{
    [TestMethod] public void IdTest() => isProperty<Guid>(nameof(User.Id));
    [TestMethod] public void NameTest() => isProperty<string>(nameof(User.Name));
    [TestMethod] public void EmailTest() => isProperty<string>(nameof(User.Email));
    [TestMethod] public void ValidFromTest() => isProperty<DateTime?>(nameof(User.ValidFrom));
    [TestMethod] public void ValidToTest() => isProperty<DateTime?>(nameof(User.ValidTo));
}
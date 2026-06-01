using Abc.Data.Consultation;
using Abc.Tests.Aids;

namespace Abc.Tests.Data;

[TestClass]
public sealed class RoleTests : BaseTests<Role>
{
    [TestMethod] public void IdTest() => isProperty<Guid>(nameof(Role.Id));
    [TestMethod] public void NameTest() => isProperty<string>(nameof(Role.Name));
    [TestMethod] public void CodeTest() => isProperty<string>(nameof(Role.Code));
    [TestMethod] public void DetailsTest() => isProperty<string>(nameof(Role.Details));
    [TestMethod] public void ValidFromTest() => isProperty<DateTime?>(nameof(Role.ValidFrom));
    [TestMethod] public void ValidToTest() => isProperty<DateTime?>(nameof(Role.ValidTo));
}
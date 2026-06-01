using Abc.Data.Consultation;
using Abc.Tests.Aids;

namespace Abc.Tests.Data;

[TestClass]
public sealed class UserRoleTests : BaseTests<UserRole>
{
    [TestMethod] public void IdTest() => isProperty<Guid>(nameof(UserRole.Id));
    [TestMethod] public void UserIdTest() => isProperty<Guid>(nameof(UserRole.UserId));
    [TestMethod] public void RoleIdTest() => isProperty<Guid>(nameof(UserRole.RoleId));
    [TestMethod] public void UserTest() => isProperty<User>(nameof(UserRole.User));
    [TestMethod] public void RoleTest() => isProperty<Role>(nameof(UserRole.Role));
    [TestMethod] public void ValidFromTest() => isProperty<DateTime?>(nameof(UserRole.ValidFrom));
    [TestMethod] public void ValidToTest() => isProperty<DateTime?>(nameof(UserRole.ValidTo));
}
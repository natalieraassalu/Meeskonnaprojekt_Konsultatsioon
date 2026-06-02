using Abc.Data.Consultation;
using Abc.Tests.Aids;

namespace Abc.Tests.Data;

[TestClass]
public sealed class CourseTests : BaseTests<Course>
{
    [TestMethod] public void IdTest() => isProperty<Guid>(nameof(Course.Id));
    [TestMethod] public void NameTest() => isProperty<string>(nameof(Course.Name));
    [TestMethod] public void CodeTest() => isProperty<string>(nameof(Course.Code));
    [TestMethod] public void DetailsTest() => isProperty<string>(nameof(Course.Details));
    [TestMethod] public void CourseMaterialsTest() => isProperty<ICollection<CourseMaterial>>(nameof(Course.CourseMaterials));
    [TestMethod] public void TimestampTest() => isProperty<byte[]>(nameof(Course.Timestamp));
    [TestMethod] public void ValidFromTest() => isProperty<DateTime?>(nameof(Course.ValidFrom));
    [TestMethod] public void ValidToTest() => isProperty<DateTime?>(nameof(Course.ValidTo));
}

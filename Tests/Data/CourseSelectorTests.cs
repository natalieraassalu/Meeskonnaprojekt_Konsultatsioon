using Abc.Data.Consultation;
using Abc.Tests.Aids;

namespace Abc.Tests.Data;

[TestClass]
public sealed class CourseSelectorTests : BaseTests<CourseSelector>
{
    [TestMethod] public void IdTest() => isProperty<Guid>(nameof(CourseSelector.Id));
    [TestMethod] public void CourseIdTest() => isProperty<Guid>(nameof(CourseSelector.CourseId));
    [TestMethod] public void LecturerIdTest() => isProperty<Guid>(nameof(CourseSelector.LecturerId));
    [TestMethod] public void StudentIdTest() => isProperty<Guid>(nameof(CourseSelector.StudentId));
    [TestMethod] public void CourseTest() => isProperty<Course>(nameof(CourseSelector.Course));
    [TestMethod] public void LecturerTest() => isProperty<User>(nameof(CourseSelector.Lecturer));
    [TestMethod] public void StudentTest() => isProperty<User>(nameof(CourseSelector.Student));
    [TestMethod] public void ValidFromTest() => isProperty<DateTime?>(nameof(CourseSelector.ValidFrom));
    [TestMethod] public void ValidToTest() => isProperty<DateTime?>(nameof(CourseSelector.ValidTo));
}

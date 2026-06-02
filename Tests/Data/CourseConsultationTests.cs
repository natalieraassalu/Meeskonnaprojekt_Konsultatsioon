using Abc.Data.Consultation;
using Abc.Tests.Aids;

namespace Abc.Tests.Data;

[TestClass]
public sealed class CourseConsultationTests : BaseTests<CourseConsultation>
{
    [TestMethod] public void IdTest() => isProperty<Guid>(nameof(CourseConsultation.Id));
    [TestMethod] public void CourseIdTest() => isProperty<Guid>(nameof(CourseConsultation.CourseId));
    [TestMethod] public void ConsultationSlotIdTest() => isProperty<Guid>(nameof(CourseConsultation.ConsultationSlotId));
    [TestMethod] public void CourseTest() => isProperty<Course>(nameof(CourseConsultation.Course));
    [TestMethod] public void ConsultationSlotTest() => isProperty<ConsultationSlot>(nameof(CourseConsultation.ConsultationSlot));
    [TestMethod] public void ValidFromTest() => isProperty<DateTime?>(nameof(CourseConsultation.ValidFrom));
    [TestMethod] public void ValidToTest() => isProperty<DateTime?>(nameof(CourseConsultation.ValidTo));
}

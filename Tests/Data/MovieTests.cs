using Abc.Data;
using Abc.Tests.Aids;

namespace Abc.Tests.Data;

[TestClass]
public sealed class MovieTests : BaseTests<Movie>
{
    [TestMethod] public void IdTest() => isProperty<Guid>(nameof(Movie.Id));
    [TestMethod] public void TitleTest() => Assert.Inconclusive();
    [TestMethod] public void ReleaseDateTest() => Assert.Inconclusive();
    [TestMethod] public void GenreTest() => Assert.Inconclusive();
    [TestMethod] public void PriceTest() => isProperty<decimal>(nameof(Movie.Price));
}


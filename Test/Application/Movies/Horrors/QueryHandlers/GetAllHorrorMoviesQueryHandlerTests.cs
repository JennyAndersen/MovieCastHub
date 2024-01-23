using Application.Movies.Queries.Horrors.GetAllHorror;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Horrors.QueryHandlers
{
    [TestFixture]
    public class GetAllHorrorMoviesQueryHandlerTests
    {
        private Mock<IMovieRepository> _movieRepositoryMock;
        private GetAllHorrorMoviesQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new GetAllHorrorMoviesQueryHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_GetAlLHorrorMovies_ReturnsCorrect([Frozen] List<Horror> horrors)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetAllHorrorsMoviesAsync()).ReturnsAsync(horrors);

            var query = new GetAllHorrorMoviesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Horror>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}

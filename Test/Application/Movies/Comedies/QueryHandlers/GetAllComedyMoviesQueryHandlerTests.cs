using Application.Movies.Queries.Comedies.GetAllComedy;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Comedies.QueryHandlers
{
    [TestFixture]
    public class GetAllComedyMoviesQueryHandlerTests
    {
        private Mock<IMovieRepository> _movieRepositoryMock;
        private GetAllComedyMoviesQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new GetAllComedyMoviesQueryHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_GetAlLBirds_ReturnsCorrect([Frozen] List<Comedy> comedies)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetAllComedyMoviesAsync()).ReturnsAsync(comedies);

            var query = new GetAllComedyMoviesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Comedy>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}

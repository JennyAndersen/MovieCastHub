using Application.Movies.Queries.Comedies.GetComedyMovieByDirector;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Comedies.QueryHandlers
{
    [TestFixture]
    public class GetComedyMovieByDirectorQueryHandlerTests
    {
        private GetComedyMovieByDirectorQueryHandler _handler;
        private Mock<IMovieRepository> _movieRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new GetComedyMovieByDirectorQueryHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_ValidDirector_ReturnsCorrectMovies([Frozen] Movie comedyMovie, List<Movie> comedyMovies)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByDirectorAsync(comedyMovie.Director)).ReturnsAsync(comedyMovies);

            var query = new GetComedyMovieByDirectorQuery(comedyMovie.Director);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}

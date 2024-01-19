using Application.Movies.Queries.Comedies.GetComedyMovieByTitle;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Comedies.QueryHandlers
{
    [TestFixture]
    public class GetComedyMovieByTitleQueryHandlerTests
    {
        private GetComedyMovieByTitleQueryHandler _handler;
        private Mock<IMovieRepository> _movieRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new GetComedyMovieByTitleQueryHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_ValidTitle_ReturnsCorrectMovies([Frozen] Movie comedyMovie, List<Movie> comedyMovies)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByTitleAsync(comedyMovie.Title)).ReturnsAsync(comedyMovies);
            var query = new GetComedyMovieByTitleQuery(comedyMovie.Title);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}

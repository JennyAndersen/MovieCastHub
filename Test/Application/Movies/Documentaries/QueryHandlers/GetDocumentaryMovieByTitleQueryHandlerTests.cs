using Application.Movies.Queries.Documentaries.GetDocumentaryMovieByTitle;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Documentaries.QueryHandlers
{
    public class GetDocumentaryMovieByTitleQueryHandlerTests
    {
        private GetDocumentaryMovieByTitleQueryHandler _handler;
        private Mock<IMovieRepository> _movieRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new GetDocumentaryMovieByTitleQueryHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_ValidTitle_ReturnsCorrectMovies([Frozen] Movie documentaryMovie, List<Movie> documentaryMovies)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByTitleAsync(documentaryMovie.Title)).ReturnsAsync(documentaryMovies);
            var query = new GetDocumentaryMovieByTitleQuery(documentaryMovie.Title);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}

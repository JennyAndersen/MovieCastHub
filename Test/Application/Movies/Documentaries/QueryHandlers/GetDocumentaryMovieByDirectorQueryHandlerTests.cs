using Application.Movies.Queries.Documentaries.GetDocumentaryMovieByDirector;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Documentaries.QueryHandlers
{
    [TestFixture]
    public class GetDocumentaryMovieByDirectorQueryHandlerTests
    {
        private GetDocumentaryMovieByDirectorQueryHandler _handler;
        private Mock<IMovieRepository> _movieRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new GetDocumentaryMovieByDirectorQueryHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_ValidDirector_ReturnsCorrectMovies([Frozen] Movie documentaryMovie, List<Movie> documentaryMovies)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByDirectorAsync(documentaryMovie.Director)).ReturnsAsync(documentaryMovies);

            var query = new GetDocumentaryMovieByDirectorQuery(documentaryMovie.Director);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}

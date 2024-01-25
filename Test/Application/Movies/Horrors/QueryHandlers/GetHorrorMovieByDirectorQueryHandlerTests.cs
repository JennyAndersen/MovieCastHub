using Application.Movies.Queries.Horrors.GetHorrorMovieByDirector;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Horrors.QueryHandlers
{
    [TestFixture]
    public class GetHorrorMovieByDirectorQueryHandlerTests
    {
        private GetHorrorMovieByDirectorQueryHandler _handler;
        private Mock<IMovieRepository> _movieRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new GetHorrorMovieByDirectorQueryHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_ValidDirector_ReturnsCorrectMovies([Frozen] Movie horrorMovie, List<Movie> horrorMovies)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByDirectorAsync(horrorMovie.Director)).ReturnsAsync(horrorMovies);

            var query = new GetHorrorMovieByDirectorQuery(horrorMovie.Director);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}

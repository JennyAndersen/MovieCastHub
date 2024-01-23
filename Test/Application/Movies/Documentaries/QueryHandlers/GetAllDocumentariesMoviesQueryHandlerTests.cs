using Application.Movies.Queries.Documentaries.GetAllDocumentary;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Documentaries.QueryHandlers
{
    [TestFixture]
    public class GetAllDocumentariesMoviesQueryHandlerTests
    {
        private Mock<IMovieRepository> _movieRepositoryMock;
        private GetAllDocumentaryMoviesQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new GetAllDocumentaryMoviesQueryHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_GetAlLBirds_ReturnsCorrect([Frozen] List<Documentary> documentaries)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetAllDocumentaryMoviesAsync()).ReturnsAsync(documentaries);

            var query = new GetAllDocumentaryMoviesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Documentary>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}

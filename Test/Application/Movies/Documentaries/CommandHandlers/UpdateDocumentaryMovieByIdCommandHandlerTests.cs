using Application.Dtos.Movie;
using Application.Movies.Commands.Documentaries.UpdateDocumentaryMovieById;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Documentaries.CommandHandlers
{
    [TestFixture]
    public class UpdateDocumentaryMovieByIdCommandHandlerTests
    {
        private UpdateDocumentaryMovieByIdCommandHandler _handler;
        private Mock<IMovieRepository> _movieRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new UpdateDocumentaryMovieByIdCommandHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Updates_DocumentaryMovie([Frozen] Documentary initialDocumentaryMovie, UpdateMovieDto updatedDocumentaryMovie)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByIdAsync(initialDocumentaryMovie.MovieId)).ReturnsAsync(initialDocumentaryMovie);
            var command = new UpdateDocumentaryMovieByIdCommand(updatedDocumentaryMovie, initialDocumentaryMovie.MovieId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Movie>());
            _movieRepositoryMock.Verify(x => x.GetByIdAsync(initialDocumentaryMovie.MovieId), Times.Once);
        }
    }
}

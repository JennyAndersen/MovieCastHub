using Application.Movies.Commands.Documentaries.DeleteDocumentaryMovieById;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Documentaries.CommandHandlers
{
    [TestFixture]
    public class DeleteDocumentaryMovieByIdCommandHandlerTests
    {
        private Mock<IMovieRepository> _movieRepositoryMock;
        private DeleteDocumentaryMovieByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new DeleteDocumentaryMovieByIdCommandHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Delete_DocumentaryMovie_return_true([Frozen] Movie documentaryMovie)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByIdAsync(documentaryMovie.MovieId)).ReturnsAsync(documentaryMovie);

            // Act
            var command = new DeleteDocumentaryMovieByIdCommand(documentaryMovie.MovieId);
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _movieRepositoryMock.Verify(x => x.DeleteAsync(documentaryMovie.MovieId), Times.Once);
            Assert.That(result, Is.True);
        }
    }
}

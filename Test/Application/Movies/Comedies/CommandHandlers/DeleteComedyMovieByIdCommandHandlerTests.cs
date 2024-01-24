using Application.Movies.Commands.Comedies.DeleteComedyMovieById;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Comedies.CommandHandlers
{
    [TestFixture]
    public class DeleteComedyMovieByIdCommandHandlerTests
    {
        private Mock<IMovieRepository> _movieRepositoryMock;
        private DeleteComedyMovieByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new DeleteComedyMovieByIdCommandHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Delete_ComedyMovie_return_true([Frozen] Movie comedyMovie)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByIdAsync(comedyMovie.MovieId)).ReturnsAsync(comedyMovie);

            // Act
            var command = new DeleteComedyMovieByIdCommand(comedyMovie.MovieId);
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _movieRepositoryMock.Verify(x => x.DeleteAsync(comedyMovie.MovieId), Times.Once);
            Assert.That(result, Is.True);
        }
    }
}

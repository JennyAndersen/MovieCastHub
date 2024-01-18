using Application.Dtos.Movie;
using Application.Movies.Commands.Comedies.UpdateComedyMovieById;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Comedies.CommandHandlers
{
    [TestFixture]
    public class UpdateComedyMovieByIdCommandHandlerTests
    {
        private UpdateComedyMovieByIdCommandHandler _handler;
        private Mock<IMovieRepository> _movieRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new UpdateComedyMovieByIdCommandHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Updates_ComedyMovie([Frozen] Comedy initialComedyMovie, UpdateMovieDto updatedComedyMovie)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByIdAsync(initialComedyMovie.MovieId)).ReturnsAsync(initialComedyMovie);
            var command = new UpdateComedyMovieByIdCommand(updatedComedyMovie, initialComedyMovie.MovieId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Movie>());
            _movieRepositoryMock.Verify(x => x.GetByIdAsync(initialComedyMovie.MovieId), Times.Once);
        }
    }
}

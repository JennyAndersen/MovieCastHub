using Application.Dtos.Movie;
using Application.Movies.Commands.Horrors.UpdateHorrorMovie;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Horrors.CommandHandlers
{
    [TestFixture]
    public class UpdateHorrorMovieByIdCommandHandlerTests
    {

        private UpdateHorrorMovieByIdCommandHandler _handler;
        private Mock<IMovieRepository> _movieRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new UpdateHorrorMovieByIdCommandHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Updates_ComedyMovie([Frozen] Horror initialHorrorMovie, UpdateMovieDto updatedHorrorMovie)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByIdAsync(initialHorrorMovie.MovieId)).ReturnsAsync(initialHorrorMovie);
            var command = new UpdateHorrorMovieByIdCommand(updatedHorrorMovie, initialHorrorMovie.MovieId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Movie>());
            _movieRepositoryMock.Verify(x => x.GetByIdAsync(initialHorrorMovie.MovieId), Times.Once);
        }
    }
}

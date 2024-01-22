using Application.Movies.Commands.Horrors.DeleteHorrorMovieById;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Horrors.CommandHandlers
{
    [TestFixture]
    public class DeleteHorrorMovieByIdCommandHandlerTests
    {
        private Mock<IMovieRepository> _movieRepositoryMock;
        private DeleteHorrorMovieByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _handler = new DeleteHorrorMovieByIdCommandHandler(_movieRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Delete_HorrorMovie_return_true([Frozen] Movie horrorMovie)
        {
            // Arrange
            _movieRepositoryMock.Setup(x => x.GetByIdAsync(horrorMovie.MovieId)).ReturnsAsync(horrorMovie);

            // Act
            var command = new DeleteHorrorMovieByIdCommand(horrorMovie.MovieId);
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _movieRepositoryMock.Verify(x => x.DeleteAsync(horrorMovie.MovieId), Times.Once);
            Assert.That(result, Is.True);
        }
    }
}

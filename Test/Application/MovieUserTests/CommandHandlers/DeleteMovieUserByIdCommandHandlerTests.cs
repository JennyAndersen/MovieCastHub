using Application.MovieUsers.Commands.DeleteMovieUserById;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.MovieUserTests.CommandHandlers
{
    [TestFixture]
    public class DeleteMovieUserByIdCommandHandlerTests
    {
        private Mock<IMovieUserRepository> _movieUserRepositoryMock;
        private DeleteMovieUserByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _movieUserRepositoryMock = new Mock<IMovieUserRepository>();
            _handler = new DeleteMovieUserByIdCommandHandler(_movieUserRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_DeleteMovieUser_return_true([Frozen] UserMovie userMovie)
        {
            // Arrange
            var command = new DeleteMovieUserByIdCommand(userMovie.UserMovieId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
            _movieUserRepositoryMock.Verify(x => x.DeleteByIdAsync(userMovie.UserMovieId), Times.Once);
        }
    }
}

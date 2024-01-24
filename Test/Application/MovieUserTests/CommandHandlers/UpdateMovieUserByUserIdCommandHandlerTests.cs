using Application.MovieUsers.Commands.UpdateMovieUserByUserId;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.MovieUserTests.CommandHandlers
{
    [TestFixture]
    public class UpdateMovieUserByUserIdCommandHandlerTests
    {
        private Mock<IMovieUserRepository> _mockMovieUserRepository;
        private UpdateMovieUserByUserIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockMovieUserRepository = new Mock<IMovieUserRepository>();
            _handler = new UpdateMovieUserByUserIdCommandHandler(_mockMovieUserRepository.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_UpdatesAnimalUser(
            [Frozen] UserMovie initialMovieUser)
        {
            // Arrange
            _mockMovieUserRepository.Setup(x => x.GetMovieUserByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid movieUserId) => new UserMovie { UserMovieId = movieUserId });

            var command = new UpdateMovieUserByUserIdCommand(initialMovieUser.UserRating);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
        }

    }
}

using Application.Dtos.MovieUser;
using Application.MovieUsers.Commands.AddMovieUser;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.MovieUserTests.CommandHandlers
{
    [TestFixture]
    public class AddMovieUserCommandHandlerTests
    {
        private AddMovieUserCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var mockMovieUserRepository = new Mock<IMovieUserRepository>();
            mockMovieUserRepository.Setup(x => x.AddMovieUserAsync(It.IsAny<UserMovie>()))
                .ReturnsAsync(true);
            _handler = new AddMovieUserCommandHandler(mockMovieUserRepository.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Adds_MovieUser([Frozen] MovieUserDto newMovieUser)
        {
            // Arrange
            var command = new AddMovieUserCommand(newMovieUser);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}

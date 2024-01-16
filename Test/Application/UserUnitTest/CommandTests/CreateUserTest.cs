using Application.Dtos.User;
using Application.Users.Commands.CreateUser;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;

namespace Test.Application.UserUnitTest.CommandTests
{
    [TestFixture]
    public class CreateUserTest
    {
        [Test]
        public async Task CreateUser_ShouldCreateUser_WhenCalledWithValidData()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userDto = new UserDto { Username = "TestUser", Password = "TestPassword" };
            var command = new CreateUserCommand(userDto);
            var handler = new CreateUserCommandHandler(mockUserRepository.Object);

            mockUserRepository.Setup(repo => repo.CreateUserAsync(It.IsAny<User>()))
                              .ReturnsAsync(new User { Username = userDto.Username, Password = userDto.Password });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Username, Is.EqualTo(userDto.Username));
            mockUserRepository.Verify(repo => repo.CreateUserAsync(It.IsAny<User>()), Times.Once);
        }
    }
}

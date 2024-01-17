using Application.Dtos.User;
using Application.Users.Commands.CreateUser;
using Domain.Models;
using FluentAssertions;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;


namespace Test.Application.UserUnitTest.CommandTests
{
    [TestFixture]
    public class CreateUserCommandHandlerTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private CreateUserCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new CreateUserCommandHandler(_mockUserRepository.Object);
        }

        [Test, CustomAutoData]
        public async Task CreateUser_ShouldCreateUser_WhenCalledWithValidData(UserDto userDto)
        {
            // Arrange
            var command = new CreateUserCommand(userDto);
            _mockUserRepository.Setup(repo => repo.CreateUserAsync(It.IsAny<User>()))
                              .ReturnsAsync(new User { Username = userDto.Username, Password = userDto.Password });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Username.Should().Be(userDto.Username);
            _mockUserRepository.Verify(repo => repo.CreateUserAsync(It.IsAny<User>()), Times.Once);
        }
    }
}

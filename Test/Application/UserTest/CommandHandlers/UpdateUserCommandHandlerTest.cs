

using Application.Dtos.User;
using Application.Users.Commands.UpdateUser;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Service;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.UserUnitTest.CommandTests
{
    [TestFixture]
    public class UpdateUserCommandHandlerTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private UpdateUserCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _handler = new UpdateUserCommandHandler(_mockUserRepository.Object);
        }

        [Test, CustomAutoData]
        public async Task UpdateUser_ShouldUpdateUser_WhenCalledWithValidData(Guid userId, UserUpdateDto userUpdateDto, User existingUser)
        {
            // Arrange
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(existingUser);

            _mockUserRepository.Setup(repo => repo.UpdateUserAsync(It.IsAny<User>()))
                               .Callback((User user) => existingUser.Password = user.Password)
                               .Returns(Task.CompletedTask);
            var command = new UpdateUserCommand(userId, userUpdateDto);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockUserRepository.Verify(repo => repo.UpdateUserAsync(It.Is<User>(u => existingUser.Password == u.Password && !string.IsNullOrEmpty(u.Password))), Times.Once);
        }
    }
}

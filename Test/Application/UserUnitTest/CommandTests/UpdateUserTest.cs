

using Application.Dtos.User;
using Application.Users.Commands.UpdateUser;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;

namespace Test.Application.UserUnitTest.CommandTests
{
    [TestFixture]
    public class UpdateUserTest
    {
        [Test]
        public async Task UpdateUser_ShouldUpdateUser_WhenCalledWithValidData()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userId = Guid.NewGuid();
            var userUpdateDto = new UserUpdateDto { Password = "NewPassword" };
            var existingUser = new User { UserId = userId, Username = "ExistingUser", Password = "OldPassword" };

            mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(existingUser);
            mockUserRepository.Setup(repo => repo.UpdateUserAsync(It.IsAny<User>()))
                              .Callback<User>(u => existingUser = u)
                              .Returns(Task.CompletedTask);
            var handler = new UpdateUserCommandHandler(mockUserRepository.Object);

            var updateUserCommand = new UpdateUserCommand(userId, userUpdateDto);

            // Act
            await handler.Handle(updateUserCommand, CancellationToken.None);

            // Assert
            mockUserRepository.Verify(repo => repo.GetUserByIdAsync(userId), Times.Once);
            mockUserRepository.Verify(repo => repo.UpdateUserAsync(It.IsAny<User>()), Times.Once);

            Assert.That(existingUser.Password, Is.EqualTo(userUpdateDto.Password), "Password should be updated to the new value.");
        }
    }
}

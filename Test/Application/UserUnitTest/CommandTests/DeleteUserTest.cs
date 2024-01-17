using Application.Users.Commands.DeleteUser;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;


namespace Test.Application.UserUnitTest.CommandTests
{
    [TestFixture]
    public class DeleteUserTest
    {
        [Test]
        public async Task DeleteUser_ShouldDeleteUser_WhenUserExists()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userId = Guid.NewGuid();
            var user = new User { UserId = userId, Username = "TestUser", Password = "TestPassword" };

            mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(user);
            mockUserRepository.Setup(repo => repo.DeleteUserAsync(userId)).Returns(Task.CompletedTask);

            var handler = new DeleteUserCommandHandler(mockUserRepository.Object);
            var command = new DeleteUserCommand(userId);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            mockUserRepository.Verify(repo => repo.GetUserByIdAsync(userId), Times.Once);
            mockUserRepository.Verify(repo => repo.DeleteUserAsync(userId), Times.Once);
        }
    }
}

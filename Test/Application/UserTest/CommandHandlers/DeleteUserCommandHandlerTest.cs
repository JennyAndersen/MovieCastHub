
using Application.Users.Commands.DeleteUser;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;


namespace Test.Application.UserUnitTest.CommandTests
{
    [TestFixture]
    public class DeleteUserCommandHandlerTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private DeleteUserCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new DeleteUserCommandHandler(_mockUserRepository.Object);
        }

        [Test, CustomAutoData]
        public async Task DeleteUser_ShouldDeleteUser_WhenUserExists(Guid userId, User existingUser)
        {
            //Arrange
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(existingUser);
            _mockUserRepository.Setup(repo => repo.DeleteUserAsync(userId)).Returns(Task.CompletedTask);
            var command = new DeleteUserCommand(userId);

            //Act
            await _handler.Handle(command, CancellationToken.None);


            //Assert
            _mockUserRepository.Verify(repo => repo.GetUserByIdAsync(userId), Times.Once);
            _mockUserRepository.Verify(repo => repo.DeleteUserAsync(userId), Times.Once);
        }
    }
}

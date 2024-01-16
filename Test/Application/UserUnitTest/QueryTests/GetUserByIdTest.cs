using Application.Users.Querys.GetUsersById;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;

namespace Test.Application.UserUnitTest.QueryTests
{
    [TestFixture]
    public class GetUsersByIdTests
    {
        [Test]
        public async Task GetUserById_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var userId = Guid.NewGuid();
            var user = new User { UserId = userId, Username = "TestUser", Password = "TestPassword" };
            mockRepo.Setup(repo => repo.GetUserByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);
            var handler = new GetUsersByIdQueryHandler(mockRepo.Object);

            // Act
            var result = await handler.Handle(new GetUsersByIdQuery(userId), CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(userId));
            Assert.That(result.Username, Is.EqualTo("TestUser"));
            Assert.That(result.Password, Is.EqualTo("TestPassword"));
        }
    }
}

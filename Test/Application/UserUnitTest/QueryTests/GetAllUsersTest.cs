using Application.Users.Querys.GetAllUsers;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;


namespace Test.Application.UserUnitTest.QueryTests
{
    [TestFixture]
    public class GetAllUsersTest
    {
        [Test]
        public async Task GetAllUsers_ShouldReturnAllUsers()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var users = new List<User>
        {
            new User { UserId = Guid.NewGuid(), Username = "User1", Password = "Password1" },
            new User { UserId = Guid.NewGuid(), Username = "User2", Password = "Password2" }
        };
            mockRepo.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(users);
            var handler = new GetAllUsersQueryHandler(mockRepo.Object);

            // Act
            var result = await handler.Handle(new GetAllUsersQuery(), CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Username, Is.EqualTo("User1"));
            Assert.That(result[1].Username, Is.EqualTo("User2"));
        }
    }
}

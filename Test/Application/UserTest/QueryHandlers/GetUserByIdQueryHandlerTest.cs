#nullable disable
using Application.Users.Querys.GetUsersById;
using Domain.Models;
using FluentAssertions;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.UserUnitTest.QueryTests
{
    [TestFixture]
    public class GetUsersByIdQueryHandlerTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private GetUsersByIdQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new GetUsersByIdQueryHandler(_mockUserRepository.Object);
        }

        [Test, CustomAutoData]
        public async Task GetUserById_ShouldReturnUser_WhenUserExists(Guid userId, User user)
        {
            // Arrange
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(user);
            var query = new GetUsersByIdQuery(userId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(user);
        }
    }
}

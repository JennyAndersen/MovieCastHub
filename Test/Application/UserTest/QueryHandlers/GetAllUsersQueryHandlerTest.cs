using Application.Users.Commands.DeleteUser;
using Application.Users.Querys.GetAllUsers;
using Domain.Models;
using FluentAssertions;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;


namespace Test.Application.UserUnitTest.QueryTests
{
    [TestFixture]
    public class GetAllUsersQueryHandlerTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private GetAllUsersQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new GetAllUsersQueryHandler(_mockUserRepository.Object);
        }

        [Test, CustomAutoData]
        public async Task GetAllUsers_ShouldReturnAllUsers(List<User> users)
        {
            //Arrange
            _mockUserRepository.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(users);
            var query = new GetAllUsersQuery();

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            result.Should().BeEquivalentTo(users);
        }
    }
}

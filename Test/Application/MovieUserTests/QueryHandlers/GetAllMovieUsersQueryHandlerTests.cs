using Application.MovieUsers.Queries.GetAll;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.MovieUserTests.QueryHandlers
{
    [TestFixture]
    public class GetAllMovieUsersQueryHandlerTests
    {
        private Mock<IMovieUserRepository> _movieUserRepositoryMock;
        private GetAllMovieUsersQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _movieUserRepositoryMock = new Mock<IMovieUserRepository>();
            _handler = new GetAllMovieUsersQueryHandler(_movieUserRepositoryMock.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_GetAllMovieUsers_ReturnsCorrect([Frozen] List<UserMovie> movieUsers)
        {
            // Arrange
            _movieUserRepositoryMock.Setup(x => x.GetAllMovieUsersAsync()).ReturnsAsync(movieUsers);
            var query = new GetAllMovieUsersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Asserts
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<UserMovie>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}

using Application.Dtos.Movie;
using Application.Movies.Commands.Comedies.AddComedyMovie;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Comedies.CommandHandlers
{
    [TestFixture]
    internal class AddComedyMovieCommandHandlerTests
    {
        private AddComedyMovieCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var mockMovieRepository = new Mock<IMovieRepository>();
            _handler = new AddComedyMovieCommandHandler(mockMovieRepository.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Adds_ComedyMovie([Frozen] ComedyMovieDto newComedy)
        {
            // Arrange
            var command = new AddComedyMovieCommand(newComedy);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Movie>());
            Assert.That(result.MovieId, Is.Not.EqualTo(Guid.Empty));
        }
    }
}

using Application.Dtos.Movie;
using Application.Movies.Commands.Horrors.AddHorrorMovie;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Horrors.CommandHandlers
{
    [TestFixture]
    public class AddHorrorMovieCommandHandlerTests
    {
        private AddHorrorMovieCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var mockMovieRepository = new Mock<IMovieRepository>();
            _handler = new AddHorrorMovieCommandHandler(mockMovieRepository.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Adds_HorrorMovie([Frozen] HorrorMovieDto newHorror)
        {
            // Arrange
            var command = new AddHorrorMovieCommand(newHorror);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Movie>());
            Assert.That(result.MovieId, Is.Not.EqualTo(Guid.Empty));
        }

    }
}

using Application.Dtos.Movie;
using Application.Movies.Commands.Documentaries.AddDocumentaryMovie;
using AutoFixture.NUnit3;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Movies.Documentaries.CommandHandlers
{
    [TestFixture]
    public class AddDocumentaryMovieCommandHandlerTests
    {
        private AddDocumentaryMovieCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var mockMovieRepository = new Mock<IMovieRepository>();
            _handler = new AddDocumentaryMovieCommandHandler(mockMovieRepository.Object);
        }

        [Test]
        [CustomAutoData]
        public async Task WHEN_Handle_THEN_Adds_DocumentaryMovie([Frozen] DocumentaryMovieDto newDocumentary)
        {
            // Arrange
            var command = new AddDocumentaryMovieCommand(newDocumentary);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Movie>());
            Assert.That(result.MovieId, Is.Not.EqualTo(Guid.Empty));
        }
    }
}

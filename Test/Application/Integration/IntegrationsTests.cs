using API.Controllers;
using Application.Dtos.User;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.UserLogin;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Test.TestHelpers;

namespace Test.Application.Integration
{
    [TestFixture]
    public class IntegrationsTests
    {
        private Mock<IMediator> _mediatorMock;
        private UserController _controller;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = CreateControllerInstance();

        }

        private UserController CreateControllerInstance()
        {
            return new UserController(_mediatorMock.Object);
        }


        [Test]
        [CustomAutoData]
        public async Task CanRegisterAndLoginUser(UserDto userDto)
        {
            // Arrange

            _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User
                {
                    UserId = Guid.NewGuid(),
                    Username = userDto.Username,
                    Password = userDto.Password,
                });

            _mediatorMock.Setup(m => m.Send(It.IsAny<LoginQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("validAccessToken");
            // Act
            var registrationResult = await _controller.CreateUser(userDto);
            var loginResult = await _controller.Login(userDto);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(registrationResult, Is.InstanceOf<OkObjectResult>());
                Assert.IsNotNull(loginResult);
                Assert.That(loginResult, Is.InstanceOf<OkObjectResult>());
            });

        }


    }
}

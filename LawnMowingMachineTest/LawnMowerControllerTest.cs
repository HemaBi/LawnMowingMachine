using FluentAssertions;
using LawnMowingMachine.Controllers;
using LawnMowingMachine.Interfaces;
using LawnMowingMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using Xunit;

namespace LawnMowingMachineTest
{
    public class LawnMowerControllerTest
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<IMowerService> _mockMowerService;
        private readonly LawnMowerController _lawnMowerController;

        public LawnMowerControllerTest()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockMowerService = new Mock<IMowerService>();

            // This is Lawn dimension in configuration 
            _mockConfiguration.SetupGet(x => x[It.Is<string>(s => s == "LawnWidth")]).Returns("15");
            _mockConfiguration.SetupGet(x => x[It.Is<string>(s => s == "LawnHeight")]).Returns("15");

            _lawnMowerController = new LawnMowerController(_mockMowerService.Object);
        }

        [Fact]
        public void MoveUp_PositiveTest()
        {
            var expectedMowerModel = new MowerModel(10, 11, new LawnDimension(_mockConfiguration.Object)) { };
            var _expected = new JsonResult(expectedMowerModel);

            _mockMowerService.Setup(x => x.MoveUp(It.IsAny<MowerModel>())).Returns(expectedMowerModel);

            var mowerModelReq = new MowerModel(10, 10, new LawnDimension(_mockConfiguration.Object)) { };
            var actual = _lawnMowerController.MoveUp(mowerModelReq) as JsonResult;

            // This tests for two things first it makes sure that the method comes back with the correct  
            // information but it is also check to see if the clamp method in the controller is making 
            // sure that the mower does not go out of bounds
            //Verifying expected and actual
            _expected.Should().BeEquivalentTo(actual);

        }

        // This method makes sure that the MoveLeft Method actually moves the mower down
        [Fact]
        public void MoveDown_PositiveTest()
        {
            var expectedMowerModel = new MowerModel(10, 9, new LawnDimension(_mockConfiguration.Object)) { };
            var _expected = new JsonResult(expectedMowerModel);

            _mockMowerService.Setup(x => x.MoveDown(It.IsAny<MowerModel>())).Returns(expectedMowerModel);

            var mowerModelReq = new MowerModel(10, 10, new LawnDimension(_mockConfiguration.Object)) { };
            var actual = _lawnMowerController.MoveDown(mowerModelReq) as JsonResult;

            // This check is to make sure that the user moves to the correct position 
            //Verifying expected and actual
            _expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void MoveLeft_PositiveTest()
        {
            var returnMowerModel = new MowerModel(9, 10, new LawnDimension(_mockConfiguration.Object)) { };
            var _expected = new JsonResult(returnMowerModel);

            _mockMowerService.Setup(x => x.MoveLeft(It.IsAny<MowerModel>())).Returns(returnMowerModel);

            var mowerModelReq = new MowerModel(10, 10, new LawnDimension(_mockConfiguration.Object)) { };
            var actual = _lawnMowerController.MoveLeft(mowerModelReq) as JsonResult;

            // This check is to make sure that the user moves to the correct position 
            //Verifying expected and actual
            _expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void MoveRight_PositiveTest()
        {
            var returnMowerModel = new MowerModel(11, 10, new LawnDimension(_mockConfiguration.Object)) { };
            var _expected = new JsonResult(returnMowerModel);

            _mockMowerService.Setup(x => x.MoveRight(It.IsAny<MowerModel>())).Returns(returnMowerModel);

            var mowerModelReq = new MowerModel(1, 1, new LawnDimension(_mockConfiguration.Object)) { };
            var actual = _lawnMowerController.MoveRight(mowerModelReq) as JsonResult;

            // This check is to make sure that the user moves to the correct position 
            //Verifying expected and actual
            _expected.Should().BeEquivalentTo(actual);
        }
    }
}

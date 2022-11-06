using LawnMowingMachine.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using Xunit;

namespace LawnMowingMachineTest
{
    public class MowerModelTest
    {
        private readonly Mock<IConfiguration> _mockConfiguration;

        public MowerModelTest()
        {
            _mockConfiguration = new Mock<IConfiguration>();

            // This is Lawn dimension in configuration 
            _mockConfiguration.SetupGet(x => x[It.Is<string>(s => s == "LawnWidth")]).Returns("15");
            _mockConfiguration.SetupGet(x => x[It.Is<string>(s => s == "LawnHeight")]).Returns("15");
        }

        [Fact]
        public void MowerMachine_PositionX_NegativeTest()
        {
            Assert.Throws<ArgumentException>(() => new MowerModel(-1, 10, new LawnDimension(_mockConfiguration.Object)) { Status = $"mower orientation is north and current position of mower is -1 and 10" });
        }

        [Fact]
        public void MowerMachine_PositionY_NegativeTest()
        {
            Assert.Throws<ArgumentException>(() => new MowerModel(10, -1, new LawnDimension(_mockConfiguration.Object)) { Status = $"mower orientation is north and current position of mower is 10 and -1" });
        }

        [Fact]
        public void LawnDimension_null_NegativeTest()
        {
            Assert.Throws<ArgumentException>(() => new MowerModel(10, 10, null) { Status = $"mower orientation is north and current position of mower is 10 and 10" });
        }
    }
}

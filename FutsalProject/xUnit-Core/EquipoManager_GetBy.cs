using CoreDapper.Abstract;
using CoreDapper.Concrete;
using System;
using Xunit;

namespace xUnit_Core
{
    public class EquipoManager_GetBy
    {
        private readonly IEquipoManager _equipoManager;

        public EquipoManager_GetBy()
        {
            _equipoManager = new EquipoManager();
        }

        [Fact]
        public void ReturnFalseGivenValueLowerThan0()
        {
            var result = _equipoManager.GetById(-1);
            Assert.False(result != null, "Failure - not allowed negative values");
        }

        [Fact]
        public void ReturnFalseGivenValueEqual0()
        {
            var result = _equipoManager.GetById(0);
            Assert.False(result != null, "Failure - zero not allowed");
        }

        [Fact]
        public void ReturnEquipoGivenValue1()
        {
            var result = _equipoManager.GetById(1);
            Assert.True(result != null, "Pass");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ReturnFalseGivenValuesLessThan1(int value)
        {
            var result = _equipoManager.GetById(value);
            Assert.False(result != null, $"Failure {value} invalid value");
        }
    }
}

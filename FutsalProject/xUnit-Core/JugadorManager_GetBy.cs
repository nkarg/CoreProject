using CoreDapper.Abstract;
using CoreDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace xUnit_Core
{
    public class JugadorManager_GetBy
    {
        private readonly IJugadorManager _jugadorManager;

        public JugadorManager_GetBy()
        {
            _jugadorManager = new JugadorManager();
        }

        [Fact]
        public void ReturnFalseGivenValueLowerThan0()
        {
            var result = _jugadorManager.GetById(-1);
            Assert.False(result != null, "Failure - not allowed negative values");
        }

        [Fact]
        public void ReturnFalseGivenValueEqual0()
        {
            var result = _jugadorManager.GetById(0);
            Assert.False(result != null, "Failure - zero not allowed");
        }

        [Fact]
        public void ReturnEquipoGivenValue1()
        {
            var result = _jugadorManager.GetById(1);
            Assert.True(result != null, "Pass");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ReturnFalseGivenValuesLessThan1(int value)
        {
            var result = _jugadorManager.GetById(value);
            Assert.False(result != null, $"Failure {value} invalid value");
        }
    }
}

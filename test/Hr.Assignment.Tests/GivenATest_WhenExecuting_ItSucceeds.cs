using System;
using Xunit;

namespace Hr.Assignment.Tests
{
    public class WhenExecutingAXUnitTest
    {
        [Fact]
        public void GivenABooleanTrue_ThenItIsTrue()
        {
            var value = true;

            Assert.Equal(value, true);
        } 
    }
}

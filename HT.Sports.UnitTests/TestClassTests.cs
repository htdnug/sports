using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HT.Sports.UnitTests
{
    public class TestClassTests
    {
        [Fact]
        public void Test1()
        {
            var sut = new TestClass();
            var actual = sut.Run();
            var expected = 1;
            Assert.Equal(expected, actual);
        }
    }
}

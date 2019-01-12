using HTDNUG.Sports.Common;
using Xunit;

namespace Sports.Common.UnitsTests
{
    public class TestClassTests
    {
        [Fact]
        public void Test1()
        {
            var sut = new TestClass();
            var actual = sut.RunTest();
            var expected = 1;
            Assert.Equal(expected, actual);
        }
    }
}

using System;
using Xunit;

namespace EmployeesApiIntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 10, b = 20;
            int answer = a + b;

            Assert.Equal(30, answer);

        }

        [Theory]
        [InlineData(2,2,4)]
        [InlineData(2,3,5)]
        [InlineData(10,-5, 5)]
        public void IKnowHowToadd(int a, int b, int expected)
        {
            int answer = a + b;
            Assert.Equal(expected, answer);
        }
    }
}

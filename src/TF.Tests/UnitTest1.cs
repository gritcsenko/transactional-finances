using FluentAssertions;
using Xunit;

namespace TF.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            true.Should().NotBe(false);
        }
    }
}

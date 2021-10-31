namespace TF.Tests;

public class SanityChecks
{
    [Fact]
    public void True_Should_NotBeFalse()
    {
        true.Should().NotBe(false);
    }
}

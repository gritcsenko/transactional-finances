using TF.Models;

namespace TF.Tests;

public class AccountListContainerTests
{
    public AccountListContainerTests()
    {
    }

    [Fact]
    public void Should_BeEmpty_WhenCreated()
    {
        var sut = new AccountListContainer();

        sut.Should().BeEmpty();
    }

    [Fact]
    public void Should_HaveZeroCount_WhenCreated()
    {
        var sut = new AccountListContainer();

        sut.Count.Should().Be(0);
    }

    [Fact]
    public void ToString_Should_HaveSquareBraces()
    {
        var sut = new AccountListContainer();

        var actual = sut.ToString();

        actual.Should().Be("[]");
    }
}

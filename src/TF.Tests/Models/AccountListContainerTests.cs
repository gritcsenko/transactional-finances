using TF.Models;

namespace TF.Tests;

public class AccountListContainerTests
{
    public AccountListContainerTests()
    {
    }

    [Fact]
    public void EmptyContainer_Should_BeEmpty()
    {
        var sut = AccountListContainer.Empty;

        sut.Should().BeEmpty();
    }

    [Fact]
    public void EmptyContainer_Should_HaveZeroCount()
    {
        var sut = AccountListContainer.Empty;

        sut.Count.Should().Be(0);
    }

    [Fact]
    public void ToString_Should_HaveSquareBraces()
    {
        var sut = AccountListContainer.Empty;

        var actual = sut.ToString();

        actual.Should().Be("[]");
    }
}

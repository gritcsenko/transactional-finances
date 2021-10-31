using TF.Models;

namespace TF.Tests;

public class AccountListTests
{
    private readonly Fixture _fixture;
    private readonly string _name;

    public AccountListTests()
    {
        _fixture = new Fixture();
        _name = _fixture.Create<string>();
    }

    [Fact]
    public void Name_Should_BePreserved()
    {
        var sut = new AccountList(_name);

        sut.Name.Should().Be(_name);
    }

    [Fact]
    public void Should_BeEmpty_WhenCreated()
    {
        var sut = new AccountList(_name);

        sut.Should().BeEmpty();
    }

    [Fact]
    public void Should_HaveZeroCount_WhenCreated()
    {
        var sut = new AccountList(_name);

        sut.Count.Should().Be(0);
    }

    [Fact]
    public void ToString_Should_HaveName()
    {
        var sut = new AccountList(_name);

        var actual = sut.ToString();

        actual.Should().Be($"{_name}: []");
    }

    [Fact]
    public void TwoEmptyLists_Should_BeEqual_When_NameIsTheSame()
    {
        var a = new AccountList(_name);
        var b = new AccountList(_name);

        a.Equals(b).Should().BeTrue();
    }

    [Fact]
    public void TwoEmptyLists_Should_NotBeEqual_When_NamesAreDifferent()
    {
        var a = new AccountList(_name);
        var b = new AccountList(_fixture.Create<string>());

        a.Equals(b).Should().BeFalse();
    }

    [Fact]
    public void TwoEmptyLists_Should_HaveSameHashCode_When_NameIsTheSame()
    {
        var a = new AccountList(_name);
        var b = new AccountList(_name);

        a.GetHashCode().Should().Be(b.GetHashCode());
    }
}

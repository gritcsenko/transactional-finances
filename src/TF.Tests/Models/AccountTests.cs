using TF.Models;

namespace TF.Tests;

public class AccountTests 
{
    private readonly Fixture _fixture;
    private readonly string _name;

    public AccountTests()
    {
        _fixture = new Fixture();
        _name = _fixture.Create<string>();
    }

    [Fact]
    public void Name_Should_BePreserved()
    {
        var sut = new Account(_name);

        sut.Name.Should().Be(_name);     
    }

    [Fact]
    public void TwoAccounts_Should_BeEqual_When_NameIsTheSame()
    {
        var a = new Account(_name);
        var b = new Account(_name);

        a.Equals(b).Should().BeTrue();
    }

    [Fact]
    public void TwoAccounts_Should_NotBeEqual_When_NamesAreDifferent()
    {
        var a = new Account(_name);
        var b = new Account(_fixture.Create<string>());

        a.Equals(b).Should().BeFalse();
    }
}

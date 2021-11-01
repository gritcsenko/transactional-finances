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
    public void Name_Should_BePreserved_WhenUsingEmpty()
    {
        var sut = AccountList.Empty(_name);

        sut.Name.Should().Be(_name);
    }

    [Fact]
    public void Should_BeEmpty_WhenUsingEmpty()
    {
        var sut = AccountList.Empty(_name);

        sut.Should().BeEmpty();
    }

    [Fact]
    public void Should_HaveZeroCount_WhenUsingEmpty()
    {
        var sut = AccountList.Empty(_name);

        sut.Count.Should().Be(0);
    }

    [Fact]
    public void ToString_Should_HaveName()
    {
        var sut = AccountList.Empty(_name);

        var actual = sut.ToString();

        actual.Should().Be($"{_name}: []");
    }

    [Fact]
    public void TwoEmptyLists_Should_BeEqual_When_NameIsTheSame()
    {
        var a = AccountList.Empty(_name);
        var b = AccountList.Empty(_name);

        a.Equals(b).Should().BeTrue();
    }

    [Fact]
    public void TwoEmptyLists_Should_NotBeEqual_When_NamesAreDifferent()
    {
        var a = AccountList.Empty(_name);
        var b = AccountList.Empty(_fixture.Create<string>());

        a.Equals(b).Should().BeFalse();
    }

    [Fact]
    public void TwoEmptyLists_Should_HaveSameHashCode_When_NameIsTheSame()
    {
        var a = AccountList.Empty(_name);
        var b = AccountList.Empty(_name);

        a.GetHashCode().Should().Be(b.GetHashCode());
    }

    [Fact]
    public void Add_Should_ReturnNewInstance()
    {
        var sut = AccountList.Empty(_name);

        var actual = sut.Add(new Account(_fixture.Create<string>()));

        actual.Should().NotBeSameAs(sut);
        sut.Should().BeEmpty();
    }

    [Fact]
    public void Add_Should_AddToTheReturned()
    {
        var sut = AccountList.Empty(_name);
        var account = new Account(_fixture.Create<string>());

        var actual = sut.Add(account);

        actual.Should().ContainSingle()
            .Which.Should().BeSameAs(account);
    }

    [Fact]
    public void Add_Should_AddUniqueOnlyToTheReturned()
    {
        var name = _fixture.Create<string>();
        var account = new Account(name);
        var sut = AccountList.Empty(_name).Add(account);

        var actual = sut.Add(new Account(name));

        actual.Should().BeSameAs(sut);
    }

    [Fact]
    public void ToString_Should_HaveNameAndAccount()
    {
        var name = _fixture.Create<string>();
        var account = new Account(name);
        var sut = AccountList.Empty(_name).Add(account);

        var actual = sut.ToString();

        actual.Should().Be($"{_name}: [{name}]");
    }

    [Fact]
    public void ToString_Should_HaveNameAndAccounts()
    {
        var names = _fixture.CreateMany<string>();
        var accounts = names.Select(name => new Account(name));
        var sut = AccountList.Empty(_name).AddRange(accounts);

        var actual = sut.ToString();

        actual.Should().ContainAll(names);
    }

    [Fact]
    public void TwoEmptyLists_Should_HaveSameHashCode_When_NameIsTheSameAndSameAccounts()
    {
        var names = _fixture.CreateMany<string>();
        var accounts = names.Select(name => new Account(name));
        var a = AccountList.Empty(_name).AddRange(accounts);
        var b = AccountList.Empty(_name).AddRange(accounts.Reverse());

        a.GetHashCode().Should().Be(b.GetHashCode());
    }
}

using FluentAssertions;
using NUnit.Framework;

namespace EasyCompany.GenericResult.Core.UnitTests;

internal class ErrorTests
{

    [Test]
    public void ShouldCreateErrorObject_WhenConstructorIsCalled()
    {
        var code = "myCode";
        var message = "myMessage";

        var error = new Error(code, message);

        error.Code.Should().Be(code);
        error.Message.Should().Be(message);
    }

    [Test]
    public void ErrorShouldBeCode_WhenToStringIsCalled()
    {
        var code = "myCode";
        var message = "myMessage";

        var error = new Error(code, message);
        var errorString = error.ToString();

        errorString.Should().Be(code);
    }

    [Test]
    public void SameError_ShouldPassed_WhenCompared()
    {
        var code = "myCode";
        var message = "myMessage";

        var errorOne = new Error(code, message);
        var errorTwo = new Error(code, message);

        var result = Error.Equals(errorOne, errorTwo);

        result.Should().BeTrue();
    }

    [Test]
    public void SameError_ShouldPassed_WhenComparedToOther()
    {
        var code = "myCode";
        var message = "myMessage";

        var errorOne = new Error(code, message);
        var errorTwo = new Error(code, message);

        var result = errorOne.Equals(errorTwo);

        result.Should().BeTrue();
    }

    [Test]
    public void SameError_ShouldPassed_WhenComparedToOtherEqualsSign()
    {
        var code = "myCode";
        var message = "myMessage";

        var errorOne = new Error(code, message);
        var errorTwo = new Error(code, message);

        var result = errorOne == errorTwo;

        result.Should().BeTrue();
    }
}
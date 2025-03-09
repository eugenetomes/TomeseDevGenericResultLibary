using NUnit.Framework;
using Shouldly;

namespace EasyCompany.GenericResult.Core.UnitTests;

internal class ErrorTests
{

    [Test]
    public void ShouldCreateErrorObject_WhenConstructorIsCalled()
    {
        var code = "myCode";
        var message = "myMessage";
        var errorType = ErrorType.Failure;

        var error = new Error(code, message, errorType);

        error.Code.ShouldBe(code);
        error.Message.ShouldBe(message);
        error.Type.ShouldBe(errorType);
    }

    [Test]
    public void ErrorShouldBeCode_WhenToStringIsCalled()
    {
        var code = "myCode";
        var message = "myMessage";
        var errorType = ErrorType.Failure;

        var error = new Error(code, message, errorType);
        var errorString = error.ToString();

        error.Code.ShouldBe(code);
    }

    [Test]
    public void SameError_ShouldPassed_WhenCompared()
    {
        var code = "myCode";
        var message = "myMessage";
        var errorType = ErrorType.Failure;

        var errorOne = new Error(code, message, errorType);
        var errorTwo = new Error(code, message, errorType);

        var result = Error.Equals(errorOne, errorTwo);

        result.ShouldBeTrue();
    }

    [Test]
    public void SameError_ShouldPassed_WhenComparedToOther()
    {
        var code = "myCode";
        var message = "myMessage";
        var errorType = ErrorType.Failure;


        var errorOne = new Error(code, message, errorType);
        var errorTwo = new Error(code, message, errorType);

        var result = errorOne.Equals(errorTwo);

        result.ShouldBeTrue();
    }

    [Test]
    public void SameError_ShouldPassed_WhenComparedToOtherEqualsSign()
    {
        var code = "myCode";
        var message = "myMessage";
        var errorType = ErrorType.Failure;

        var errorOne = new Error(code, message, errorType);
        var errorTwo = new Error(code, message, errorType);

        var result = errorOne == errorTwo;

        result.ShouldBeTrue();
    }

    [Test]
    public void FailureError_ShouldPassed_WhenFailureIsCalled()
    {
        var code = "myCode";
        var message = "myMessage";

        var error = Error.Failure(code, message);

        error.Type.ShouldBe(ErrorType.Failure);
    }


    [Test]
    public void NotFoundError_ShouldPassed_WhenNotFoundIsCalled()
    {
        var code = "myCode";
        var message = "myMessage";

        var error = Error.NotFound(code, message);

        error.Type.ShouldBe(ErrorType.NotFound);
    }

    [Test]
    public void NotFoundProblem_ShouldPassed_WhenProblemIsCalled()
    {
        var code = "myCode";
        var message = "myMessage";

        var error = Error.Problem(code, message);

        error.Type.ShouldBe(ErrorType.Problem);
    }

    [Test]
    public void NotConflict_ShouldPassed_WhenConflictIsCalled()
    {
        var code = "myCode";
        var message = "myMessage";

        var error = Error.Conflict(code, message);

        error.Type.ShouldBe(ErrorType.Conflict);
    }

    [Test]
    public void Exception_ShouldPassed_WhenExceptionIsCalled()
    {
        var exceptionMessage = "My Exception has been thrown";

        try
        {
            throw new Exception(exceptionMessage);
        }
        catch (Exception ex)
        {
            var error = Error.Exception(ex);
            error.Code.ShouldBe("Exception");
            error.Message.ShouldBe(ex.Message);
            error.Type.ShouldBe(ErrorType.Exception);
        }
    }
}
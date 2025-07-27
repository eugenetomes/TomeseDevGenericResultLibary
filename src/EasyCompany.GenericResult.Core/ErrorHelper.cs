using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCompany.GenericResult.Core;
public static class ErrorHelper
{
    public static string GetTitle(this Error error) =>
        error.Type switch
        {
            ErrorType.Validation => error.Code,
            ErrorType.Problem => error.Code,
            ErrorType.NotFound => error.Code,
            ErrorType.Conflict => error.Code,
            ErrorType.Exception => error.Code,
            ErrorType.Forbidden => error.Code,
            _ => "Server failure"
        };

    public static string GetDetail(this Error error) =>
        error.Type switch
        {
            ErrorType.Validation => error.Message,
            ErrorType.Problem => error.Message,
            ErrorType.Exception => error.Message,
            ErrorType.NotFound => error.Message,
            ErrorType.Conflict => error.Message,
            ErrorType.Forbidden => error.Message,
            _ => "An unexpected error occurred"
        };

    public static string GetErrorType(this ErrorType errorType) =>
    errorType switch
    {
        ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
        ErrorType.Problem => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
        ErrorType.Exception => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
        ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
        ErrorType.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
        ErrorType.Forbidden => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3",
        _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
    };

    public static int GetStatusCode(this ErrorType errorType) =>
           errorType switch
           {
               ErrorType.Validation or ErrorType.Problem => 400,
               ErrorType.NotFound => 404,
               ErrorType.Conflict => 409,
               ErrorType.Forbidden => 403,
               _ => 500
           };

    public static Dictionary<string, object?>? GetErrors(this Result result)
    {
        if (result.Error is not ValidationError validationError)
        {
            return null;
        }

        return new Dictionary<string, object?>
            {
                { "errors", validationError.Errors }
            };
    }
}

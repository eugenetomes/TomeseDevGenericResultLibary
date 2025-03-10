﻿namespace EasyCompany.GenericResult.Core;

public record Error
{
    public Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    [Obsolete("Constructor will be depreciated in the next version")]
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
        Type = ErrorType.Failure;
    }

    public string Code { get; }

    public string Message { get; }

    public ErrorType Type { get; }

    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new("General.Null", "Null value was provided", ErrorType.Failure);
    public static Error Failure(string code, string message) => new(code, message, ErrorType.Failure);
    public static Error NotFound(string code, string message) => new(code, message, ErrorType.NotFound);
    public static Error Problem(string code, string message) => new(code, message, ErrorType.Problem);
    public static Error Conflict(string code, string message) => new(code, message, ErrorType.Conflict);
    public static Error Exception(Exception exception) => new("Exception", exception.Message, ErrorType.Exception);

}
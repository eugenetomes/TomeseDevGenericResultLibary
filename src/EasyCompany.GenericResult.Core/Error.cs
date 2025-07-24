namespace EasyCompany.GenericResult.Core;

public record Error
{
    public Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    private Error()
    {
        // This constructor is for serialization purposes only.
    }

    public string Code { get; init; } = string.Empty;

    public string Message { get; init; } = string.Empty;

    public ErrorType Type { get; init; } = default;

    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new("General.Null", "Null value was provided", ErrorType.Failure);
    public static Error Failure(string code, string message) => new(code, message, ErrorType.Failure);
    public static Error NotFound(string code, string message) => new(code, message, ErrorType.NotFound);
    public static Error Problem(string code, string message) => new(code, message, ErrorType.Problem);
    public static Error Conflict(string code, string message) => new(code, message, ErrorType.Conflict);
    public static Error Exception(Exception exception) => new("Exception", exception.Message, ErrorType.Exception);

}
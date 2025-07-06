using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCompany.GenericResult.Core.IntegrationResults;
public class IntegrationResult
{
    protected internal IntegrationResult(bool isSuccess, IntegrationError error)
    {
        if (isSuccess && error != IntegrationError.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == IntegrationError.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public IntegrationError Error { get; }

    public static IntegrationResult Success() => new(true, IntegrationError.None);

    public static IntegrationResult<TValue> Success<TValue>(TValue value) => new(value, true, IntegrationError.None);

    public static IntegrationResult Failure(IntegrationError error) => new(false, error);

    public static IntegrationResult<TValue> Failure<TValue>(IntegrationError error) => new(default, false, error);

    public static IntegrationResult<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(IntegrationError.NullValue);
}

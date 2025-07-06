using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCompany.GenericResult.Core.IntegrationResults;

public class IntegrationResult<TValue> : IntegrationResult
{
    private readonly TValue? _value;

    protected internal IntegrationResult(TValue? value, bool isSuccess, IntegrationError error)
        : base(isSuccess, error) =>
        _value = value;

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator IntegrationResult<TValue>(TValue? value) => Create(value);
}

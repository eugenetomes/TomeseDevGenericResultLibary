using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCompany.GenericResult.Core.IntegrationResults;
public class IntegrationError
{
    public string Type { get; set; } = string.Empty;
    public int Status { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public string TraceId { get; set; } = string.Empty;
    public List<Error> Errors { get; set; } = new();

    public IntegrationError()
    {

    }

    public IntegrationError(string type, int status, string title, string detail, string traceId, List<Error> errors)
    {
        Type = type;
        Status = status;
        Title = title;
        Detail = detail;
        TraceId = traceId;
        Errors = errors;
    }

    public static IntegrationError Exception(Exception exception)
    {
        return new IntegrationError("https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1", 500, "An unexpected error occurred", exception.Message, string.Empty, new List<Error>());
    }
    public static readonly IntegrationError None = new(string.Empty, 200, string.Empty, string.Empty, string.Empty, new List<Error>());
    public static readonly IntegrationError NullValue = new("General.Null", 0, "Null value was provided", string.Empty, string.Empty, new List<Error>());
}

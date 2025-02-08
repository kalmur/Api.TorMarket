using System.Net;
using Api.TorMarket.Application.Results.Errors;

namespace Api.TorMarket.Domain.Results.Errors;

public class ApiError : Error
{
    public ApiError(HttpStatusCode statusCode, string responseContent) 
        : base(ErrorType.Api)
    {
        StatusCode = statusCode;
        ResponseContent = responseContent;
    }

    public HttpStatusCode StatusCode { get; }
    public string ResponseContent { get; }
}

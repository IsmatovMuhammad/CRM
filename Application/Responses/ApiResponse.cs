using System.Net;

namespace Application.Responses;

public class ApiResponse<T>
{
    private HttpStatusCode internalServerError;
    private string v;


    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public ApiResponse(HttpStatusCode statusCode, string message, T data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }
    public ApiResponse(HttpStatusCode statusCode, string message, Domain.Models.Groups group)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public ApiResponse(HttpStatusCode internalServerError, string v)
    {
        this.internalServerError = internalServerError;
        this.v = v;
    }

}

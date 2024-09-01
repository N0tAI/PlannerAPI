namespace TaskPlanner.API.Controllers;

public record class ApiResponse(string Message)
{
    public ApiResponse() : this(string.Empty)
    {
    }
    public ApiValueResponse<TValue> WithValue<TValue>(TValue value)
        => new ApiValueResponse<TValue>(value, Message);
    public static ApiValueResponse<TValue> Create<TValue>(TValue v)
        => new ApiValueResponse<TValue>(v);
    public static ApiValueResponse<TValue> Create<TValue>(TValue v, string message)
        => new ApiValueResponse<TValue>(v, message);
    public static ApiResponse WithMessage(string message)
        => new ApiResponse(message);
    public static ApiResponse Empty
    {
        get => new ApiResponse();
    }
}
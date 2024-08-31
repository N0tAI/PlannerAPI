using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace TaskPlanner.API.Web;

public record class ApiResponse
{
    public string Message { get; set; }
    protected ApiResponse() : this(string.Empty)
    {
    }
    protected ApiResponse(string message)
    {
        Message = message;
    }
    
    public ApiResponse<TValue> WithValue<TValue>(TValue value)
        => new ApiResponse<TValue>(value, Message);
    public static ApiResponse<TValue> Create<TValue>(TValue v)
        => new ApiResponse<TValue>(v);
    public static ApiResponse<TValue> Create<TValue>(TValue v, string message)
        => new ApiResponse<TValue>(v, message);
    public static ApiResponse Empty
    {
        get => new ApiResponse();
    }
}

public record class ApiResponse<TValue> : ApiResponse
{
    public TValue Value { get; set; }

    public ApiResponse(TValue value, string message) : base(message)
    {
        Value = value;
    }
    public ApiResponse(TValue value) : base()
    {
        Value = value;
    }
    public static ApiResponse<TValue> Create(TValue v)
        => new ApiResponse<TValue>(v);
    public static ApiResponse<TValue> Create(TValue v, string message)
        => new ApiResponse<TValue>(v, message);
}
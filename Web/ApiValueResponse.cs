namespace TaskPlanner.API.Web;

public record class ApiValueResponse<TValue> : ApiResponse
{
    public TValue Value { get; set; }
    public ApiValueResponse(TValue value, string message) : base(message)
    {
        Value = value;
    }
    public ApiValueResponse(TValue value) : this(value, string.Empty)
    {
    }
    public static ApiValueResponse<TValue> Create(TValue v)
        => new ApiValueResponse<TValue>(v);
    public static ApiValueResponse<TValue> Create(TValue v, string message)
        => new ApiValueResponse<TValue>(v, message);
}

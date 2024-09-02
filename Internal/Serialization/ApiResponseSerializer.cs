using System.Text.Json;
using System.Text.Json.Serialization;
using TaskPlanner.API.Controllers;

namespace TaskPlanner.API.Internal.Serialization;

public class ApiResponseSerializer : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert.IsAssignableTo(typeof(ApiResponse));

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return options.GetConverter(typeToConvert);
    }
}

using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskPlanner.API.Web.Serialization;

public class ApiResponseSerializer : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert.IsAssignableTo(typeof(ApiResponse));

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if(typeToConvert.IsAssignableTo(typeof(ApiValueResponse<>)))
        {
            var converterType = typeof(JsonConverter<>);
            converterType.MakeGenericType(typeToConvert.GenericTypeArguments[0]);
            return options.GetConverter(converterType);
        }
        return options.GetConverter(typeToConvert);
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RichObject.Domain.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CountryCode
    {
        GBR = 826,
        USA = 840,
    }
}
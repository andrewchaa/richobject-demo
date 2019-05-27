using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RichObject.Domain.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IdType
    {
        Passport = 1,
        DrivingLicence = 2,
    }
}
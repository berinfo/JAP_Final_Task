using System.Text.Json.Serialization;

namespace server.Units
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UnitEnum
    {
        pcs,
        g,
        kg,
        ml,
        l
    }
}

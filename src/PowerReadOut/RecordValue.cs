using System.Text.Json.Serialization;

namespace PowerReadOut;

internal struct RecordValue
{
    [JsonPropertyName("unit")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public RecordUnit Unit { get; }
    [JsonPropertyName("value")]
    
    public string Value { get; }

    public RecordValue(RecordUnit unit, string value)
    {
        Unit = unit;
        Value = value;
    }
}
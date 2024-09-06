using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

public class EuroMillionsDraw
{
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime Date { get; set; }
    public List<int> Numbers { get; set; }
    public List<int> Stars { get; set; }
}

public class CustomDateTimeConverter : DateTimeConverterBase
{
    private const string DateFormat = "dddd dd/MM/yyyy";
    private static readonly CultureInfo FrenchCulture = new CultureInfo("fr-FR");

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var date = (DateTime)value;
        writer.WriteValue(date.ToString(DateFormat, FrenchCulture));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var dateString = (string)reader.Value;
        return DateTime.ParseExact(dateString, DateFormat, FrenchCulture);
    }
}

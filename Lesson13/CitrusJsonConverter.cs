using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson13
{
    public class CitrusJsonConverter : System.Text.Json.Serialization.JsonConverter<Fruit>
    {
        public override Fruit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;

                var innerOptions = new JsonSerializerOptions();
                foreach (var conv in options.Converters)
                    if (!(conv is CitrusJsonConverter))
                        innerOptions.Converters.Add(conv);

                if (root.TryGetProperty("VitaminC", out _))
                    return JsonSerializer.Deserialize<Citrus>(root.GetRawText(), innerOptions);
                return JsonSerializer.Deserialize<Fruit>(root.GetRawText(), innerOptions);
            }
        }
        public override void Write(Utf8JsonWriter writer, Fruit value, JsonSerializerOptions options)
        {
            if (value is Citrus c)
                JsonSerializer.Serialize(writer, c, options);
            else
                JsonSerializer.Serialize(writer, value, options);
        }
    }
}

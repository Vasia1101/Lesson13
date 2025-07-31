using Lesson13;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public static class FruitSerializer
{
    public static void SerializeToJson(string path, List<Fruit> fruits)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(path, JsonSerializer.Serialize(fruits, options));
    }

    public static List<Fruit> DeserializeFromJson(string path)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Deserialize<List<Fruit>>(File.ReadAllText(path), options)
               ?? new List<Fruit>();
    }

    public static void SerializeToXml(string path, List<Fruit> fruits)
    {
        var xmlSer = new XmlSerializer(typeof(List<Fruit>), new Type[] { typeof(Citrus) });
        using var fs = new FileStream(path, FileMode.Create);
        xmlSer.Serialize(fs, fruits);
    }

    public static List<Fruit> DeserializeFromXml(string path)
    {
        var xmlSer = new XmlSerializer(typeof(List<Fruit>), new Type[] { typeof(Citrus) });
        using var fs = new FileStream(path, FileMode.Open);
        return (List<Fruit>)(xmlSer.Deserialize(fs) ?? new List<Fruit>());
    }
}


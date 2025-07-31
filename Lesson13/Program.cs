// See https://aka.ms/new-console-template for more information
using Lesson13;
using System.Text.Json;
using System.Xml.Serialization;

Console.WriteLine("Hello, World!");
    try
    {
        List<Fruit> fruits = new List<Fruit>
            {
                new Fruit("Apple", "red"),
                new Fruit("Banana", "yellow"),
                new Citrus("Lemon", "yellow", 0.053),
                new Citrus("Orange", "orange", 0.059),
                new Fruit("Grape", "purple"),
                new Citrus("Grapefruit", "pink", 0.031),
                new Fruit("Pear", "green")
            };

        // Print 'yellow' fruits
        Console.WriteLine("\nYellow fruits:");
        foreach (var f in fruits.Where(x => x.Color == "yellow"))
            f.Print();

        // Sort by name, output to file
        var sorted = fruits.OrderBy(x => x.Name).ToList();
        using (var writer = new StreamWriter("fruits.txt"))
        {
            foreach (var f in sorted)
                f.Print(writer);
        }
        Console.WriteLine("\nFruits sorted by name written to fruits.txt.");

        // Xml serialize/deserialize
        var xmlSer = new XmlSerializer(typeof(List<Fruit>), new Type[] { typeof(Citrus) });
        using (var fs = new FileStream("fruits.xml", FileMode.Create))
            xmlSer.Serialize(fs, fruits);
        Console.WriteLine("Serialized to fruits.xml.");

        using (var fs = new FileStream("fruits.xml", FileMode.Open))
            fruits = (List<Fruit>)xmlSer.Deserialize(fs);

        // Json serialize/deserialize
        string json = JsonSerializer.Serialize(fruits, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("fruits.json", json);
        Console.WriteLine("Serialized to fruits.json.");

        fruits = JsonSerializer.Deserialize<List<Fruit>>(File.ReadAllText("fruits.json"),
            new JsonSerializerOptions
            {
                Converters = { new CitrusJsonConverter() }
            });

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
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
                new Fruit("Pear", "green"),
                new Fruit("Mango", "orange"),
                new Fruit("Blueberry", "blue"),
                new Fruit("Kiwi", "brown"),
                new Citrus("Mandarin", "orange", 0.040),
                new Citrus("Lime", "green", 0.029),
                new Fruit("Plum", "violet"),
                new Citrus("Pomelo", "green", 0.045),
                new Fruit("Pineapple", "yellow"),
                new Fruit("Cherry", "red")
            };

        
        Console.WriteLine("Yellow fruits:");
        foreach (var f in fruits.Where(x => x.Color == "yellow"))
            f.Print();

        Console.WriteLine("Green fruits:");
        foreach (var f in fruits.Where(x => x.Color == "green"))
            f.Print();

        var sorted = fruits.OrderBy(x => x.Name).ToList();
            using (var writer = new StreamWriter("fruits.txt"))
            {
                foreach (var f in sorted)
                    f.Print(writer);
            }
            Console.WriteLine("Fruits sorted by name written to fruits.txt.");

            FruitSerializer.SerializeToJson("fruits.json", fruits);
            var loadedFruits = FruitSerializer.DeserializeFromJson("fruits.json");

            FruitSerializer.SerializeToXml("fruits.xml", fruits);
            var loadedFruitsXml = FruitSerializer.DeserializeFromXml("fruits.xml");


}
catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
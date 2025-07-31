namespace Lesson13.Tests;

using Xunit;
using Lesson13;

public class FruitTests
{
    [Fact]
    public void Fruit_ToString_ReturnsExpected()
    {
        // Arrange
        var fruit = new Fruit("Apple", "red");

        // Act
        string result = fruit.ToString();

        // Assert
        Assert.Contains("Apple", result);
        Assert.Contains("red", result);
    }

    [Fact]
    public void Citrus_ToString_ReturnsExpected()
    {
        var citrus = new Citrus("Lemon", "yellow", 0.045);
        string result = citrus.ToString();
        Console.WriteLine(result);
        Assert.Contains("Lemon", result);
        Assert.Contains("yellow", result);
        Assert.Contains("0.045", result);
    }

    [Fact]
    public void Citrus_NegativeVitaminC_SetsToZero()
    {
        var citrus = new Citrus("Lime", "green", -5);
        Assert.Equal(0, citrus.VitaminC);
    }

    [Fact]
    public void SortByName_WorksCorrectly()
    {
        var fruits = new List<Fruit>
        {
            new Fruit("Banana", "yellow"),
            new Fruit("Apple", "red")
        };

        var sorted = fruits.OrderBy(f => f.Name).ToList();
        Assert.Equal("Apple", sorted[0].Name);
        Assert.Equal("Banana", sorted[1].Name);
    }
}

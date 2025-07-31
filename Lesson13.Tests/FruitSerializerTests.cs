using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Lesson13;

public class FruitSerializerTests
{
	[Fact]
	public void SerializeAndDeserializeJson_WorksCorrectly()
	{
		// Arrange
		var testFile = "test_fruits.json";
		var fruits = new List<Fruit>
		{
			new Fruit("Apple", "red"),
			new Citrus("Lemon", "yellow", 0.05)
		};

		// Act
		FruitSerializer.SerializeToJson(testFile, fruits);
		var loaded = FruitSerializer.DeserializeFromJson(testFile);

		// Assert
		Assert.NotNull(loaded);
		Assert.Equal(fruits.Count, loaded.Count);
		Assert.Equal("Apple", loaded[0].Name);
		Assert.Equal("yellow", loaded[1].Color);

		// Clean up
		File.Delete(testFile);
	}

	[Fact]
	public void SerializeAndDeserializeXml_WorksCorrectly()
	{
		// Arrange
		var testFile = "test_fruits.xml";
		var fruits = new List<Fruit>
		{
			new Fruit("Pear", "green"),
			new Citrus("Orange", "orange", 0.06)
		};

		// Act
		FruitSerializer.SerializeToXml(testFile, fruits);
		var loaded = FruitSerializer.DeserializeFromXml(testFile);

		// Assert
		Assert.NotNull(loaded);
		Assert.Equal(fruits.Count, loaded.Count);
		Assert.Equal("Pear", loaded[0].Name);
		Assert.Equal(0.06, (loaded[1] as Citrus)?.VitaminC);

		// Clean up
		File.Delete(testFile);
	}

	[Fact]
	public void DeserializeFromJson_FileNotFound_Throws()
	{
		Assert.Throws<FileNotFoundException>(() =>
		{
			FruitSerializer.DeserializeFromJson("not_existing_file.json");
		});
	}

	[Fact]
	public void DeserializeFromXml_FileNotFound_Throws()
	{
		Assert.Throws<FileNotFoundException>(() =>
		{
			FruitSerializer.DeserializeFromXml("not_existing_file.xml");
		});
	}
}

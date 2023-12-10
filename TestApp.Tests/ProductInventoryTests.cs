using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }

    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        ProductInventory product = new ProductInventory();
        string name = "apple";
        double price = 1.00;
        int quantity = 3;

        string expected = $"Product Inventory:{Environment.NewLine}apple - Price: $1.00 - Quantity: 3";

        // Act
        this._inventory.AddProduct(name, price, quantity);
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
        ProductInventory product = new ProductInventory();

        string expected = "Product Inventory:";

        // Act
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        ProductInventory product = new ProductInventory();
        string name = "apple";
        double price = 1.222222222;
        int quantity = 3;

        string expected = $"Product Inventory:{Environment.NewLine}apple - Price: $1.22 - Quantity: 3";

        // Act
        this._inventory.AddProduct(name, price, quantity);
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Arrange
        ProductInventory product = new ProductInventory();

        // Act
        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        ProductInventory product = new ProductInventory();
        string name = "apple";
        double price = 1.20;
        int quantity = 3;

        // Act
        this._inventory.AddProduct(name, price, quantity);
        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(result , Is.EqualTo(3.5999999999999996d));

    }
}

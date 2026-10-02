using System;
using System.Collections.Generic;
using InventoryManager.Models;

List<Product> products = new List<Product>();

while (true)
{
    Console.WriteLine("\n===== INVENTORY MANAGER =====");
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. View Products");
    Console.WriteLine("3. Update Product");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your choice: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddProduct();
            break;

        case "2":
            ViewProducts();
            break;

        case "3":
            UpdateProduct();
            break;

        case "4":
            DeleteProduct();
            break;

        case "5":
            Console.WriteLine("Exiting application...");
            return;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}


void AddProduct()
{
    Console.Write("\nEnter Product ID: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter Product Name: ");
    string name = Console.ReadLine();

    Console.Write("Enter Price: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());

    Console.Write("Enter Quantity: ");
    int quantity = Convert.ToInt32(Console.ReadLine());

    Product product = new Product();

    product.ID = id;
    product.Name = name;
    product.Price = price;
    product.Quantity = quantity;
    product.IsAvailable = quantity > 0;

    products.Add(product);

    Console.WriteLine("Product added successfully.");
}


void ViewProducts()
{
    Console.WriteLine("\n===== PRODUCT LIST =====");

    if (products.Count == 0)
    {
        Console.WriteLine("No products found.");
        return;
    }

    foreach (Product product in products)
    {
        Console.WriteLine("------------------------");
        Console.WriteLine($"ID: {product.ID}");
        Console.WriteLine($"Name: {product.Name}");
        Console.WriteLine($"Price: {product.Price}");
        Console.WriteLine($"Quantity: {product.Quantity}");
        Console.WriteLine($"Available: {product.IsAvailable}");
    }
}


void UpdateProduct()
{
    Console.Write("\nEnter Product ID to update: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Product product = products.Find(p => p.ID == id);

    if (product == null)
    {
        Console.WriteLine("Product not found.");
        return;
    }

    Console.Write("Enter new name: ");
    product.Name = Console.ReadLine();

    Console.Write("Enter new price: ");
    product.Price = Convert.ToDecimal(Console.ReadLine());

    Console.Write("Enter new quantity: ");
    product.Quantity = Convert.ToInt32(Console.ReadLine());

    product.IsAvailable = product.Quantity > 0;

    Console.WriteLine("Product updated successfully.");
}


void DeleteProduct()
{
    Console.Write("\nEnter Product ID to delete: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Product product = products.Find(p => p.ID == id);

    if (product == null)
    {
        Console.WriteLine("Product not found.");
        return;
    }

    products.Remove(product);

    Console.WriteLine("Product deleted successfully.");
}
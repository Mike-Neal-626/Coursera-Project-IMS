using System;
using System.Collections.Generic;  // Needed for List<T>

class InventoryManagementSystem
{
    static void Main(string[] args)
    {
        List<string> products = new List<string>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Welcome to the Inventory Management System");
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. View Inventory");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        // Add product logic
                        AddProduct();
                        break;
                    case 2:
                        // Update product logic
                        UpdateProduct();
                        break;
                    case 3:
                        // View inventory logic
                        ViewInventory();
                        break;
                    case 4:
                        // Remove product logic
                        RemoveProduct();
                        break;
                    case 5:
                        // Exit the system
                        Console.WriteLine("Exiting the system. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }

    // Method to add a product
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price:C}, Stock: {StockQuantity}";
        }
    }

    static List<Product> products = new List<Product>();

    static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter product price: ");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
        {
            Console.Write("Invalid price. Enter a valid price: ");
        }

        Console.Write("Enter stock quantity: ");
        int stock;
        while (!int.TryParse(Console.ReadLine(), out stock) || stock < 0)
        {
            Console.Write("Invalid quantity. Enter a valid stock quantity: ");
        }

        products.Add(new Product { Name = name, Price = price, StockQuantity = stock });
        Console.WriteLine("Product added successfully.");
    }

    // Method to update product details
    static void UpdateProduct()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products available to update.");
            return;
        }

        ViewInventory();
        Console.Write("Enter the product number to update: ");
        int index;
        if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= products.Count)
        {
            Product product = products[index - 1];

            Console.Write($"Enter new name (current: {product.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                product.Name = name;
            }

            Console.Write($"Enter new price (current: {product.Price:C}): ");
            decimal price;
            if (decimal.TryParse(Console.ReadLine(), out price) && price >= 0)
            {
                product.Price = price;
            }

            Console.Write($"Enter new stock quantity (current: {product.StockQuantity}): ");
            int stock;
            if (int.TryParse(Console.ReadLine(), out stock) && stock >= 0)
            {
                product.StockQuantity = stock;
            }

            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid product number.");
        }
    }

    // Method to view inventory
    static void ViewInventory()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
            return;
        }

        Console.WriteLine("Current Inventory:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i]}");
        }
    }

    // Method to remove a product
    static void RemoveProduct()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products available to remove.");
            return;
        }

        ViewInventory();
        Console.Write("Enter the product number to remove: ");
        int index;
        if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= products.Count)
        {
            products.RemoveAt(index - 1);
            Console.WriteLine("Product removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid product number.");
        }
    }
}
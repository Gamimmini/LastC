using System;
using System.IO;

namespace ProductManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "products.txt";

            while (true)
            {
                Console.WriteLine("----- Product Management -----");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. Display all products");
                Console.WriteLine("3. Search for a product");
                Console.WriteLine("4. Exit");
                Console.WriteLine("----------------------------------");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct(filePath);
                        break;
                    case "2":
                        DisplayAllProducts(filePath);
                        break;
                    case "3":
                        SearchProduct(filePath);
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddProduct(string filePath)
        {
            Console.WriteLine("----- Add a Product -----");
            Console.Write("Enter product code: ");
            string code = Console.ReadLine();
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter manufacturer: ");
            string manufacturer = Console.ReadLine();
            Console.Write("Enter price: ");
            string priceStr = Console.ReadLine();
            Console.Write("Enter additional description: ");
            string description = Console.ReadLine();

            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{code},{name},{manufacturer},{priceStr},{description}");
                    Console.WriteLine("Product added successfully.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while adding the product: {e.Message}");
            }
        }

        static void DisplayAllProducts(string filePath)
        {
            Console.WriteLine("----- All Products -----");

            try
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        Console.WriteLine($"Code: {values[0]}, Name: {values[1]}, Manufacturer: {values[2]}, Price: {values[3]}, Description: {values[4]}");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No products found.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }
        }

        static void SearchProduct(string filePath)
        {
            Console.WriteLine("----- Search for a Product -----");
            Console.Write("Enter product code to search: ");
            string searchCode = Console.ReadLine();

            try
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    string line;
                    bool found = false;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        if (values[0] == searchCode)
                        {
                            Console.WriteLine($"Code: {values[0]}, Name: {values[1]}, Manufacturer: {values[2]}, Price: {values[3]}, Description: {values[4]}");
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Product not found.");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No products found.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }
        }
    }
}

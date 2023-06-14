using System;
using System.IO;

namespace ReadCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"E:\C# Basic\ReadFile\Countries.csv";

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        Console.WriteLine($"Name: {values[0]}, Age: {values[1]}, Address: {values[2]}, Phone: {values[3]}, Email: {values[4]}, Salary: {values[5]}");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! An error occurred. Please try again later: " + ex.Message);
            }
        }
    }
}
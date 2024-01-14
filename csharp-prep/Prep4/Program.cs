using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<double> numbers = new List<double>();

        Console.WriteLine("Enter numbers (enter 0 to finish):");

        double input;
        do
        {
            string userInput = Console.ReadLine();
            while (!double.TryParse(userInput, out input))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
                userInput = Console.ReadLine();
            }

            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        // Core Requirements:
        double sum = numbers.Sum();
        Console.WriteLine($"Sum of the numbers: {sum}");

        double average = numbers.Count > 0 ? numbers.Average() : 0;
        Console.WriteLine($"Average of the numbers: {average}");

        double maximum = numbers.Count > 0 ? numbers.Max() : 0;
        Console.WriteLine($"Maximum number: {maximum}");

        // Stretch Challenge:

        // Find the smallest positive number (closest to zero)
        double smallestPositive = numbers.Where(x => x > 0).DefaultIfEmpty(0).Min();
        Console.WriteLine($"Smallest positive number: {smallestPositive}");

        // Sort the numbers in the list
        numbers.Sort();
        
        // Display the sorted list
        Console.Write("Sorted list: ");
        foreach (var number in numbers)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }
}

using System;

class Program
{
    static void Main()
    {
        // Core Requirements:

        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        // Determine the letter grade
        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Check if the user passed the course and display a message
        if (gradePercentage >= 70)
        {
            Console.WriteLine($"Congratulations! You passed with a grade of {letter}.");
        }
        else
        {
            Console.WriteLine($"Keep working hard! You got a grade of {letter}.");
        }

        // Stretch Challenge:

        // Determine the sign (+, -, or none)
        string sign = "";

        int lastDigit = gradePercentage % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        // Handle exceptional cases (A+, F+, F-)
        if (letter == "A" && sign == "+")
        {
            letter = "A";
            sign = ""; // No A+ grade
        }
        else if (letter == "F" && (sign == "+" || sign == "-"))
        {
            letter = "F";
            sign = ""; // No F+ or F- grade
        }

        // Display both the grade letter and the sign in one print statement
        Console.WriteLine($"Your final grade is: {letter}{sign}");
    }
}

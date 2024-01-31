using System;

public class Fraction
{
    private int top;
    private int bottom;

    // Constructors
    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    public Fraction(int top)
    {
        this.top = top;
        bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        this.top = top;
        this.bottom = bottom != 0 ? bottom : 1;
    }

    // Getters and Setters
    public int GetTop()
    {
        return top;
    }

    public void SetTop(int top)
    {
        this.top = top;
    }

    public int GetBottom()
    {
        return bottom;
    }

    public void SetBottom(int bottom)
    {
        this.bottom = bottom != 0 ? bottom : 1;
    }

    // Methods to return representations
    public string GetFractionString()
    {
        return $"{top}/{bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)top / bottom;
    }
}

class Program
{
    static void Main()
    {
        // Create instances using different constructors
        Fraction fraction1 = new Fraction();        // 1/1
        Fraction fraction2 = new Fraction(6);       // 6/1
        Fraction fraction3 = new Fraction(6, 7);    // 6/7

        // Display fractions using GetFractionString method
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction3.GetFractionString());

        // Display fractions using GetDecimalValue method
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine(fraction3.GetDecimalValue());

        // Change values using setters
        fraction1.SetTop(5);
        fraction2.SetBottom(2);

        // Display updated fractions
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction2.GetFractionString());

        // Display updated decimal values
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine(fraction2.GetDecimalValue());
    }
}

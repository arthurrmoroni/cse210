using System;
 
class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int percent = int.Parse(Console.ReadLine());
 
        string letter;
 
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
 
        // Stretch: add + or - based on the last digit
        int lastDigit = percent % 10;
        string sign = "";
 
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
 
        // There is no A+ (and 100% is just an A), and no F+ or F-
        if (letter == "A" && percent >= 93)
        {
            sign = "";
        }
        if (letter == "F")
        {
            sign = "";
        }
 
        Console.WriteLine($"Your grade is: {letter}{sign}");
 
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("You didn't pass this time, but keep going. You'll do better next time!");
        }
    }
}
using System;
using System.Collections.Generic;
 
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
 
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
 
        int number = -1;
        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
 
            if (number != 0)
            {
                numbers.Add(number);
            }
        }
 
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }
 
        // Sum
        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }
        Console.WriteLine($"The sum is: {sum}");
 
        // Average
        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");
 
        // Largest number
        int max = numbers[0];
        foreach (int n in numbers)
        {
            if (n > max)
            {
                max = n;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
 
        // Stretch: smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int n in numbers)
        {
            if (n > 0 && n < smallestPositive)
            {
                smallestPositive = n;
            }
        }
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
 
        // Stretch: sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}
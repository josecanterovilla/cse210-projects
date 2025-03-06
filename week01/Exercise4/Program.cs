using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        

        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();

        int number = 1;
        int sum_numbers = 0;
        List<int> smallest_numbers = new List<int>();

        while (number != 0)
        {
        Console.Write("Insert a list of numbers, type 0 when finished: ");
        string inputUser = Console.ReadLine();
        number = int.Parse(inputUser);
        numbers.Add(number);
        
        }

        foreach (int i in numbers)
        {
        sum_numbers = sum_numbers + i;
        if (i > 0)
        {
            smallest_numbers.Add(i);
            
        }
        }

        double average = (double)sum_numbers / (numbers.Count -1);
        int largest = numbers.Max();
        int smallest = smallest_numbers.Min();
        Console.WriteLine($"The sum is {sum_numbers}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");
        Console.WriteLine("Your program is over.");


    }
}
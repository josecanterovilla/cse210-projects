using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("Hello World! This is the class Exercise 4 Project.");

        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);

            if (number == 0)
            {

                break;

            }
            numbers.Add(number);
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");


        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The largest number is: {max}");

        int smallestPositive = int.MaxValue;

        foreach (int number in numbers)
        {
            if (number > 0)
            {
                if (number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
        }

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();

        Console.WriteLine("The sorted list is: ");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }




    }
}

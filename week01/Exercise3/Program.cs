using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1,100);

        Console.Write("What is your gress?: ");
        string inputUser2 = Console.ReadLine();
        int guess_number = int.Parse(inputUser2);

        while (magic_number != guess_number)
        {if (magic_number == guess_number)
        {Console.WriteLine("You guessed it!");}

        else if (magic_number < guess_number)
        {Console.WriteLine("Lower");}

        else if (magic_number > guess_number)
        {Console.WriteLine("Higher");}
        }
    }
}
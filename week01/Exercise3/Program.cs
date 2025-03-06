using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1,100);

        
        int repeats = 0;
        string continue_playing = "";

        while (continue_playing != "no")

        {Console.Write("What is your guess?: ");
        string inputUser2 = Console.ReadLine();
        int guess_number = int.Parse(inputUser2);
        
        repeats ++;

        if (magic_number == guess_number) 
        {Console.WriteLine($"You guessed it!, with {repeats} guesses");
        repeats = 0;
        Console.Write("Do you want to keep playing?: ");
        continue_playing = Console.ReadLine();}

        else if (magic_number < guess_number)
        {Console.WriteLine("Lower");}

        else if (magic_number > guess_number)
        {Console.WriteLine("Higher");}
        }
        
        
    }
}
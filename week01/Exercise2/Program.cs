using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        
        Console.Write("What is the grade number percent?: ");
        string inputUser = Console.ReadLine();
        int grade = int.Parse(inputUser);
        int division = grade % 10; 
        string letter = "";

        if (grade >= 90)
        {  

                letter = "A";
        }
        
        else if (grade >= 80)
        {
            letter = "B";
            }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
            {
            
            letter = "F";
            }

        if (grade >= 70)
        {  Console.WriteLine($"You pass the course");

        }
        else {
            Console.WriteLine($"You don't passed");
        }
        if (grade > 93)
            {
            Console.WriteLine($"Your grade is: {letter}");
            }
        else if (grade < 60) {
                Console.WriteLine($"Your grade is: {letter}");
            }
        else if (division >= 7)
            {
            Console.WriteLine($"Your grade is {letter}+");
            }
        else if (division < 3) {
            Console.WriteLine($"Your grade is {letter}-");   
            }

    }
}

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Week 01 - Dynamic Arrays");
        Console.WriteLine("------------------------");
        Console.WriteLine();

        // run first problem
        MultiplesOf();

        Console.WriteLine();
        Console.WriteLine("------------------------");
        Console.WriteLine();

        // run second problem
        RotateRight();

        Console.WriteLine();
        Console.WriteLine("Program finished.");
    }

    /*
    PLAN: Multiples Of

    1. Ask the user to enter a number.
    2. Create a dynamic array (List) to store multiples.
    3. Use a loop from 1 to 10.
    4. Multiply the user number by the loop number.
    5. Add each result into the list.
    6. Print the results from the list.
    */

    static void MultiplesOf()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        List<int> multiples = new List<int>();

        for (int i = 1; i <= 10; i++)
        {
            int result = number * i;
            multiples.Add(result);
        }

        Console.WriteLine();
        Console.WriteLine("Multiples of " + number + ":");

        foreach (int value in multiples)
        {
            Console.WriteLine(value);
        }
    }

    /*
    PLAN: Rotate Right

    1. Create a list of numbers.
    2. Save the last number in a variable.
    3. Move each number one position to the right.
    4. Put the saved last number into the first position.
    5. Print the new list.
    */

    static void RotateRight()
    {
        List<int> numbers = new List<int>() { 5, 10, 15, 20, 25 };

        Console.WriteLine("Original numbers:");

        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }

        int last = numbers[numbers.Count - 1];

        for (int i = numbers.Count - 1; i > 0; i--)
        {
            numbers[i] = numbers[i - 1];
        }

        numbers[0] = last;

        Console.WriteLine();
        Console.WriteLine("Numbers after rotating right:");

        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}

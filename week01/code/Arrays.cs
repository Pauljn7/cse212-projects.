using System;
using System.Collections.Generic;

public static class Arrays
{
    /*
    PLAN: Multiples Of

    1. Ask the user to enter a number.
    2. Create a dynamic array (List<int>) to store the multiples.
    3. Use a loop from 1 to 10.
    4. Multiply the number by each value in the loop.
    5. Store each result in the dynamic array.
    6. Return the list of multiples.
    */

    public static List<int> MultiplesOf(int number)
    {
        List<int> results = new List<int>();

        for (int i = 1; i <= 10; i++)
        {
            int value = number * i;
            results.Add(value);
        }

        return results;
    }


    /*
    PLAN: Rotate Right

    1. Receive a dynamic array (List<int>).
    2. Save the last value of the list.
    3. Move every element one position to the right.
    4. Place the saved last value into the first position.
    5. Return the updated list.
    */

    public static List<int> RotateRight(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            return numbers;
        }

        int last = numbers[numbers.Count - 1];

        for (int i = numbers.Count - 1; i > 0; i--)
        {
            numbers[i] = numbers[i - 1];
        }

        numbers[0] = last;

        return numbers;
    }
}

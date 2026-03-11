using System;
using System.Collections.Generic;

public static class Arrays
{
    /*
    PLAN: Multiples Of

    1. Receive two numbers: the base number and how many multiples to generate.
    2. Create a dynamic array (List<int>) to store the results.
    3. Use a loop starting from 1 up to the count value.
    4. Multiply the base number by the loop counter.
    5. Add each result into the list.
    6. Return the list of multiples.
    */

    public static List<int> MultiplesOf(int number, int count)
    {
        List<int> results = new List<int>();

        for (int i = 1; i <= count; i++)
        {
            results.Add(number * i);
        }

        return results;
    }


    /*
    PLAN: Rotate Right

    1. Receive a list of integers.
    2. If the list is empty, do nothing.
    3. Save the last value in a temporary variable.
    4. Move every element one position to the right.
    5. Place the saved last value into the first position.
    6. The list is now rotated to the right.
    */

    public static void RotateListRight(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            return;
        }

        int last = numbers[numbers.Count - 1];

        for (int i = numbers.Count - 1; i > 0; i--)
        {
            numbers[i] = numbers[i - 1];
        }

        numbers[0] = last;
    }
}

using System;
using System.Collections.Generic;

public static class Arrays
{
    /*
    PLAN: Multiples Of

    1. Receive a number and a count.
    2. Create an array of doubles with the size of count.
    3. Use a loop from 1 up to the count value.
    4. Multiply the number by the loop counter.
    5. Store each result in the array.
    6. Return the array of multiples.
    */

    public static double[] MultiplesOf(double number, int count)
    {
        double[] results = new double[count];

        for (int i = 0; i < count; i++)
        {
            results[i] = number * (i + 1);
        }

        return results;
    }

    /*
    PLAN: Rotate Right

    1. Receive a list of integers and the number of rotations.
    2. Repeat the rotation process the specified number of times.
    3. Save the last element in the list.
    4. Shift every element one position to the right.
    5. Place the saved last element at the beginning of the list.
    */

    public static void RotateListRight(List<int> numbers, int rotations)
    {
        int count = numbers.Count;

        if (count == 0)
        {
            return;
        }

        rotations = rotations % count;

        for (int r = 0; r < rotations; r++)
        {
            int last = numbers[count - 1];

            for (int i = count - 1; i > 0; i--)
            {
                numbers[i] = numbers[i - 1];
            }

            numbers[0] = last;
        }
    }
}

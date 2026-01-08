
using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        for (int i = 1; i <= 10; i++)
        {
            Console.Write(numbers[numbers.Length - i] + ", ");
        }
    }
}

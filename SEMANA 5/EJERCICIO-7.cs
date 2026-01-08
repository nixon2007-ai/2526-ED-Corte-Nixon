
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Lista de letras (incluye 'ñ')
        List<char> alphabet = new List<char>
        {
            'a','b','c','d','e','f','g','h','i','j','k','l',
            'm','n','ñ','o','p','q','r','s','t','u','v','w',
            'x','y','z'
        };

        // i recorre desde Count hasta 2 (igual que range(len, 1, -1) en Python)
        for (int i = alphabet.Count; i > 1; i--)
        {
            if (i % 3 == 0)
            {
                // pop(i-1) en Python equivale a RemoveAt(i-1) en C#
                alphabet.RemoveAt(i - 1);
            }
        }

        // Mostrar resultado similar a print(alphabet)
        Console.WriteLine("[" + string.Join(", ", alphabet) + "]");
    }
}

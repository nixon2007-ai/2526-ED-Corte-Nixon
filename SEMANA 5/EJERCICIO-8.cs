
using System;

class Program
{
    static void Main()
    {
        Console.Write("Introduce una palabra: ");
        string? word = Console.ReadLine();

        if (word == null)
        {
            Console.WriteLine("Entrada no válida.");
            return;
        }

        // Convertir a arreglo de caracteres y crear su reverso
        char[] original = word.ToCharArray();
        char[] reversed = word.ToCharArray();
        Array.Reverse(reversed);

        // Comparar
        if (new string(original) == new string(reversed))
        {
            Console.WriteLine("Es un palíndromo");
        }
        else
        {
            Console.WriteLine("No es un palíndromo");
        }
    }
}

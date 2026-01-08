
using System;
using System.Collections.Generic;

// Lista para almacenar los números ganadores
List<int> awarded = new List<int>();

// Pedir 6 números al usuario
for (int i = 0; i < 6; i++)
{
    Console.Write("Introduce un número ganador: ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int number))
    {
        awarded.Add(number);
    }
    else
    {
        Console.WriteLine("Entrada no válida. Por favor, introduce un número entero.");
        i--; // repetir esta iteración
    }
}

// Ordenar la lista
awarded.Sort();

// Mostrar resultado
Console.WriteLine("Los números ganadores son " + string.Join(", ", awarded));

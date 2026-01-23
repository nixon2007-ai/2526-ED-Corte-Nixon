using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese el número de discos:");
        int numDiscos = int.Parse(Console.ReadLine());
        MoverDiscos(numDiscos, 'A', 'C', 'B'); // A: origen, C: destino, B: auxiliar
    }

    static void MoverDiscos(int n, char origen, char destino, char auxiliar)
    {
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 de {origen} a {destino}");
            return;
        }
        MoverDiscos(n - 1, origen, auxiliar, destino);
        Console.WriteLine($"Mover disco {n} de {origen} a {destino}");
        MoverDiscos(n - 1, auxiliar, destino, origen);
    }
}
4
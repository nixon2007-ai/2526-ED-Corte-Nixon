
using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Lista de asignaturas
        List<string> subjects = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        List<string> passed = new List<string>();

        // Pedir notas
        foreach (var subject in subjects)
        {
            Console.Write($"¿Qué nota has sacado en {subject}? ");

            // Intentar leer y convertir a double (usa CultureInfo para admitir el punto o la coma decimal)
            string? input = Console.ReadLine();
            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double score) ||
                double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out score))
            {
                if (score >= 5.0)
                {
                    passed.Add(subject);
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Se registrará como suspenso.");
                // Si lo prefieres, podrías repetir la solicitud en lugar de marcar suspenso.
            }
        }

        // Eliminar aprobadas de la lista original
        foreach (var subject in passed)
        {
            subjects.Remove(subject);
        }

        // Mostrar resultado
        Console.WriteLine("Tienes que repetir " + string.Join(", ", subjects));
    }
}

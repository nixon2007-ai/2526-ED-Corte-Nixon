using System;

class Estudiante
{
    public int ID { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string[] Telefonos { get; set; }

    public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        ID = id;
        Nombres = nombres;
        Apellidos = apellidos;
        Direccion = direccion;
        Telefonos = telefonos;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"ID: {ID}");
        Console.WriteLine($"Nombres: {Nombres}");
        Console.WriteLine($"Apellidos: {Apellidos}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine("Teléfonos:");
        foreach (var telefono in Telefonos)
        {
            Console.WriteLine($"- {telefono}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Registro de Estudiante");
        
        // Ingreso de datos
        Console.Write("Ingrese ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Ingrese Nombres: ");
        string nombres = Console.ReadLine();

        Console.Write("Ingrese Apellidos: ");
        string apellidos = Console.ReadLine();

        Console.Write("Ingrese Dirección: ");
        string direccion = Console.ReadLine();

        string[] telefonos = new string[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ingrese Teléfono {i + 1}: ");
            telefonos[i] = Console.ReadLine();
        }

        // Crear objeto Estudiante
        Estudiante estudiante = new Estudiante(id, nombres, apellidos, direccion, telefonos);

        // Mostrar información del estudiante
        Console.WriteLine("\nInformación del Estudiante:");
        estudiante.MostrarInformacion();
    }
}

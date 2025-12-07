using System;

// Clase que representa un cuadrado
public class Cuadrado
{
    // Propiedad que almacena la longitud del lado del cuadrado
    public double Lado { get; set; }

    // Constructor que inicializa la longitud del lado
    public Cuadrado(double lado)
    {
        Lado = lado;
    }

    // CalcularArea es una función que devuelve un valor double,
    // se utiliza para calcular el área de un cuadrado,
    // requiere como argumento la longitud del lado del cuadrado
    public double CalcularArea()
    {
        return Lado * Lado;
    }

    // CalcularPerimetro es una función que devuelve un valor double,
    // se utiliza para calcular el perímetro de un cuadrado
    public double CalcularPerimetro()
    {
        return 4 * Lado;
    }
}

// Clase que representa un triángulo
public class Triangulo
{
    // Propiedades que almacenan la base y la altura del triángulo
    public double Base { get; set; }
    public double Altura { get; set; }

    // Constructor que inicializa la base y la altura
    public Triangulo(double baseTriangulo, double altura)
    {
        Base = baseTriangulo;
        Altura = altura;
    }

    // CalcularArea es una función que devuelve un valor double,
    // se utiliza para calcular el área de un triángulo,
    // requiere como argumento la base y la altura del triángulo
    public double CalcularArea()
    {
        return (Base * Altura) / 2;
    }

    // CalcularPerimetro es una función que devuelve un valor double,
    // se utiliza para calcular el perímetro de un triángulo,
    // requiere como argumento los lados del triángulo
    public double CalcularPerimetro(double lado1, double lado2)
    {
        return Base + lado1 + lado2; // Asumiendo que lado1 y lado2 son los otros dos lados del triángulo
    }
}

// Ejemplo de uso
class Program
{
    static void Main(string[] args)
    {
        // Mensaje de autor
        Console.WriteLine("Creado por Nixon Corte\n");

        // Crear un objeto de la clase Cuadrado con un lado de 4
        Cuadrado cuadrado = new Cuadrado(4);
        Console.WriteLine("Figura: Cuadrado");
        Console.WriteLine($"Área del cuadrado: {cuadrado.CalcularArea()}");
        Console.WriteLine($"Perímetro del cuadrado: {cuadrado.CalcularPerimetro()}\n");

        // Crear un objeto de la clase Triangulo con base 4 y altura 3
        Triangulo triangulo = new Triangulo(4, 3);
        Console.WriteLine("Figura: Triángulo");
        Console.WriteLine($"Área del triángulo: {triangulo.CalcularArea()}");
        Console.WriteLine($"Perímetro del triángulo: {triangulo.CalcularPerimetro(3, 5)}"); // Ejemplo de lados
    }
}

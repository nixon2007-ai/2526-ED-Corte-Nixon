
using System;
using System.Globalization;

namespace ListasEnlazadasPromedio
{
    // Nodo de lista enlazada simple
    public class Nodo
    {
        public double Valor { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(double valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }

    // Lista enlazada simple
    public class ListaEnlazada
    {
        public Nodo Cabeza { get; private set; }
        public Nodo Cola { get; private set; }
        public int Longitud { get; private set; }

        public ListaEnlazada()
        {
            Cabeza = null;
            Cola = null;
            Longitud = 0;
        }

        // Inserta al final (O(1) con referencia a Cola)
        public void AgregarAlFinal(double valor)
        {
            var nuevo = new Nodo(valor);
            if (Cabeza == null)
            {
                Cabeza = nuevo;
                Cola = nuevo;
            }
            else
            {
                Cola.Siguiente = nuevo;
                Cola = nuevo;
            }
            Longitud++;
        }

        // Permite iterar (foreach) por la lista
        public System.Collections.Generic.IEnumerable<double> Elementos()
        {
            var actual = Cabeza;
            while (actual != null)
            {
                yield return actual.Valor;
                actual = actual.Siguiente;
            }
        }

        public override string ToString()
        {
            return string.Join(", ", Elementos());
        }

        // Suma todos los elementos (O(n))
        public double Sumar()
        {
            double suma = 0;
            var actual = Cabeza;
            while (actual != null)
            {
                suma += actual.Valor;
                actual = actual.Siguiente;
            }
            return suma;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Para aceptar punto o coma como separador decimal según cultura.
            var culture = CultureInfo.InvariantCulture;

            Console.WriteLine("=== Manejo de datos reales con listas enlazadas ===");
            int n = LeerEnteroPositivo("Ingrese la cantidad de datos (N): ");

            var listaPrincipal = new ListaEnlazada();

            // Cargar N datos tipo real
            for (int i = 1; i <= n; i++)
            {
                double valor = LeerDouble($"Ingrese el dato #{i}: ");
                listaPrincipal.AgregarAlFinal(valor);
            }

            // Calcular promedio
            double promedio = (n > 0) ? (listaPrincipal.Sumar() / n) : 0.0;

            // Particionar en dos listas
            var listaMenorIgual = new ListaEnlazada();
            var listaMayor = new ListaEnlazada();

            foreach (var x in listaPrincipal.Elementos())
            {
                if (x <= promedio)
                    listaMenorIgual.AgregarAlFinal(x);
                else
                    listaMayor.AgregarAlFinal(x);
            }

            // Mostrar resultados
            Console.WriteLine();
            Console.WriteLine("Resultados:");
            Console.WriteLine($"a) Lista principal: [{listaPrincipal}]");
            Console.WriteLine($"b) Promedio: {promedio.ToString("0.############", culture)}");
            Console.WriteLine($"c) Datos <= promedio: [{listaMenorIgual}]");
            Console.WriteLine($"d) Datos  > promedio: [{listaMayor}]");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // --- Utilidades de lectura segura ---

        static int LeerEnteroPositivo(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine()?.Trim() ?? "";
                if (int.TryParse(entrada, out valor) && valor >= 0)
                    return valor;

                Console.WriteLine("Entrada inválida. Ingrese un entero >= 0.");
            }
        }

        static double LeerDouble(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine()?.Trim() ?? "";

                // Permitir tanto coma como punto decimal
                entrada = entrada.Replace(',', '.');

                if (double.TryParse(entrada, NumberStyles.Float, CultureInfo.InvariantCulture, out double valor))
                    return valor;

                Console.WriteLine("Entrada inválida. Ingrese un número real (use punto o coma como decimal).");
            }
        }
    }
}


using System;

class Nodo
{
    public int Dato;
    public Nodo Siguiente;

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    public Nodo Inicio;

    public ListaEnlazada()
    {
        Inicio = null;
    }

    // Inserta por el inicio
    public void InsertarInicio(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        nuevo.Siguiente = Inicio;
        Inicio = nuevo;
    }

    // Retorna la cantidad de nodos
    public int Longitud()
    {
        int contador = 0;
        Nodo aux = Inicio;
        while (aux != null)
        {
            contador++;
            aux = aux.Siguiente;
        }
        return contador;
    }

    // Compara dos listas en tamaño y contenido
    public bool EsIgualContenido(ListaEnlazada otra)
    {
        Nodo a = this.Inicio;
        Nodo b = otra.Inicio;

        while (a != null && b != null)
        {
            if (a.Dato != b.Dato)
                return false;

            a = a.Siguiente;
            b = b.Siguiente;
        }

        return true; 
    }
}

class Program
{
    static void Main()
    {
        ListaEnlazada lista1 = new ListaEnlazada();
        ListaEnlazada lista2 = new ListaEnlazada();

        int n1, n2, dato;

        // -------------------------
        // Carga de la primera lista
        // -------------------------
        Console.Write("Ingrese cantidad de datos para la primera lista: ");
        n1 = int.Parse(Console.ReadLine());

        for (int i = 0; i < n1; i++)
        {
            Console.Write("Ingrese un número: ");
            dato = int.Parse(Console.ReadLine());
            lista1.InsertarInicio(dato);
        }

        // -------------------------
        // Carga de la segunda lista
        // -------------------------
        Console.Write("Ingrese cantidad de datos para la segunda lista: ");
        n2 = int.Parse(Console.ReadLine());

        for (int i = 0; i < n2; i++)
        {
            Console.Write("Ingrese un número: ");
            dato = int.Parse(Console.ReadLine());
            lista2.InsertarInicio(dato);
        }

        // -------------------------
        // Comparación de listas
        // -------------------------
        Console.WriteLine("\nRESULTADO:");

        if (lista1.Longitud() == lista2.Longitud())
        {
            if (lista1.EsIgualContenido(lista2))
            {
                Console.WriteLine("a. Las listas son iguales en tamaño y contenido.");
            }
            else
            {
                Console.WriteLine("b. Las listas son iguales en tamaño pero no en contenido.");
            }
        }
        else
        {
            Console.WriteLine("c. Las listas no tienen el mismo tamaño ni contenido.");
        }
    }
}

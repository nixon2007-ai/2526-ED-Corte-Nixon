using System;

namespace ArbolBST
{
    // Clase Nodo
    class Nodo
    {
        public int Valor;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    // Clase Árbol Binario de Búsqueda
    class BST
    {
        public Nodo Raiz;

        public BST()
        {
            Raiz = null;
        }

        // Insertar
        public Nodo Insertar(Nodo raiz, int valor)
        {
            if (raiz == null)
                return new Nodo(valor);

            if (valor < raiz.Valor)
                raiz.Izquierdo = Insertar(raiz.Izquierdo, valor);
            else if (valor > raiz.Valor)
                raiz.Derecho = Insertar(raiz.Derecho, valor);

            return raiz;
        }

        // Buscar
        public bool Buscar(Nodo raiz, int valor)
        {
            if (raiz == null) return false;
            if (raiz.Valor == valor) return true;

            if (valor < raiz.Valor)
                return Buscar(raiz.Izquierdo, valor);
            else
                return Buscar(raiz.Derecho, valor);
        }

        // Encontrar mínimo
        public Nodo Minimo(Nodo raiz)
        {
            while (raiz.Izquierdo != null)
                raiz = raiz.Izquierdo;
            return raiz;
        }

        // Eliminar
        public Nodo Eliminar(Nodo raiz, int valor)
        {
            if (raiz == null) return raiz;

            if (valor < raiz.Valor)
                raiz.Izquierdo = Eliminar(raiz.Izquierdo, valor);
            else if (valor > raiz.Valor)
                raiz.Derecho = Eliminar(raiz.Derecho, valor);
            else
            {
                // Caso 1: sin hijos
                if (raiz.Izquierdo == null && raiz.Derecho == null)
                    return null;

                // Caso 2: un hijo
                if (raiz.Izquierdo == null)
                    return raiz.Derecho;
                else if (raiz.Derecho == null)
                    return raiz.Izquierdo;

                // Caso 3: dos hijos
                Nodo temp = Minimo(raiz.Derecho);
                raiz.Valor = temp.Valor;
                raiz.Derecho = Eliminar(raiz.Derecho, temp.Valor);
            }

            return raiz;
        }

        // Recorridos
        public void InOrden(Nodo raiz)
        {
            if (raiz != null)
            {
                InOrden(raiz.Izquierdo);
                Console.Write(raiz.Valor + " ");
                InOrden(raiz.Derecho);
            }
        }

        public void PreOrden(Nodo raiz)
        {
            if (raiz != null)
            {
                Console.Write(raiz.Valor + " ");
                PreOrden(raiz.Izquierdo);
                PreOrden(raiz.Derecho);
            }
        }

        public void PostOrden(Nodo raiz)
        {
            if (raiz != null)
            {
                PostOrden(raiz.Izquierdo);
                PostOrden(raiz.Derecho);
                Console.Write(raiz.Valor + " ");
            }
        }

        // Máximo
        public Nodo Maximo(Nodo raiz)
        {
            while (raiz.Derecho != null)
                raiz = raiz.Derecho;
            return raiz;
        }

        // Altura
        public int Altura(Nodo raiz)
        {
            if (raiz == null) return -1;

            int izquierda = Altura(raiz.Izquierdo);
            int derecha = Altura(raiz.Derecho);

            return Math.Max(izquierda, derecha) + 1;
        }

        // Limpiar árbol
        public void Limpiar()
        {
            Raiz = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BST arbol = new BST();
            int opcion, valor;

            do
            {
                Console.WriteLine("\n===== MENÚ BST =====");
                Console.WriteLine("1. Insertar");
                Console.WriteLine("2. Buscar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Recorrido Inorden");
                Console.WriteLine("5. Recorrido Preorden");
                Console.WriteLine("6. Recorrido Postorden");
                Console.WriteLine("7. Mostrar mínimo");
                Console.WriteLine("8. Mostrar máximo");
                Console.WriteLine("9. Mostrar altura");
                Console.WriteLine("10. Limpiar árbol");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese valor: ");
                        valor = int.Parse(Console.ReadLine());
                        arbol.Raiz = arbol.Insertar(arbol.Raiz, valor);
                        break;

                    case 2:
                        Console.Write("Ingrese valor a buscar: ");
                        valor = int.Parse(Console.ReadLine());
                        Console.WriteLine(arbol.Buscar(arbol.Raiz, valor) ? "Encontrado" : "No encontrado");
                        break;

                    case 3:
                        Console.Write("Ingrese valor a eliminar: ");
                        valor = int.Parse(Console.ReadLine());
                        arbol.Raiz = arbol.Eliminar(arbol.Raiz, valor);
                        break;

                    case 4:
                        Console.Write("Inorden: ");
                        arbol.InOrden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.Write("Preorden: ");
                        arbol.PreOrden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.Write("Postorden: ");
                        arbol.PostOrden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 7:
                        if (arbol.Raiz != null)
                            Console.WriteLine("Mínimo: " + arbol.Minimo(arbol.Raiz).Valor);
                        else
                            Console.WriteLine("Árbol vacío");
                        break;

                    case 8:
                        if (arbol.Raiz != null)
                            Console.WriteLine("Máximo: " + arbol.Maximo(arbol.Raiz).Valor);
                        else
                            Console.WriteLine("Árbol vacío");
                        break;

                    case 9:
                        Console.WriteLine("Altura: " + arbol.Altura(arbol.Raiz));
                        break;

                    case 10:
                        arbol.Limpiar();
                        Console.WriteLine("Árbol limpiado");
                        break;

                }

            } while (opcion != 0);
        }
    }
}
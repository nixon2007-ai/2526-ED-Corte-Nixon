using System;
using System.Collections.Generic;
using System.Linq;

namespace VuelosBaratosEcuador
{
    class Grafo
    {
        public Dictionary<string, List<(string destino, int precio)>> adj =
            new Dictionary<string, List<(string, int)>>();

        public void AgregarVuelo(string origen, string destino, int precio)
        {
            if (!adj.ContainsKey(origen))
                adj[origen] = new List<(string, int)>();

            if (!adj.ContainsKey(destino))
                adj[destino] = new List<(string, int)>();

            adj[origen].Add((destino, precio));
            adj[destino].Add((origen, precio)); // ida y vuelta
        }

        public List<string> Ciudades() => adj.Keys.ToList();
    }

    class Program
    {
        static void Main()
        {
            Grafo grafo = new Grafo();

            // ===== BASE DE DATOS FICTICIA DE VUELOS (ECUADOR) =====
            CargarBaseDeDatos(grafo);

            Console.WriteLine("BIENVENIDOS AL SISTEMA DE VUELOS NACIONALES – ECUADOR\n");
            Console.WriteLine("Ciudades disponibles:");
            foreach (var c in grafo.Ciudades())
                Console.WriteLine("- " + c);

            Console.Write("\nCiudad de origen: ");
            string origen = Console.ReadLine();

            Console.Write("Ciudad de destino: ");
            string destino = Console.ReadLine();

            var (costo, ruta) = Dijkstra(grafo, origen, destino);

            Console.WriteLine("\nTU RESULTADO SERIA LO SIGUIENTE");
            if (costo == int.MaxValue)
            {
                Console.WriteLine("No existe una ruta disponible.");
            }
            else
            {
                Console.WriteLine("Ruta más barata:");
                Console.WriteLine(string.Join(" -> ", ruta));
                Console.WriteLine($"Costo total del vuelo: ${costo}");
            }

            Console.ReadLine();
        }

        // ===== BASE DE DATOS FICTICIA =====
        static void CargarBaseDeDatos(Grafo grafo)
        {
            grafo.AgregarVuelo("Quito", "Guayaquil", 120);
            grafo.AgregarVuelo("Quito", "Cuenca", 140);
            grafo.AgregarVuelo("Quito", "Manta", 130);
            grafo.AgregarVuelo("Quito", "Esmeraldas", 110);
            grafo.AgregarVuelo("Quito", "Nueva Loja", 130);

            grafo.AgregarVuelo("Guayaquil", "Durán", 40);
            grafo.AgregarVuelo("Guayaquil", "Milagro", 45);
            grafo.AgregarVuelo("Guayaquil", "Machala", 80);
            grafo.AgregarVuelo("Guayaquil", "Salinas", 55);

            grafo.AgregarVuelo("Cuenca", "Loja", 60);
            grafo.AgregarVuelo("Cuenca", "Riobamba", 110);

            grafo.AgregarVuelo("Manta", "Portoviejo", 45);
            grafo.AgregarVuelo("Portoviejo", "Chone", 40);

            grafo.AgregarVuelo("Ambato", "Baños", 25);
            grafo.AgregarVuelo("Baños", "Riobamba", 35);

            grafo.AgregarVuelo("Quito", "Puerto Ayora", 280); // Galápagos
        }

        // ===== ALGORITMO DIJKSTRA =====
        static (int, List<string>) Dijkstra(Grafo g, string origen, string destino)
        {
            var dist = g.Ciudades().ToDictionary(c => c, c => int.MaxValue);
            var previo = new Dictionary<string, string>();
            var visitado = new HashSet<string>();

            dist[origen] = 0;

            while (visitado.Count < g.Ciudades().Count)
            {
                string actual = dist
                    .Where(x => !visitado.Contains(x.Key))
                    .OrderBy(x => x.Value)
                    .First().Key;

                if (actual == destino) break;

                visitado.Add(actual);

                foreach (var (vecino, precio) in g.adj[actual])
                {
                    int nuevaDist = dist[actual] + precio;
                    if (nuevaDist < dist[vecino])
                    {
                        dist[vecino] = nuevaDist;
                        previo[vecino] = actual;
                    }
                }
            }

            List<string> ruta = new List<string>();
            string nodo = destino;

            while (previo.ContainsKey(nodo))
            {
                ruta.Insert(0, nodo);
                nodo = previo[nodo];
            }

            if (ruta.Count > 0)
                ruta.Insert(0, origen);

            return (dist[destino], ruta);
        }
    }
}
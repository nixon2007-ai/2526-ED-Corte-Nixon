using System;
using System.Collections.Generic;
using System.Linq;

class Ciudadano
{
    public string Nombre { get; set; }

    // Dosis por marca
    public int DosisPfizer { get; set; }
    public int DosisAstra { get; set; }

    // Propiedades derivadas (útiles para filtros)
    public bool VacunadoPfizer => DosisPfizer >= 1;
    public bool VacunadoAstra => DosisAstra >= 1;
    public int DosisTotales => DosisPfizer + DosisAstra;

    // Interpretaciones de "ambas dosis"
    public bool AmbasDosis_Total => DosisTotales >= 2;                 // 2 o más dosis en total (mezcla o misma marca)
    public bool AmbasDosis_MismaMarca => (DosisPfizer >= 2) || (DosisAstra >= 2); // 2 de la misma marca (esquema completo homogéneo)
}

class Program
{
    static void Main()
    {
        // 1) Universo U: 500 ciudadanos
        var ciudadanos = GenerarCiudadanos(500);

        // 2) Parámetros de los conjuntos por marca
        int totalPfizer = 75;    // |P|
        int totalAstra  = 75;    // |A|
        int traslape    = 25;    // |P ∩ A| (cuántos reciben ambas marcas). Pon 0 si NO quieres traslape.

        traslape = Math.Max(0, Math.Min(traslape, Math.Min(totalPfizer, totalAstra)));

        // 3) Seleccionamos P y A con barajado
        var rnd = new Random();
        var barajados = ciudadanos.OrderBy(_ => rnd.Next()).ToList();

        // Conjunto P (75)
        var conjuntoPfizer = new HashSet<Ciudadano>(barajados.Take(totalPfizer));

        // Intersección elegida desde P
        var interseccionElegida = conjuntoPfizer.OrderBy(_ => rnd.Next()).Take(traslape).ToList();

        // Resto para A (sin repetir P, salvo intersección)
        var candidatosNoPfizer = barajados.Skip(totalPfizer).Where(c => !conjuntoPfizer.Contains(c)).ToList();
        int faltanAstraSolo = totalAstra - traslape;
        var soloAstra = candidatosNoPfizer.OrderBy(_ => rnd.Next()).Take(faltanAstraSolo).ToList();

        // Conjunto A (75) = intersección + exclusivos de A
        var conjuntoAstra = new HashSet<Ciudadano>(interseccionElegida.Concat(soloAstra));

        // 4) Asignamos dosis según pertenencia a conjuntos (manteniendo exactamente 75 en cada marca)
        //    - P \ A: 1–2 dosis de Pfizer
        //    - A \ P: 1–2 dosis de Astra
        //    - P ∩ A: al menos 1 de Pfizer y 1 de Astra (=> ya cumplen 2 dosis totales)
        //    - U \ (P ∪ A): 0 dosis
        var soloPfizerSet = new HashSet<Ciudadano>(conjuntoPfizer);
        soloPfizerSet.ExceptWith(conjuntoAstra);

        var soloAstraSet = new HashSet<Ciudadano>(conjuntoAstra);
        soloAstraSet.ExceptWith(conjuntoPfizer);

        var ambasMarcasSet = new HashSet<Ciudadano>(conjuntoPfizer);
        ambasMarcasSet.IntersectWith(conjuntoAstra);

        foreach (var c in soloPfizerSet)
        {
            c.DosisPfizer = (rnd.NextDouble() < 0.5) ? 1 : 2; // mitad 1 dosis, mitad 2 dosis aprox.
            c.DosisAstra = 0;
        }

        foreach (var c in soloAstraSet)
        {
            c.DosisAstra = (rnd.NextDouble() < 0.5) ? 1 : 2;
            c.DosisPfizer = 0;
        }

        foreach (var c in ambasMarcasSet)
        {
            // Al menos 1 y 1; opcionalmente una dosis extra aleatoria
            c.DosisPfizer = 1;
            c.DosisAstra = 1;
            // 30% de probabilidad de recibir una dosis adicional (Pfizer o Astra)
            if (rnd.NextDouble() < 0.3)
            {
                if (rnd.NextDouble() < 0.5) c.DosisPfizer++;
                else c.DosisAstra++;
            }
        }

        // Los demás quedan con 0 dosis (no vacunados)
        var unionPA = new HashSet<Ciudadano>(conjuntoPfizer);
        unionPA.UnionWith(conjuntoAstra);

        var noVacunadosSet = new HashSet<Ciudadano>(ciudadanos);
        noVacunadosSet.ExceptWith(unionPA);

        // 5) Listados solicitados (teoría de conjuntos)
        // - No vacunados: U \ (P ∪ A)
        var noVacunados = noVacunadosSet.ToList();

        // - Han recibido ambas dosis: por defecto usamos "2 o más dosis totales"
        var ambasDosis = ciudadanos.Where(c => c.AmbasDosis_Total).ToList();
        // Si prefieres "esquema completo con la misma marca", usa:
        // var ambasDosis = ciudadanos.Where(c => c.AmbasDosis_MismaMarca).ToList();

        // - Solo Pfizer: P \ A
        var soloPfizer = soloPfizerSet.ToList();

        // - Solo AstraZeneca: A \ P
        var soloAstraZeneca = soloAstraSet.ToList();

        // 6) Mostrar resultados
        MostrarResultados("Ciudadanos que no se han vacunado", noVacunados);
        MostrarResultados("Ciudadanos que han recibido ambas dosis (2+ en total)", ambasDosis);
        MostrarResultados("Ciudadanos que solo han recibido la vacuna de Pfizer (P \\ A)", soloPfizer);
        MostrarResultados("Ciudadanos que solo han recibido la vacuna de AstraZeneca (A \\ P)", soloAstraZeneca);

        // (Opcional) Mostrar control de tamaños de conjuntos
        Console.WriteLine($"\nControl:");
        Console.WriteLine($"Total ciudadanos (U): {ciudadanos.Count}");
        Console.WriteLine($"|P| (Pfizer): {conjuntoPfizer.Count}");
        Console.WriteLine($"|A| (Astra): {conjuntoAstra.Count}");
        Console.WriteLine($"|P ∩ A| (ambas marcas): {ambasMarcasSet.Count}");
        Console.WriteLine($"|P ∪ A| (al menos 1 marca): {unionPA.Count}");
    }

    static void MostrarResultados(string titulo, IEnumerable<Ciudadano> ciudadanos)
    {
        var lista = ciudadanos.ToList();
        Console.WriteLine($"\n{titulo}: {lista.Count}");
        foreach (var c in lista)
            Console.WriteLine($"{c.Nombre}  —  Pfizer:{c.DosisPfizer}  Astra:{c.DosisAstra}");
    }

    static List<Ciudadano> GenerarCiudadanos(int total)
    {
        var nombres = new List<string>
        {
            "Sofía Valentina Martínez Pérez", "Lucas Mateo González Rodríguez", "Valentina Gabriela Pérez López",
            "Mateo Nicolás Rodríguez Fernández", "Camila Isabella López Ramírez", "Diego Alejandro Fernández Torres",
            "Isabella Renata Sánchez Morales", "Samuel Andrés Torres Jiménez", "Mariana Paula Ramírez Díaz",
            "Nicolás Sebastián Díaz Herrera", "Gabriela Sofía Herrera Cordero", "Julián Mateo Castro Alarcón",
            "Renata Ana Morales Salazar", "Andrés Felipe Jiménez Paredes", "Paula Valeria Vargas Aguirre",
            "Leonardo Emiliano Ruiz Medina", "Ana Teresa Beltrán Soto", "Sebastián Joaquín Ortega León",
            "Emma Gabriela Silva Cortés", "Felipe Esteban Mendoza Castillo", "Martina Juliana Romero Ríos",
            "Joaquín Cristian Moreno Salas", "Lucía Valeria Salazar Aguirre", "Cristian Ignacio Paredes López",
            "Laura Teresa Aguirre Cordero", "Emiliano Hugo Cordero Ríos", "Sara Valentina Ríos Medina",
            "Bruno Alejandro Soto Fernández", "Carla Teresa Medina Romero", "Mateo Nicolás Castro Jiménez",
            "Valeria Sofía Núñez Alarcón", "Alejandro Matías Peña Torres", "Sofía Renata Jiménez Salazar",
            "Tomás Julián Salgado Moreno", "Juliana Isabel Quiroz Ríos", "Ignacio Sebastián Alarcón Herrera",
            "Teresa Ana León Paredes", "Hugo Andrés Cortés Romero", "Daniela Valentina Castillo Díaz",
            "Esteban Nicolás Salas González", "Mariana Valeria Ortega López", "Nicolás Alejandro Aguirre Sánchez",
            "Valentina Sofía Castro Ramírez", "Santiago Mateo Morales Fernández", "Andrea Gabriela Ramírez Torres",
            "Rodrigo Sebastián Delgado Jiménez", "Paula Laura López Cordero", "Adrián Felipe Torres Alarcón",
            "Laura Ana Pineda Salazar", "Joaquín Esteban Vargas Mendoza", "Alejandra Sofía Herrera Ríos",
            "Matías Nicolás Rojas Cordero", "Gabriela Ana Sánchez Alarcón", "Samuel Felipe Ruiz Medina",
            "Renata Valentina Castro Herrera", "Diego Emiliano Medina López", "Sofía Gabriela González Romero",
            "Leonardo Nicolás Torres Paredes", "Isabella Valentina Pérez Aguirre", "Nicolás Mateo Martínez Fernández",
            "Camila Ana Morales Ríos", "Julián Andrés Salazar Soto", "Valeria Teresa Cordero López",
            "Mateo Cristian Jiménez Alarcón", "Ana Valentina Beltrán Herrera", "Cristian Felipe Ríos González",
            "Paula Sofía Aguirre Martínez", "Sebastián Leonardo Castro Ramírez", "Laura Gabriela Fernández Díaz",
            "Emiliano Nicolás Pérez Salas", "Teresa Valentina Alarcón Romero", "Hugo Joaquín León Cordero",
            "Joaquín Esteban Soto Ríos", "Valentina Gabriela Medina Fernández", "Ignacio Mateo Romero Paredes",
            "Mariana Ana Salas González", "Nicolás Sebastián Torres Aguirre", "Gabriela Valeria Herrera López",
            "Tomás Leonardo Ramírez Alarcón", "Renata Sofía Mendoza Jiménez", "Joaquín Nicolás Morales Ramírez",
            "Ignacio Mateo Pérez Alarcón", "Mariana Sofía Ríos López", "Nicolás Sebastián González Aguirre",
            "Gabriela Valentina Castro Jiménez", "Tomás Julián Ramírez Paredes", "Renata Ana Salazar Cordero"
        };

        var ciudadanos = new List<Ciudadano>();
        for (int i = 0; i < total; i++)
        {
            ciudadanos.Add(new Ciudadano
            {
                // Aseguramos nombres únicos agregando índice
                Nombre = $"{nombres[i % nombres.Count]} #{i + 1}"
            });
        }
        return ciudadanos;
    }
}
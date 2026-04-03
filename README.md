#  Sistema de Vuelos Baratos – Ecuador

##  Descripción del proyecto
Este proyecto implementa un sistema de búsqueda de vuelos baratos a nivel nacional en el Ecuador, utilizando estructuras de datos del tipo grafo.  
Las ciudades del país se representan como nodos, mientras que los vuelos entre ellas se modelan como aristas ponderadas, donde el peso corresponde al precio del vuelo.

La información de vuelos se basa en una base de datos ficticia, incorporada directamente dentro del programa, cumpliendo con los requerimientos de la práctica académica.




##  Objetivo
Encontrar la ruta más económica entre una ciudad de origen y una ciudad de destino, incluso cuando se requiere hacer escalas, aplicando el algoritmo de Dijkstra sobre un grafo ponderado.




##  Relación con la práctica
**Título de la Práctica:**  
*Implementación y representación de árboles y grafos*

Este proyecto se relaciona directamente con la práctica, ya que:
- Implementa un grafo no dirigido.
- Utiliza listas de adyacencia para su representación.
- Aplica algoritmos clásicos de grafos para resolver un problema real.
- Refuerza los conceptos teóricos vistos en la unidad de Árboles y Grafos.




##  Estructura del proyecto
- **Lenguaje:** C#
- **Tipo:** Aplicación de consola
- **Estructura principal:**
  - Clase `Grafo`: gestiona nodos y aristas.
  - Algoritmo de Dijkstra: calcula la ruta de menor costo.
  - Base de datos ficticia integrada en el código.




##  Cómo ejecutar el programa
1. Abrir **Visual Studio**
2. Crear un **Nuevo Proyecto -> Aplicación de Consola (.NET)**
3. Copiar el código del archivo `Program.cs`
4. Ejecutar el programa
5. Ingresar:
   - Ciudad de origen
   - Ciudad de destino
6. Visualizar la ruta más barata y su costo total




##  Funcionalidades
- Visualización de ciudades disponibles
- Cálculo de rutas con múltiples escalas
- Optimización por costo
- Simulación de vuelos realistas a nivel nacional



##  Nota
Los precios y rutas utilizados en este proyecto son ficticios y fueron creados exclusivamente con fines académicos como menciona el docente en la práctica.




##  Desarrolladores

- **Corte Salinas Nixon Darío**
- **Noa Illanes Gricelda Yoshira**
- **Ríos Vivanco Samanta Briggitte**



##  Asignatura
Estructura de Datos - Paralelo "E"

##  Evidencia de la codificación

<img width="848" height="461" alt="image" src="https://github.com/user-attachments/assets/46cf81ea-5cf1-4594-ac6a-fcddd980532c" />

<img width="862" height="468" alt="image" src="https://github.com/user-attachments/assets/ae3f4929-8991-4d7d-bff4-5975471739ee" />



# Traductor Español - Inglés en C#

## Descripción del Proyecto
Este proyecto consiste en una aplicación de consola desarrollada en C#, que implementa un diccionario bilingüe Español–Inglés / Inglés–Español utilizando la estructura de datos Dictionary.

El programa permite:
- Traducir frases completas.
- Agregar nuevas palabras al diccionario.
- Visualizar frases de ejemplo en ambos idiomas.
- Traducir automáticamente palabra por palabra dentro de una oración.

El sistema utiliza expresiones regulares (Regex) para identificar y traducir palabras dentro de una frase sin afectar signos de puntuación.


## Desarrollador
Nixon Dario Corte Salinas


## Tecnologías Utilizadas
- Lenguaje: C#
- Plataforma: .NET (Aplicación de Consola)
- Librerías:
  - System
  - System.Collections.Generic
  - System.Text
  - System.Text.RegularExpressions


## Estructura del Programa

El programa utiliza dos diccionarios principales:

Dictionary<string, string> EsToEn  
Dictionary<string, string> EnToEs  

Estos permiten realizar traducciones bidireccionales entre Español e Inglés.


## Menú Principal

El programa muestra el siguiente menú interactivo:

1. Traducir una frase  
2. Agregar palabra al diccionario  
3. Ver frases de ejemplo  
0. Salir  

El usuario selecciona la opción escribiendo el número correspondiente.



## Funcionalidades

### Traducir Frase
- El usuario ingresa una oración.
- El sistema identifica cada palabra mediante una expresión regular.
- Busca la palabra en el diccionario.
- Si la encuentra, la traduce.
- Si no la encuentra, la deja igual.
- Finalmente muestra la frase traducida.

### Agregar Palabra
- El usuario ingresa una palabra en español.
- Luego ingresa su traducción en inglés.
- La palabra se almacena en ambos diccionarios para permitir traducción en ambas direcciones.

### Mostrar Frases
El sistema muestra 20 frases en español y 20 frases en inglés para práctica.



## Funcionamiento del Algoritmo de Traducción

1. Se captura la frase ingresada por el usuario.
2. Se usa Regex.Replace() para identificar cada palabra.
3. Se verifica si existe en el diccionario Español–Inglés.
4. Si no existe, se verifica en el diccionario Inglés–Español.
5. Se reemplaza por su traducción correspondiente.
6. Se imprime la frase final traducida.



## Características del Proyecto

✔ Contiene más de 100 palabras base  
✔ Traducción bidireccional  
✔ No distingue entre mayúsculas y minúsculas  
✔ Permite agregar nuevas palabras dinámicamente  
✔ Uso de expresiones regulares  
✔ Interfaz sencilla basada en consola  



## Cómo Ejecutarlo

1. Abrir Visual Studio.
2. Crear un nuevo proyecto de tipo "Aplicación de Consola (.NET)".
3. Copiar el código en el archivo Program.cs.
4. Ejecutar con Ctrl + F5.



## Posibles Mejoras Futuras

- Guardar palabras agregadas en un archivo externo (.txt o JSON).
- Implementar base de datos.
- Crear una interfaz gráfica.
- Agregar eliminación de palabras.
- Mejorar la traducción con tiempos verbales.
- Detectar automáticamente el idioma ingresado.



## Objetivo Académico

Este proyecto fue desarrollado con fines educativos para reforzar:
- Uso de estructuras de datos (Dictionary).
- Manipulación de cadenas de texto.
- Uso de expresiones regulares.
- Lógica de programación.
- Creación de menús interactivos en consola.



Proyecto académico desarrollado por Nixon Dario Corte Salinas.

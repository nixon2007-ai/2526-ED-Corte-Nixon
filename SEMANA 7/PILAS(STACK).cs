using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese una expresión matemática:");
        string expresion = Console.ReadLine();
        
        if (VerificarBalance(expresion))
        {
            Console.WriteLine("Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Fórmula no balanceada.");
        }
    }

    static bool VerificarBalance(string expresion)
    {
        Stack<char> pila = new Stack<char>();
        foreach (char c in expresion)
        {
            if (c == '{' || c == '(' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == '}' || c == ')' || c == ']')
            {
                if (pila.Count == 0) return false;
                char top = pila.Pop();
                if (!EsParentesisBalanceado(top, c)) return false;
            }
        }
        return pila.Count == 0;
    }

    static bool EsParentesisBalanceado(char apertura, char cierre)
    {
        return (apertura == '{' && cierre == '}') ||
               (apertura == '(' && cierre == ')') ||
               (apertura == '[' && cierre == ']');
    }
}

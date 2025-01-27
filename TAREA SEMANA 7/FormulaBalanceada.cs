using System;
using System.Collections.Generic;

class Program
{
    // Función para verificar si los paréntesis, corchetes y llaves están balanceados
    static bool EstaBalanceada(string expresion)
    {
        // Usamos una pila para guardar los símbolos de apertura
        Stack<char> pila = new Stack<char>();

        // Recorremos cada carácter de la expresión
        for (int i = 0; i < expresion.Length; i++)
        {
            char caracter = expresion[i];

            // Si es un símbolo de apertura, lo agregamos a la pila
            if (caracter == '(' || caracter == '[' || caracter == '{')
            {
                pila.Push(caracter);
            }
            // Si es un símbolo de cierre, verificamos si coincide con el último de la pila
            else if (caracter == ')' || caracter == ']' || caracter == '}')
            {
                // Si la pila está vacía, no hay un símbolo de apertura correspondiente
                if (pila.Count == 0)
                {
                    return false;
                }

                // Sacamos el último símbolo de apertura de la pila
                char ultimo = pila.Pop();

                // Verificamos si el símbolo de cierre coincide con el de apertura
                if ((caracter == ')' && ultimo != '(') ||
                    (caracter == ']' && ultimo != '[') ||
                    (caracter == '}' && ultimo != '{'))
                {
                    return false; // No están balanceados
                }
            }
        }

        // Si la pila está vacía, todos los símbolos están balanceados
        return pila.Count == 0;
    }

// JEFFREY JOSE MAYORGA ANGOS PARALELO A
    static void Main()
    {
        // Expresión matemática que queremos verificar
        string expresion = "{7+(8*5)-[(9-7)+(4+1)]}";

        // Llamamos a la función y mostramos el resultado
        if (EstaBalanceada(expresion))
        {
            Console.WriteLine("La expresión está balanceada.");
        }
        else
        {
            Console.WriteLine("La expresión NO está balanceada.");
        }
    }
}
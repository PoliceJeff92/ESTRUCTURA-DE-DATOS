using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numeros = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            Console.Write($"Introduce el número ganador {i + 1}: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            numeros.Add(numero);
        }

        numeros.Sort();

        Console.WriteLine("Números ganadores ordenados:");
        foreach (int numero in numeros)
        {
            Console.Write(numero + " ");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numeros = Enumerable.Range(1, 10).ToList();
        numeros.Reverse();

        Console.WriteLine("Números en orden inverso:");
        Console.WriteLine(string.Join(", ", numeros));
    }
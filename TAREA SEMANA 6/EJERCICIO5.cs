using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Listas para guardar los números primos y Armstrong
        List<int> primos = new List<int>();
        List<int> armstrong = new List<int>();

        // Números que vamos a revisar
        int[] numeros = { 2, 3, 4, 5, 153, 370, 371, 407, 13, 17, 19, 9474 };

        // Recorremos los números
        foreach (int num in numeros)
        {
            // Verificamos si es primo
            if (EsPrimo(num))
            {
                primos.Add(num); // Lo agregamos al final de la lista de primos
            }

            // Verificamos si es Armstrong
            if (EsArmstrong(num))
            {
                armstrong.Insert(0, num); // Lo agregamos al inicio de la lista de Armstrong
            }
        }

        // a. Mostrar cuántos números hay en cada lista
        Console.WriteLine("Números primos insertados: " + primos.Count);
        Console.WriteLine("Números Armstrong insertados: " + armstrong.Count);

        // b. Decir cuál lista tiene más elementos
        if (primos.Count > armstrong.Count)
        {
            Console.WriteLine("La lista de primos tiene más elementos.");
        }
        else if (primos.Count < armstrong.Count)
        {
            Console.WriteLine("La lista de Armstrong tiene más elementos.");
        }
        else
        {
            Console.WriteLine("Ambas listas tienen la misma cantidad de elementos.");
        }

        // c. Mostrar todos los números de las listas
        Console.WriteLine("Números primos:");
        foreach (int primo in primos)
        {
            Console.Write(primo + " ");
        }

        Console.WriteLine("\nNúmeros Armstrong:");
        foreach (int arm in armstrong)
        {
            Console.Write(arm + " ");
        }
    }

    // Función para saber si un número es primo
    static bool EsPrimo(int num)
    {
        if (num <= 1)
            return false;
        if (num == 2)
            return true;

        for (int i = 2; i < num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    // Función para saber si un número es Armstrong
    static bool EsArmstrong(int num)
    {
        int suma = 0;
        int temp = num;
        int digitos = num.ToString().Length;

        while (temp > 0)
        {
            int digito = temp % 10;
            suma += (int)Math.Pow(digito, digitos);
            temp /= 10;
        }
// JEFFREY JOSE MAYORGA ANGOS
        return suma == num;
    }
}
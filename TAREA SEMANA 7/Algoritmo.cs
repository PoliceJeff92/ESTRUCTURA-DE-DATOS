using System;
using System.Collections.Generic;

class Program
{
    // Función para mover un disco de una torre a otra
    static void MoverDisco(Stack<int> origen, Stack<int> destino, char torreOrigen, char torreDestino)
    {
        // Sacamos el disco de la torre de origen
        int disco = origen.Pop();

        // Lo colocamos en la torre de destino
        destino.Push(disco);

        // Mostramos el movimiento en la consola
        Console.WriteLine($"Mover disco {disco} de {torreOrigen} a {torreDestino}");
    }

    // Función recursiva para resolver el problema de las Torres de Hanoi
    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, char torreOrigen, char torreDestino, char torreAuxiliar)
    {
        // Si solo hay un disco, lo movemos directamente
        if (n == 1)
        {
            MoverDisco(origen, destino, torreOrigen, torreDestino);
        }
        else
        {
            // Movemos n-1 discos de la torre de origen a la torre auxiliar
            ResolverHanoi(n - 1, origen, auxiliar, destino, torreOrigen, torreAuxiliar, torreDestino);

            // Movemos el disco restante de la torre de origen a la torre de destino
            MoverDisco(origen, destino, torreOrigen, torreDestino);

            // Movemos los n-1 discos de la torre auxiliar a la torre de destino
            ResolverHanoi(n - 1, auxiliar, destino, origen, torreAuxiliar, torreDestino, torreOrigen);
        }
    }

// JEFFREY MAYORGA ANGOS PARALELO A
    static void Main()
    {
        // Número de discos
        int n = 3;

        // Creamos las tres torres como pilas
        Stack<int> torreA = new Stack<int>();
        Stack<int> torreB = new Stack<int>();
        Stack<int> torreC = new Stack<int>();

        // Llenamos la torre A con los discos (el disco más grande en la base)
        for (int i = n; i >= 1; i--)
        {
            torreA.Push(i);
        }

        // Llamamos a la función para resolver el problema
        Console.WriteLine("Movimientos para resolver las Torres de Hanoi:");
        ResolverHanoi(n, torreA, torreC, torreB, 'A', 'C', 'B');
    }
}
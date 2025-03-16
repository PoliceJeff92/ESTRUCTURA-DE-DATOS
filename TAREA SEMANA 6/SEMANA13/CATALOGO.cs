using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creo una lista para guardar los títulos de las revistas.
        // No estoy seguro si debería usar un array o una lista, pero creo que la lista es mejor porque se puede modificar fácilmente.
        List<string> catalogoRevistas = new List<string>();

        // Agrego 10 títulos al catálogo. 
        // Me dijeron que no importaba mucho cuáles fueran los títulos, así que puse algunos que se me ocurrieron.
        catalogoRevistas.Add("Revista de Ciencia y Tecnología");
        catalogoRevistas.Add("National Geographic");
        catalogoRevistas.Add("Muy Interesante");
        catalogoRevistas.Add("Nature");
        catalogoRevistas.Add("Scientific American");
        catalogoRevistas.Add("Forbes");
        catalogoRevistas.Add("Harvard Business Review");
        catalogoRevistas.Add("The Economist");
        catalogoRevistas.Add("Time Magazine");
        catalogoRevistas.Add("Wired");

        Console.WriteLine("Bienvenido al Catálogo de Revistas");
        Console.WriteLine("---------------------------------");

        // Aquí hago un menú para que el usuario pueda buscar un título o salir del programa.
        // No sé si este es el mejor diseño para un menú, pero creo que funciona.
        bool continuar = true; // Esto lo uso para controlar si el usuario quiere seguir usando el programa.
        while (continuar)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine(); // Leo la opción del usuario.

            // Uso un switch para manejar las opciones del menú.
            // Espero haberlo hecho bien, aunque todavía me confundo un poco con los casos.
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título a buscar: ");
                    string tituloBuscar = Console.ReadLine();

                    // Llamo a mi función de búsqueda iterativa para ver si el título está en el catálogo.
                    if (BuscarTituloIterativo(catalogoRevistas, tituloBuscar))
                    {
                        Console.WriteLine("Encontrado"); // Si lo encuentra, imprimo "Encontrado".
                    }
                    else
                    {
                        Console.WriteLine("No encontrado"); // Si no lo encuentra, imprimo "No encontrado".
                    }
                    break;

                case "2":
                    Console.WriteLine("Saliendo del programa..."); // Si el usuario elige salir, termino el programa.
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente."); // Si el usuario ingresa algo incorrecto, le pido que intente de nuevo.
                    break;
            }
        }
    }

    // Esta es mi función para buscar un título en el catálogo.
    // La hice iterativa porque todavía no entiendo muy bien cómo hacer búsquedas recursivas.
    static bool BuscarTituloIterativo(List<string> catalogo, string titulo)
    {
        // Recorro toda la lista de revistas una por una.
        foreach (string revista in catalogo)
        {
            // Comparo cada título con el que el usuario ingresó.
            // Usé StringComparison.OrdinalIgnoreCase porque quería que no distinga entre mayúsculas y minúsculas.
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true; // Si encuentro el título, retorno true.
            }
        } // Desarrollado por Jeffrey Jose Mayorga Angos 

        // Si llegué hasta aquí, significa que no encontré el título.
        return false;
    }
}
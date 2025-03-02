using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Diccionario inicial con las palabras proporcionadas
        Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "time", "tiempo" },
            { "person", "persona" },
            { "year", "año" },
            { "way", "camino/forma" },
            { "day", "día" },
            { "thing", "cosa" },
            { "man", "hombre" },
            { "world", "mundo" },
            { "life", "vida" },
            { "hand", "mano" },
            { "part", "parte" },
            { "child", "niño/a" },
            { "eye", "ojo" },
            { "woman", "mujer" },
            { "place", "lugar" },
            { "work", "trabajo" },
            { "week", "semana" },
            { "case", "caso" },
            { "point", "punto/tema" },
            { "government", "gobierno" },
            { "company", "empresa/compañía" }
        };

        bool running = true;

        while (running)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    TranslatePhrase(dictionary);
                    break;

                case "2":
                    AddWordsToDictionary(dictionary);
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void TranslatePhrase(Dictionary<string, string> dictionary)
    {
        Console.Write("Ingrese la frase a traducir: ");
        string phrase = Console.ReadLine();

        string[] words = phrase.Split(' ');
        List<string> translatedWords = new List<string>();

        foreach (string word in words)
        {
            string cleanedWord = word.Trim(new char[] { '.', ',', '!', '?' });

            if (dictionary.ContainsKey(cleanedWord))
            {
                // Si la palabra está en el diccionario, la traduce
                translatedWords.Add(dictionary[cleanedWord]);
            }
            else if (dictionary.ContainsValue(cleanedWord))
            {
                // Si la palabra es un valor en el diccionario, busca la clave correspondiente
                string key = dictionary.FirstOrDefault(x => x.Value.Equals(cleanedWord, StringComparison.OrdinalIgnoreCase)).Key;
                translatedWords.Add(key);
            }
            else
            {
                // Si no se encuentra en el diccionario, deja la palabra original
                translatedWords.Add(cleanedWord);
            }
        }

        string translatedPhrase = string.Join(" ", translatedWords);
        Console.WriteLine($"Su frase traducida es: {translatedPhrase}");
    }

    static void AddWordsToDictionary(Dictionary<string, string> dictionary)
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string englishWord = Console.ReadLine().Trim();

        Console.Write("Ingrese la traducción en español: ");
        string spanishWord = Console.ReadLine().Trim();

        if (!dictionary.ContainsKey(englishWord))
        {
            dictionary.Add(englishWord, spanishWord);
            Console.WriteLine($"Palabra '{englishWord}' agregada al diccionario.");
        }
        else
        {
            Console.WriteLine($"La palabra '{englishWord}' ya existe en el diccionario.");
        }
    }
}
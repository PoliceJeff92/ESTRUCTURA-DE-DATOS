using System;
using System.Collections.Generic;

class Estudiante
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public double Nota { get; set; }

    public Estudiante(string cedula, string nombre, string apellido, string correo, double nota)
    {
        Cedula = cedula;
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        Nota = nota;
    }

    public void Mostrar()
    {
        Console.WriteLine($"Cédula: {Cedula}, Nombre: {Nombre} {Apellido}, Correo: {Correo}, Nota: {Nota}");
    }
}

class Program
{
    static List<Estudiante> estudiantes = new List<Estudiante>();

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- Menú de Estudiantes ---");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Buscar estudiante por cédula");
            Console.WriteLine("3. Eliminar estudiante por cédula");
            Console.WriteLine("4. Mostrar total de aprobados y reprobados");
            Console.WriteLine("5. Mostrar todos los estudiantes");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarEstudiante();
                    break;
                case 2:
                    BuscarEstudiante();
                    break;
                case 3:
                    EliminarEstudiante();
                    break;
                case 4:
                    MostrarTotales();
                    break;
                case 5:
                    MostrarTodos();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }

    static void AgregarEstudiante()
    {
        Console.WriteLine("\n--- Agregar Estudiante ---");
        Console.Write("Cédula: ");
        string cedula = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Correo: ");
        string correo = Console.ReadLine();
        Console.Write("Nota (1-10): ");
        double nota = double.Parse(Console.ReadLine());

        Estudiante nuevo = new Estudiante(cedula, nombre, apellido, correo, nota);

        if (nota >= 6)
        {
            estudiantes.Insert(0, nuevo); // Aprobados al inicio
            Console.WriteLine("Estudiante aprobado agregado al inicio.");
        }
        else
        {
            estudiantes.Add(nuevo); // Reprobados al final
            Console.WriteLine("Estudiante reprobado agregado al final.");
        }
    }

    static void BuscarEstudiante()
    {
        Console.WriteLine("\n--- Buscar Estudiante ---");
        Console.Write("Ingresa la cédula: ");
        string cedula = Console.ReadLine();

        bool encontrado = false;
        foreach (var est in estudiantes)
        {
            if (est.Cedula == cedula)
            {
                Console.WriteLine("Estudiante encontrado:");
                est.Mostrar();
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    static void EliminarEstudiante()
    {
        Console.WriteLine("\n--- Eliminar Estudiante ---");
        Console.Write("Ingresa la cédula: ");
        string cedula = Console.ReadLine();

        bool eliminado = false;
        for (int i = 0; i < estudiantes.Count; i++)
        {
            if (estudiantes[i].Cedula == cedula)
            {
                estudiantes.RemoveAt(i);
                Console.WriteLine("Estudiante eliminado.");
                eliminado = true;
                break;
            }
        }

        if (!eliminado)
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    static void MostrarTotales()
    {
        int aprobados = 0;
        int reprobados = 0;

        foreach (var est in estudiantes)
        {
            if (est.Nota >= 6)
                aprobados++;
            else
                reprobados++;
        }

        Console.WriteLine("\n--- Totales ---");
        Console.WriteLine($"Aprobados: {aprobados}");
        Console.WriteLine($"Reprobados: {reprobados}");
    }

    static void MostrarTodos()
    {
        Console.WriteLine("\n--- Lista de Estudiantes ---");
        foreach (var est in estudiantes)
        {
            est.Mostrar();
        }
    }
}
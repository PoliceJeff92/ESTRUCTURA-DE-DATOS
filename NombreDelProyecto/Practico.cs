﻿using System;
using System.Collections.Generic;

// Clase que representa a un paciente
class Paciente
{
    // Propiedades del paciente
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string HistorialMedico { get; set; }

    // Constructor para inicializar los datos del paciente
    public Paciente(string nombre, string telefono, string email, DateTime fechaNacimiento, string historialMedico)
    {
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        FechaNacimiento = fechaNacimiento;
        HistorialMedico = historialMedico;
    }
}

// Clase que gestiona la agenda de turnos
class AgendaTurnos
{
    // Lista para almacenar los pacientes
    private List<Paciente> pacientes;

    // Diccionario para almacenar los turnos (fecha y hora como clave, paciente como valor)
    private Dictionary<DateTime, Paciente> turnos;

    // Constructor para inicializar las estructuras de datos
    public AgendaTurnos()
    {
        pacientes = new List<Paciente>();
        turnos = new Dictionary<DateTime, Paciente>();
    }

    // Método para agregar un paciente a la lista
    public void AgregarPaciente(Paciente paciente)
    {
        pacientes.Add(paciente);
        Console.WriteLine("Paciente agregado correctamente.");
    }

    // Método para asignar un turno a un paciente
    public void AsignarTurno(DateTime fechaHora, string nombrePaciente)
    {
        // Buscar al paciente por nombre
        Paciente paciente = pacientes.Find(p => p.Nombre == nombrePaciente);
        if (paciente != null)
        {
            // Verificar si el turno ya está ocupado
            if (!turnos.ContainsKey(fechaHora))
            {
                turnos[fechaHora] = paciente;
                Console.WriteLine("Turno asignado correctamente.");
            }
            else
            {
                Console.WriteLine("El turno ya está ocupado.");
            }
        }
        else
        {
            Console.WriteLine("Paciente no encontrado.");
        }
    }

    // Método para mostrar todos los turnos asignados
    public void MostrarTurnos()
    {
        if (turnos.Count == 0)
        {
            Console.WriteLine("No hay turnos asignados.");
            return;
        }

        Console.WriteLine("Lista de Turnos:");
        foreach (var turno in turnos)
        {
            Console.WriteLine($"Fecha: {turno.Key}, Paciente: {turno.Value.Nombre}");
        }
    }

    // Método para buscar y mostrar la información de un paciente
    public void BuscarPaciente(string nombre)
    {
        Paciente paciente = pacientes.Find(p => p.Nombre == nombre);
        if (paciente != null)
        {
            Console.WriteLine("Información del Paciente:");
            Console.WriteLine($"Nombre: {paciente.Nombre}");
            Console.WriteLine($"Teléfono: {paciente.Telefono}");
            Console.WriteLine($"Email: {paciente.Email}");
            Console.WriteLine($"Fecha de Nacimiento: {paciente.FechaNacimiento.ToShortDateString()}");
            Console.WriteLine($"Historial Médico: {paciente.HistorialMedico}");
        }
        else
        {
            Console.WriteLine("Paciente no encontrado.");
        }
    }
}

// JEFFREY MAYORGA ANGOS
// Clase principal del programa
class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia de la agenda de turnos
        AgendaTurnos agenda = new AgendaTurnos();
        bool salir = false;

        // Menú interactivo
        while (!salir)
        {
            Console.WriteLine("\n--- Menú de la Clínica ---");
            Console.WriteLine("1. Agregar Paciente");
            Console.WriteLine("2. Asignar Turno");
            Console.WriteLine("3. Ver Turnos");
            Console.WriteLine("4. Buscar Paciente");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": // Agregar paciente
                    Console.Write("Nombre del paciente: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Teléfono: ");
                    string telefono = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Fecha de Nacimiento (yyyy-MM-dd): ");
                    DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());
                    Console.Write("Historial Médico: ");
                    string historialMedico = Console.ReadLine();

                    Paciente nuevoPaciente = new Paciente(nombre, telefono, email, fechaNacimiento, historialMedico);
                    agenda.AgregarPaciente(nuevoPaciente);
                    break;

                case "2": // Asignar turno
                    Console.Write("Fecha y Hora del Turno (yyyy-MM-dd HH:mm): ");
                    DateTime fechaHora = DateTime.Parse(Console.ReadLine());
                    Console.Write("Nombre del paciente: ");
                    string nombrePaciente = Console.ReadLine();
                    agenda.AsignarTurno(fechaHora, nombrePaciente);
                    break;

                case "3": // Ver turnos
                    agenda.MostrarTurnos();
                    break;

                case "4": // Buscar paciente
                    Console.Write("Nombre del paciente a buscar: ");
                    string nombreBuscar = Console.ReadLine();
                    agenda.BuscarPaciente(nombreBuscar);
                    break;

                case "5": // Salir del programa
                    salir = true;
                    Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
                    break;

                default: // Opción no válida
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace TorneoFutbol
{
    // Desarrollado por los estudiantes:
    // Jeffrey Jose Mayorga Angos
    // Lucia Jeaneth Rodríguez Requelme
    // Ana Lucía Toapanta Trujillo

    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Posicion { get; set; }
        public int EquipoId { get; set; }

        public Jugador(int id, string nombre, int edad, string posicion, int equipoId)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
            Posicion = posicion;
            EquipoId = equipoId;
        }

        public override bool Equals(object obj)
        {
            return obj is Jugador jugador && Id == jugador.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public HashSet<Jugador> Jugadores { get; set; }

        public Equipo(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Jugadores = new HashSet<Jugador>();
        }
    }

    public class Torneo
    {
        private Dictionary<int, Equipo> equipos;

        public Torneo()
        {
            equipos = new Dictionary<int, Equipo>();
        }

        public void AgregarEquipo(int id, string nombre)
        {
            if (!equipos.ContainsKey(id))
            {
                equipos[id] = new Equipo(id, nombre);
                Console.WriteLine($"Equipo '{nombre}' agregado.");
            }
            else
            {
                Console.WriteLine("El equipo ya existe.");
            }
        }

        public void AgregarJugador(int id, string nombre, int edad, string posicion, int equipoId)
        {
            if (equipos.ContainsKey(equipoId))
            {
                Jugador jugador = new Jugador(id, nombre, edad, posicion, equipoId);
                if (equipos[equipoId].Jugadores.Add(jugador))
                {
                    Console.WriteLine($"Jugador '{nombre}' agregado al equipo '{equipos[equipoId].Nombre}'.");
                }
                else
                {
                    Console.WriteLine("El jugador ya existe en el equipo.");
                }
            }
            else
            {
                Console.WriteLine("El equipo no existe.");
            }
        }

        public void ReportarEquipos()
        {
            foreach (var equipo in equipos.Values)
            {
                Console.WriteLine($"Equipo: {equipo.Nombre}, Jugadores: {string.Join(", ", equipo.Jugadores.Select(j => j.Nombre))}");
            }
        }

        public void ReportarJugadoresEquipo(int equipoId)
        {
            if (equipos.ContainsKey(equipoId))
            {
                var equipo = equipos[equipoId];
                Console.WriteLine($"Jugadores del equipo '{equipo.Nombre}': {string.Join(", ", equipo.Jugadores.Select(j => j.Nombre))}");
            }
            else
            {
                Console.WriteLine("El equipo no existe.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Torneo torneo = new Torneo(); // Crea una nueva instancia de Torneo
            torneo.AgregarEquipo(1, "Equipo A"); // Agrega el equipo A
            torneo.AgregarEquipo(2, "Equipo B"); // Agrega el equipo B
            torneo.AgregarJugador(1, "Jugador 1", 25, "Delantero", 1); // Agrega un jugador al equipo A
            torneo.AgregarJugador(2, "Jugador 2", 22, "Defensa", 1); // Agrega otro jugador al equipo A
            torneo.AgregarJugador(3, "Jugador 3", 30, "Portero", 2); // Agrega un jugador al equipo B

            // Reporta todos los equipos y sus jugadores
            torneo.ReportarEquipos();
            // Reporta los jugadores del equipo A
            torneo.ReportarJugadoresEquipo(1);
        }
    }
}

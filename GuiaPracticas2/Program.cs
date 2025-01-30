using System;
using System.Collections.Generic;

namespace GUIA_DE_PRACTICAS_2_ESTRUCTURA_DE_DATOS
{
    // Clase para simular la asignación de asientos en una atracción de parque
    public class AtraccionParque
    {
        private Queue<string> colaEspera = new Queue<string>(); // Cola para guardar a las personas
        private int asientosTotales = 30; // Total de asientos disponibles
        private int asientosOcupados = 0; // Asientos que ya están ocupados

        // Método para agregar personas a la cola
        public void LlegarPersona(string nombre)
        {
            if (asientosOcupados < asientosTotales)
            {
                colaEspera.Enqueue(nombre); // Agrega a la persona a la cola
                asientosOcupados++; // Aumenta el número de asientos ocupados
                Console.WriteLine($"{nombre} se ha unido a la cola. Asientos disponibles: {asientosTotales - asientosOcupados}");
            }
            else
            {
                Console.WriteLine("Lo siento, todos los asientos están ocupados.");
            }
        }

        // Método para subir a las personas a la atracción
        public void SubirAtraccion()
        {
            Console.WriteLine("Subiendo a la atracción...");
            while (colaEspera.Count > 0)
            {
                string persona = colaEspera.Dequeue(); // Saca a la persona de la cola
                Console.WriteLine($"{persona} ha subido a la atracción.");
            }
            Console.WriteLine("Todos los asientos están ocupados y la atracción está en marcha.");
        }

        // Método para mostrar la cola actual
        public void MostrarCola()
        {
            Console.WriteLine("Personas en la cola:");
            foreach (var persona in colaEspera)
            {
                Console.WriteLine(persona);
            }
        }
    }

    // Clase para simular el botón "retroceder" de un navegador web
    public class NavegadorWeb
    {
        private Stack<string> historial = new Stack<string>(); // Pila para guardar el historial
        private Stack<string> adelante = new Stack<string>(); // Pila para guardar las páginas adelantadas

        // Método para navegar a una nueva página
        public void Navegar(string url)
        {
            historial.Push(url); // Agrega la URL al historial
            adelante.Clear(); // Limpia la pila de adelante
            Console.WriteLine($"Navegando a: {url}");
        }

        // Método para retroceder a la página anterior
        public void Retroceder()
        {
            if (historial.Count > 1) // Verifica si hay páginas para retroceder
            {
                string actual = historial.Pop(); // Saca la página actual del historial
                adelante.Push(actual); // Guarda la página en la pila de adelante
                Console.WriteLine($"Retrocediendo a: {historial.Peek()}");
            }
            else
            {
                Console.WriteLine("No hay páginas anteriores.");
            }
        }

        // Método para adelantar a la página siguiente
        public void Adelantar()
        {
            if (adelante.Count > 0) // Verifica si hay páginas para adelantar
            {
                string siguiente = adelante.Pop(); // Saca la página de la pila de adelante
                historial.Push(siguiente); // Agrega la página al historial
                Console.WriteLine($"Adelantando a: {siguiente}");
            }
            else
            {
                Console.WriteLine("No hay páginas siguientes.");
            }
        }

        // Método para mostrar el historial de navegación
        public void MostrarHistorial()
        {
            Console.WriteLine("Historial de navegación:");
            foreach (var url in historial)
            {
                Console.WriteLine(url);
            }
        }
    }

    // Clase para simular la asignación de asientos en un auditorio
    public class AuditorioCongreso
    {
        private Queue<string> cola1 = new Queue<string>(); // Cola para el primer registro
        private Queue<string> cola2 = new Queue<string>(); // Cola para el segundo registro
        private int asientosTotales = 100; // Total de asientos disponibles
        private int asientosOcupados = 0; // Asientos que ya están ocupados

        // Método para agregar personas a una de las colas
        public void LlegarPersona(string nombre, int cola)
        {
            if (asientosOcupados < asientosTotales)
            {
                if (cola == 1)
                {
                    cola1.Enqueue(nombre); // Agrega a la persona a la cola 1
                }
                else if (cola == 2)
                {
                    cola2.Enqueue(nombre); // Agrega a la persona a la cola 2
                }
                asientosOcupados++; // Aumenta el número de asientos ocupados
                Console.WriteLine($"{nombre} se ha unido a la cola {cola}. Asientos disponibles: {asientosTotales - asientosOcupados}");
            }
            else
            {
                Console.WriteLine("Lo siento, todos los asientos están ocupados.");
            }
        }

        // Método para asignar asientos a las personas en las colas
        public void AsignarAsientos()
        {
            Console.WriteLine("Asignando asientos...");
            while (cola1.Count > 0 || cola2.Count > 0)
            {
                if (cola1.Count > 0)
                {
                    string persona = cola1.Dequeue(); // Saca a la persona de la cola 1
                    Console.WriteLine($"{persona} ha recibido un asiento desde la cola 1.");
                }

                if (cola2.Count > 0)
                {
                    string persona = cola2.Dequeue(); // Saca a la persona de la cola 2
                    Console.WriteLine($"{persona} ha recibido un asiento desde la cola 2.");
                }
            }
            Console.WriteLine("Todos los asientos han sido asignados.");
        }

        // Método para mostrar las colas actuales
        public void MostrarColas()
        {
            Console.WriteLine("Personas en la cola 1:");
            foreach (var persona in cola1)
            {
                Console.WriteLine(persona);
            }

            Console.WriteLine("Personas en la cola 2:");
            foreach (var persona in cola2)
            {
                Console.WriteLine(persona);
            }
        }
    }

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- GUIA DE PRACTICAS 2 ESTRUCTURA DE DATOS -----");

            // Simulación de Parque de Diversiones
            Console.WriteLine("\n----- Simulación de Parque de Diversiones -----");
            AtraccionParque atraccion = new AtraccionParque();
            for (int i = 1; i <= 35; i++)
            {
                atraccion.LlegarPersona($"Persona {i}");
            }
            atraccion.MostrarCola();
            atraccion.SubirAtraccion();

            // Simulación de Navegador Web
            Console.WriteLine("\n----- Simulación de Navegador Web -----");
            NavegadorWeb navegador = new NavegadorWeb();
            navegador.Navegar("https://www.google.com");
            navegador.Navegar("https://www.facebook.com");
            navegador.Navegar("https://www.twitter.com");
            navegador.Retroceder();
            navegador.Adelantar();
            navegador.MostrarHistorial();

            // Simulación de Auditorio de Congreso
            Console.WriteLine("\n----- Simulación de Auditorio de Congreso -----");
            AuditorioCongreso auditorio = new AuditorioCongreso();
            for (int i = 1; i <= 50; i++)
            {
                auditorio.LlegarPersona($"Persona {i}", 1);
                auditorio.LlegarPersona($"Persona {i + 50}", 2);
            }
            auditorio.MostrarColas();
            auditorio.AsignarAsientos();

            // Leyenda con los nombres de los estudiantes
            Console.WriteLine("\n----- Código desarrollado por: -----");
            Console.WriteLine("MAYORGA ANGOS JJEFREY JOSE");
            Console.WriteLine("LUCIA JEANETH RODRIGUEZ REQUELME");
            Console.WriteLine("ANA LUCIA TOAPANTA TRUJILLO");
        }
    }
}

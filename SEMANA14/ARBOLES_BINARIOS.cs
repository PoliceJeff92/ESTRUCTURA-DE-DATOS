using System;
using System.Collections.Generic;

namespace ArbolBinarioPersonalizado
{
    // Clase que representa un nodo del árbol binario personalizado
    class NodoPersonalizado
    {
        public int Valor { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public NodoPersonalizado Izquierdo { get; set; }
        public NodoPersonalizado Derecho { get; set; }

        public NodoPersonalizado(int valor, string descripcion = "")
        {
            Valor = valor;
            Descripcion = descripcion;
            FechaCreacion = DateTime.Now;
            Izquierdo = null;
            Derecho = null;
        }
    }

    // Clase que implementa el árbol binario de búsqueda personalizado
    class ArbolBinarioMejorado
    {
        private NodoPersonalizado raiz;
        private int operacionesRealizadas;
        private DateTime fechaCreacion;

        public ArbolBinarioMejorado()
        {
            raiz = null;
            operacionesRealizadas = 0;
            fechaCreacion = DateTime.Now;
        }

        // Método público para insertar un valor con descripción opcional
        public void Insertar(int valor, string descripcion = "")
        {
            raiz = InsertarRecursivo(raiz, valor, descripcion);
            operacionesRealizadas++;
            Console.WriteLine($"Valor {valor} insertado correctamente. Descripción: {(string.IsNullOrEmpty(descripcion) ? "No proporcionada" : descripcion)}");
        }

        // Método recursivo para insertar un valor
        private NodoPersonalizado InsertarRecursivo(NodoPersonalizado nodo, int valor, string descripcion)
        {
            // Si el árbol está vacío, crear un nuevo nodo
            if (nodo == null)
            {
                return new NodoPersonalizado(valor, descripcion);
            }

            // Si el valor es menor, insertar en el subárbol izquierdo
            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor, descripcion);
            }
            // Si el valor es mayor, insertar en el subárbol derecho
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor, descripcion);
            }
            // Si el valor ya existe, actualizar la descripción
            else
            {
                nodo.Descripcion = descripcion;
                Console.WriteLine($"El valor {valor} ya existe en el árbol. Se ha actualizado su descripción.");
            }

            return nodo;
        }

        // Método para buscar un valor
        public NodoPersonalizado Buscar(int valor)
        {
            operacionesRealizadas++;
            return BuscarRecursivo(raiz, valor);
        }

        // Método recursivo para buscar un valor
        private NodoPersonalizado BuscarRecursivo(NodoPersonalizado nodo, int valor)
        {
            // Si el árbol está vacío o llegamos a una hoja sin encontrar el valor
            if (nodo == null)
            {
                return null;
            }

            // Si encontramos el valor
            if (valor == nodo.Valor)
            {
                return nodo;
            }

            // Si el valor es menor, buscar en el subárbol izquierdo
            if (valor < nodo.Valor)
            {
                return BuscarRecursivo(nodo.Izquierdo, valor);
            }
            // Si el valor es mayor, buscar en el subárbol derecho
            else
            {
                return BuscarRecursivo(nodo.Derecho, valor);
            }
        }

        // Método público para eliminar un valor
        public void Eliminar(int valor)
        {
            bool existeAntes = Buscar(valor) != null;
            raiz = EliminarRecursivo(raiz, valor);
            if (existeAntes)
            {
                operacionesRealizadas++;
            }
        }

        // Método recursivo para eliminar un valor
        private NodoPersonalizado EliminarRecursivo(NodoPersonalizado nodo, int valor)
        {
            // Si el árbol está vacío
            if (nodo == null)
            {
                Console.WriteLine($"El valor {valor} no existe en el árbol.");
                return null;
            }

            // Si el valor a eliminar es menor, ir al subárbol izquierdo
            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);
            }
            // Si el valor a eliminar es mayor, ir al subárbol derecho
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);
            }
            // Si encontramos el nodo a eliminar
            else
            {
                // Caso 1: Nodo sin hijos o con un solo hijo
                if (nodo.Izquierdo == null)
                {
                    Console.WriteLine($"Valor {valor} eliminado correctamente.");
                    return nodo.Derecho;
                }
                else if (nodo.Derecho == null)
                {
                    Console.WriteLine($"Valor {valor} eliminado correctamente.");
                    return nodo.Izquierdo;
                }

                // Caso 2: Nodo con dos hijos
                // Encontrar el sucesor inmediato (valor mínimo en subárbol derecho)
                NodoPersonalizado sucesor = EncontrarNodoMinimo(nodo.Derecho);
                nodo.Valor = sucesor.Valor;
                nodo.Descripcion = sucesor.Descripcion;

                // Eliminar el sucesor inmediato
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor.Valor);
                Console.WriteLine($"Valor {valor} eliminado correctamente.");
            }

            return nodo;
        }

        // Método para encontrar el nodo con valor mínimo en un árbol
        private NodoPersonalizado EncontrarNodoMinimo(NodoPersonalizado nodo)
        {
            NodoPersonalizado actual = nodo;
            
            // Recorrer el árbol hacia la izquierda hasta encontrar el valor mínimo
            while (actual.Izquierdo != null)
            {
                actual = actual.Izquierdo;
            }
            
            return actual;
        }

        // Método para recorrer el árbol en orden (in-order traversal)
        public void RecorridoEnOrden()
        {
            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }
            
            Console.WriteLine("Recorrido En Orden (In-Order):");
            RecorridoEnOrdenRecursivo(raiz);
            Console.WriteLine();
            operacionesRealizadas++;
        }

        // Método recursivo para recorrer el árbol en orden
        private void RecorridoEnOrdenRecursivo(NodoPersonalizado nodo)
        {
            if (nodo != null)
            {
                // Visitar subárbol izquierdo
                RecorridoEnOrdenRecursivo(nodo.Izquierdo);
                // Visitar nodo
                Console.Write($"{nodo.Valor} ({nodo.Descripcion}) ");
                // Visitar subárbol derecho
                RecorridoEnOrdenRecursivo(nodo.Derecho);
            }
        }

        // Método para recorrer el árbol en pre-orden (pre-order traversal)
        public void RecorridoPreOrden()
        {
            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }
            
            Console.WriteLine("Recorrido Pre-Orden (Pre-Order):");
            RecorridoPreOrdenRecursivo(raiz);
            Console.WriteLine();
            operacionesRealizadas++;
        }

        // Método recursivo para recorrer el árbol en pre-orden
        private void RecorridoPreOrdenRecursivo(NodoPersonalizado nodo)
        {
            if (nodo != null)
            {
                // Visitar nodo
                Console.Write($"{nodo.Valor} ({nodo.Descripcion}) ");
                // Visitar subárbol izquierdo
                RecorridoPreOrdenRecursivo(nodo.Izquierdo);
                // Visitar subárbol derecho
                RecorridoPreOrdenRecursivo(nodo.Derecho);
            }
        }

        // Método para recorrer el árbol en post-orden (post-order traversal)
        public void RecorridoPostOrden()
        {
            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }
            
            Console.WriteLine("Recorrido Post-Orden (Post-Order):");
            RecorridoPostOrdenRecursivo(raiz);
            Console.WriteLine();
            operacionesRealizadas++;
        }

        // Método recursivo para recorrer el árbol en post-orden
        private void RecorridoPostOrdenRecursivo(NodoPersonalizado nodo)
        {
            if (nodo != null)
            {
                // Visitar subárbol izquierdo
                RecorridoPostOrdenRecursivo(nodo.Izquierdo);
                // Visitar subárbol derecho
                RecorridoPostOrdenRecursivo(nodo.Derecho);
                // Visitar nodo
                Console.Write($"{nodo.Valor} ({nodo.Descripcion}) ");
            }
        }

        // Método para recorrer el árbol por niveles (level-order traversal)
        public void RecorridoPorNiveles()
        {
            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }
            
            Console.WriteLine("Recorrido Por Niveles (Level-Order):");
            
            Queue<NodoPersonalizado> cola = new Queue<NodoPersonalizado>();
            cola.Enqueue(raiz);
            
            while (cola.Count > 0)
            {
                NodoPersonalizado nodo = cola.Dequeue();
                Console.Write($"{nodo.Valor} ({nodo.Descripcion}) ");
                
                if (nodo.Izquierdo != null)
                {
                    cola.Enqueue(nodo.Izquierdo);
                }
                
                if (nodo.Derecho != null)
                {
                    cola.Enqueue(nodo.Derecho);
                }
            }
            
            Console.WriteLine();
            operacionesRealizadas++;
        }

        // Método para obtener la altura del árbol
        public int ObtenerAltura()
        {
            operacionesRealizadas++;
            return ObtenerAlturaRecursivo(raiz);
        }

        // Método recursivo para obtener la altura del árbol
        private int ObtenerAlturaRecursivo(NodoPersonalizado nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            
            // Calcular la altura de los subárboles
            int alturaIzquierda = ObtenerAlturaRecursivo(nodo.Izquierdo);
            int alturaDerecha = ObtenerAlturaRecursivo(nodo.Derecho);
            
            // La altura es el máximo entre la altura izquierda y derecha, más 1 por el nodo actual
            return Math.Max(alturaIzquierda, alturaDerecha) + 1;
        }

        // Método para contar el número de nodos
        public int ContarNodos()
        {
            operacionesRealizadas++;
            return ContarNodosRecursivo(raiz);
        }

        // Método recursivo para contar el número de nodos
        private int ContarNodosRecursivo(NodoPersonalizado nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            
            // Contar el nodo actual y recursivamente contar los nodos de los subárboles
            return 1 + ContarNodosRecursivo(nodo.Izquierdo) + ContarNodosRecursivo(nodo.Derecho);
        }

        // Método para contar las hojas (nodos sin hijos)
        public int ContarHojas()
        {
            operacionesRealizadas++;
            return ContarHojasRecursivo(raiz);
        }

        // Método recursivo para contar las hojas
        private int ContarHojasRecursivo(NodoPersonalizado nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            
            // Si el nodo es una hoja (no tiene hijos)
            if (nodo.Izquierdo == null && nodo.Derecho == null)
            {
                return 1;
            }
            
            // Contar recursivamente las hojas en los subárboles
            return ContarHojasRecursivo(nodo.Izquierdo) + ContarHojasRecursivo(nodo.Derecho);
        }

        // Método para calcular el factor de equilibrio (AVL)
        public int ObtenerFactorEquilibrio(NodoPersonalizado nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            
            return ObtenerAlturaRecursivo(nodo.Izquierdo) - ObtenerAlturaRecursivo(nodo.Derecho);
        }

        // Método para visualizar la estructura del árbol (representación mejorada)
        public void VisualizarArbol()
        {
            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }
            
            Console.WriteLine("Estructura del Árbol:");
            VisualizarArbolRecursivo(raiz, "", true);
            operacionesRealizadas++;
        }

        // Método recursivo para visualizar la estructura del árbol
        private void VisualizarArbolRecursivo(NodoPersonalizado nodo, string prefijo, bool esUltimo)
        {
            if (nodo == null)
            {
                return;
            }
            
            // Calcular el factor de equilibrio para cada nodo
            int factorEquilibrio = ObtenerFactorEquilibrio(nodo);
            
            Console.WriteLine($"{prefijo}{(esUltimo ? "└── " : "├── ")}{nodo.Valor} [FE:{factorEquilibrio}] '{nodo.Descripcion}'");
            
            // Preparar el prefijo para los hijos
            string nuevoPrefijoIzquierdo = prefijo + (esUltimo ? "    " : "│   ");
            
            // Procesar el hijo derecho primero para que aparezca abajo en la visualización
            VisualizarArbolRecursivo(nodo.Derecho, nuevoPrefijoIzquierdo, nodo.Izquierdo == null);
            VisualizarArbolRecursivo(nodo.Izquierdo, nuevoPrefijoIzquierdo, true);
        }

        // Método para verificar si el árbol está balanceado (estilo AVL)
        public bool EstaBalanceado()
        {
            operacionesRealizadas++;
            return VerificarBalanceRecursivo(raiz);
        }

        // Método recursivo para verificar balance
        private bool VerificarBalanceRecursivo(NodoPersonalizado nodo)
        {
            if (nodo == null)
            {
                return true;
            }
            
            // Obtener factor de equilibrio
            int factorEquilibrio = ObtenerFactorEquilibrio(nodo);
            
            // Verificar que el factor de equilibrio esté entre -1 y 1
            if (factorEquilibrio < -1 || factorEquilibrio > 1)
            {
                return false;
            }
            
            // Verificar recursivamente los subárboles
            return VerificarBalanceRecursivo(nodo.Izquierdo) && VerificarBalanceRecursivo(nodo.Derecho);
        }

        // Método para obtener el número de operaciones realizadas
        public int ObtenerOperacionesRealizadas()
        {
            return operacionesRealizadas;
        }

        // Método para obtener la fecha de creación del árbol
        public DateTime ObtenerFechaCreacion()
        {
            return fechaCreacion;
        }

        // Método para obtener los valores dentro de un rango
        public List<int> ObtenerValoresEnRango(int min, int max)
        {
            List<int> resultado = new List<int>();
            ObtenerValoresEnRangoRecursivo(raiz, min, max, resultado);
            operacionesRealizadas++;
            return resultado;
        }

        // Método recursivo para obtener valores en un rango
        private void ObtenerValoresEnRangoRecursivo(NodoPersonalizado nodo, int min, int max, List<int> resultado)
        {
            if (nodo == null)
            {
                return;
            }
            
            // Si el valor actual es mayor que min, explorar subárbol izquierdo
            if (min < nodo.Valor)
            {
                ObtenerValoresEnRangoRecursivo(nodo.Izquierdo, min, max, resultado);
            }
            
            // Si el valor está en el rango, añadirlo al resultado
            if (min <= nodo.Valor && nodo.Valor <= max)
            {
                resultado.Add(nodo.Valor);
            }
            
            // Si el valor actual es menor que max, explorar subárbol derecho
            if (nodo.Valor < max)
            {
                ObtenerValoresEnRangoRecursivo(nodo.Derecho, min, max, resultado);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioMejorado arbol = new ArbolBinarioMejorado();
            bool salir = false;

            Console.WriteLine("=== APLICACIÓN DE ÁRBOL BINARIO DE BÚSQUEDA MEJORADO ===");
            Console.WriteLine("Desarrollado por: [TU NOMBRE]"); // Reemplaza con tu nombre
            Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));

            while (!salir)
            {
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Insertar valor");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Eliminar valor");
                Console.WriteLine("4. Recorrer árbol");
                Console.WriteLine("5. Información del árbol");
                Console.WriteLine("6. Visualizar estructura del árbol");
                Console.WriteLine("7. Búsqueda por rango");
                Console.WriteLine("8. Verificar balance");
                Console.WriteLine("9. Estadísticas del árbol");
                Console.WriteLine("10. Salir");

                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el valor a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorInsertar))
                        {
                            Console.Write("Ingrese una descripción (opcional): ");
                            string descripcion = Console.ReadLine();
                            arbol.Insertar(valorInsertar, descripcion);
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido. Ingrese un número entero.");
                        }
                        break;

                    case "2":
                        Console.Write("Ingrese el valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorBuscar))
                        {
                            NodoPersonalizado nodoEncontrado = arbol.Buscar(valorBuscar);
                            if (nodoEncontrado != null)
                            {
                                Console.WriteLine($"El valor {valorBuscar} se encuentra en el árbol.");
                                Console.WriteLine($"Descripción: {nodoEncontrado.Descripcion}");
                                Console.WriteLine($"Fecha de creación: {nodoEncontrado.FechaCreacion}");
                            }
                            else
                            {
                                Console.WriteLine($"El valor {valorBuscar} NO se encuentra en el árbol.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido. Ingrese un número entero.");
                        }
                        break;

                    case "3":
                        Console.Write("Ingrese el valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorEliminar))
                        {
                            arbol.Eliminar(valorEliminar);
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido. Ingrese un número entero.");
                        }
                        break;

                    case "4":
                        MostrarSubmenuRecorridos(arbol);
                        break;

                    case "5":
                        MostrarInformacionArbol(arbol);
                        break;

                    case "6":
                        arbol.VisualizarArbol();
                        break;

                    case "7":
                        BusquedaPorRango(arbol);
                        break;

                    case "8":
                        VerificarBalance(arbol);
                        break;

                    case "9":
                        MostrarEstadisticas(arbol);
                        break;

                    case "10":
                        salir = true;
                        Console.WriteLine("¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void MostrarSubmenuRecorridos(ArbolBinarioMejorado arbol)
        {
            Console.WriteLine("\nSubmenu de Recorridos:");
            Console.WriteLine("1. Recorrido En Orden (In-Order)");
            Console.WriteLine("2. Recorrido Pre-Orden (Pre-Order)");
            Console.WriteLine("3. Recorrido Post-Orden (Post-Order)");
            Console.WriteLine("4. Recorrido Por Niveles (Level-Order)");
            Console.WriteLine("5. Volver al menú principal");

            Console.Write("\nSeleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    arbol.RecorridoEnOrden();
                    break;

                case "2":
                    arbol.RecorridoPreOrden();
                    break;

                case "3":
                    arbol.RecorridoPostOrden();
                    break;

                case "4":
                    arbol.RecorridoPorNiveles();
                    break;

                case "5":
                    // Volver al menú principal
                    break;

                default:
                    Console.WriteLine("Opción inválida. Volviendo al menú principal.");
                    break;
            }
        }

        static void MostrarInformacionArbol(ArbolBinarioMejorado arbol)
        {
            Console.WriteLine("\nInformación del Árbol:");
            Console.WriteLine($"Altura del árbol: {arbol.ObtenerAltura()}");
            Console.WriteLine($"Número total de nodos: {arbol.ContarNodos()}");
            Console.WriteLine($"Número de hojas: {arbol.ContarHojas()}");
            Console.WriteLine($"¿Árbol balanceado?: {(arbol.EstaBalanceado() ? "Sí" : "No")}");
        }

        static void BusquedaPorRango(ArbolBinarioMejorado arbol)
        {
            Console.Write("Ingrese el valor mínimo del rango: ");
            if (!int.TryParse(Console.ReadLine(), out int min))
            {
                Console.WriteLine("Valor inválido. Ingrese un número entero.");
                return;
            }

            Console.Write("Ingrese el valor máximo del rango: ");
            if (!int.TryParse(Console.ReadLine(), out int max))
            {
                Console.WriteLine("Valor inválido. Ingrese un número entero.");
                return;
            }

            if (min > max)
            {
                Console.WriteLine("El valor mínimo no puede ser mayor que el valor máximo.");
                return;
            }

            List<int> valoresEnRango = arbol.ObtenerValoresEnRango(min, max);
            
            if (valoresEnRango.Count == 0)
            {
                Console.WriteLine($"No se encontraron valores en el rango [{min}, {max}].");
            }
            else
            {
                Console.WriteLine($"Valores encontrados en el rango [{min}, {max}]:");
                foreach (int valor in valoresEnRango)
                {
                    Console.Write($"{valor} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Total de valores en el rango: {valoresEnRango.Count}");
            }
        }

        static void VerificarBalance(ArbolBinarioMejorado arbol)
        {
            bool balanceado = arbol.EstaBalanceado();
            Console.WriteLine($"El árbol {(balanceado ? "está balanceado" : "no está balanceado")}.");
            if (!balanceado)
            {
                Console.WriteLine("Un árbol está balanceado si para cada nodo, la diferencia de altura entre sus subárboles izquierdo y derecho no es mayor que 1.");
                Console.WriteLine("Sugerencia: Intente insertar nodos adicionales para equilibrar el árbol.");
            }
        }

        static void MostrarEstadisticas(ArbolBinarioMejorado arbol)
        {
            Console.WriteLine("\nEstadísticas del árbol:");
            Console.WriteLine($"Fecha de creación: {arbol.ObtenerFechaCreacion()}");
            Console.WriteLine($"Tiempo de vida: {(DateTime.Now - arbol.ObtenerFechaCreacion()).ToString(@"hh\:mm\:ss")}");
            Console.WriteLine($"Número de operaciones realizadas: {arbol.ObtenerOperacionesRealizadas()}");
            Console.WriteLine($"Densidad del árbol: {(double)arbol.ContarNodos() / arbol.ObtenerAltura():F2} nodos por nivel");
            
            double factorRamificacion = 0;
            int nodos = arbol.ContarNodos();
            int hojas = arbol.ContarHojas();
            
            if (nodos > 1) // Si hay más de un nodo
            {
                factorRamificacion = (double)(nodos - 1) / (nodos - hojas);
            }
            
            Console.WriteLine($"Factor de ramificación promedio: {factorRamificacion:F2}");
        }
    }
}
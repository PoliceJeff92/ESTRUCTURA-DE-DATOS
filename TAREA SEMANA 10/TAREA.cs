using System; // Biblioteca estándar de C# para operaciones básicas.
using System.Collections.Generic; // Para trabajar con colecciones como HashSet.
using System.IO; // Para manejar operaciones de archivos.
using iText.Kernel.Pdf; // Biblioteca iText7 para generar PDFs.
using iText.Layout; // Para estructurar el contenido del PDF.
using iText.Layout.Element; // Para elementos como párrafos en el PDF.

class Program
{
    static void Main(string[] args)
    {
        // Paso 1: Crear conjuntos ficticios
        // Generamos un conjunto de 500 ciudadanos ficticios.
        HashSet<string> ciudadanos = GenerarCiudadanos(500);

        // Generamos un conjunto de 75 ciudadanos vacunados con Pfizer.
        HashSet<string> vacunadosPfizer = GenerarVacunados(75, "Pfizer");

        // Generamos un conjunto de 75 ciudadanos vacunados con Astrazeneca.
        HashSet<string> vacunadosAstrazeneca = GenerarVacunados(75, "Astrazeneca");

        // Paso 2: Operaciones de conjuntos
        // Ciudadanos que han recibido ambas vacunas (intersección de Pfizer y Astrazeneca).
        HashSet<string> vacunadosConDosDosis = new HashSet<string>(vacunadosPfizer);
        vacunadosConDosDosis.IntersectWith(vacunadosAstrazeneca);

        // Ciudadanos que no se han vacunado (diferencia entre todos los ciudadanos y los vacunados).
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer); // Eliminamos los vacunados con Pfizer.
        noVacunados.ExceptWith(vacunadosAstrazeneca); // Eliminamos los vacunados con Astrazeneca.

        // Ciudadanos que solo han recibido la vacuna de Pfizer (diferencia entre Pfizer y Astrazeneca).
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstrazeneca);

        // Ciudadanos que solo han recibido la vacuna de Astrazeneca (diferencia entre Astrazeneca y Pfizer).
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca);
        soloAstrazeneca.ExceptWith(vacunadosPfizer);

        // Paso 3: Generar reporte en PDF
        // Llamamos al método para generar el reporte en PDF con los datos obtenidos.
        GenerarReportePDF(noVacunados, vacunadosConDosDosis, soloPfizer, soloAstrazeneca);

        // Mensaje de confirmación en la consola.
        Console.WriteLine("Reporte generado exitosamente.");
    }

    // Método para generar un conjunto de ciudadanos ficticios.
    static HashSet<string> GenerarCiudadanos(int cantidad)
    {
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= cantidad; i++)
        {
            // Agregamos nombres como "Ciudadano 1", "Ciudadano 2", ..., "Ciudadano N".
            ciudadanos.Add($"Ciudadano {i}");
        }
        return ciudadanos;
    }

    // Método para generar un conjunto de ciudadanos vacunados con una vacuna específica.
    static HashSet<string> GenerarVacunados(int cantidad, string tipoVacuna)
    {
        Random random = new Random();
        HashSet<string> vacunados = new HashSet<string>();

        // Generamos nombres únicos de ciudadanos vacunados hasta alcanzar la cantidad deseada.
        while (vacunados.Count < cantidad)
        {
            int numero = random.Next(1, 501); // Genera números aleatorios entre 1 y 500.
            vacunados.Add($"Ciudadano {numero}");
        }
        return vacunados;
    }

    // Método para generar un reporte en PDF con los datos obtenidos.
    static void GenerarReportePDF(HashSet<string> noVacunados, HashSet<string> vacunadosConDosDosis, HashSet<string> soloPfizer, HashSet<string> soloAstrazeneca)
    {
        string rutaArchivo = "ReporteVacunacion.pdf"; // Ruta del archivo PDF.

        // Usamos PdfWriter para escribir el archivo PDF.
        using (PdfWriter writer = new PdfWriter(rutaArchivo))
        {
            PdfDocument pdf = new PdfDocument(writer); // Creamos un documento PDF.
            Document document = new Document(pdf); // Creamos un documento editable.

            // Título del reporte.
            document.Add(new Paragraph("Reporte de Vacunación contra el COVID-19").SetBold().SetFontSize(16));

            // Sección de ciudadanos no vacunados.
            document.Add(new Paragraph("\nListado de ciudadanos que no se han vacunado:"));
            foreach (var ciudadano in noVacunados)
            {
                document.Add(new Paragraph($"- {ciudadano}")); // Añadimos cada ciudadano al PDF.
            }

            // Sección de ciudadanos con dos dosis.
            document.Add(new Paragraph("\nListado de ciudadanos que han recibido las dos vacunas:"));
            foreach (var ciudadano in vacunadosConDosDosis)
            {
                document.Add(new Paragraph($"- {ciudadano}"));
            }

            // Sección de ciudadanos con solo Pfizer.
            document.Add(new Paragraph("\nListado de ciudadanos que solamente han recibido la vacuna de Pfizer:"));
            foreach (var ciudadano in soloPfizer)
            {
                document.Add(new Paragraph($"- {ciudadano}"));
            }

            // Sección de ciudadanos con solo Astrazeneca.
            document.Add(new Paragraph("\nListado de ciudadanos que solamente han recibido la vacuna de Astrazeneca:"));
            foreach (var ciudadano in soloAstrazeneca)
            {
                document.Add(new Paragraph($"- {ciudadano}"));
            }

            document.Close(); // Cerramos el documento para guardar los cambios.
        }
    }
}
// JEFFREY JOSE MAYRGA ANGOS.
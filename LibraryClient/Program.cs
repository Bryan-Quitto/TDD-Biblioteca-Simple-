using LibraryCore;
using System;

var biblioteca = new Biblioteca();

bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE BIBLIOTECA (TDD) ===");
    Console.WriteLine("1. Registrar Libro");
    Console.WriteLine("2. Registrar Usuario");
    Console.WriteLine("3. Prestar Libro");
    Console.WriteLine("4. Devolver Libro");
    Console.WriteLine("5. Listar Libros Disponibles");
    Console.WriteLine("6. Listar Préstamos Activos");
    Console.WriteLine("7. Historial de Usuario (Opcional)");
    Console.WriteLine("8. Salir");
    Console.Write("\nSeleccione una opción: ");

    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            RegistrarLibroUI();
            break;
        case "2":
            RegistrarUsuarioUI();
            break;
        case "3":
            PrestarLibroUI();
            break;
        case "4":
            DevolverLibroUI();
            break;
        case "5":
            ListarDisponiblesUI();
            break;
        case "6":
            ListarPrestamosUI();
            break;
        case "7":
            HistorialUsuarioUI();
            break;
        case "8":
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida.");
            Pausar();
            break;
    }
}

void RegistrarLibroUI()
{
    Console.WriteLine("\n--- REGISTRAR LIBRO ---");
    Console.Write("Código: ");
    string codigo = Console.ReadLine() ?? "";
    Console.Write("Título: ");
    string titulo = Console.ReadLine() ?? "";
    Console.Write("Autor: ");
    string autor = Console.ReadLine() ?? "";
    Console.Write("Stock: ");
    if (int.TryParse(Console.ReadLine(), out int stock))
    {
        var libro = new Libro(codigo, titulo, autor, stock);
        if (biblioteca.RegistrarLibro(libro))
            Console.WriteLine("¡Libro registrado con éxito!");
        else
            Console.WriteLine("Error: Código duplicado o stock inválido.");
    }
    else
    {
        Console.WriteLine("Error: El stock debe ser un número.");
    }
    Pausar();
}

void RegistrarUsuarioUI()
{
    Console.WriteLine("\n--- REGISTRAR USUARIO ---");
    Console.Write("Código: ");
    string codigo = Console.ReadLine() ?? "";
    Console.Write("Nombre: ");
    string nombre = Console.ReadLine() ?? "";

    var usuario = new Usuario(codigo, nombre);
    if (biblioteca.RegistrarUsuario(usuario))
        Console.WriteLine("¡Usuario registrado con éxito!");
    else
        Console.WriteLine("Error: Código duplicado o nombre vacío.");
    Pausar();
}

void PrestarLibroUI()
{
    Console.WriteLine("\n--- PRESTAR LIBRO ---");
    Console.Write("Código del Libro: ");
    string codLibro = Console.ReadLine() ?? "";
    Console.Write("Código del Usuario: ");
    string codUsuario = Console.ReadLine() ?? "";

    if (biblioteca.PrestarLibro(codLibro, codUsuario))
        Console.WriteLine("¡Préstamo realizado exitosamente!");
    else
        Console.WriteLine("Error: Libro/Usuario no existen o sin stock.");
    Pausar();
}

void DevolverLibroUI()
{
    Console.WriteLine("\n--- DEVOLVER LIBRO ---");
    Console.Write("Código del Libro: ");
    string codLibro = Console.ReadLine() ?? "";
    Console.Write("Código del Usuario: ");
    string codUsuario = Console.ReadLine() ?? "";

    if (biblioteca.DevolverLibro(codLibro, codUsuario))
        Console.WriteLine("¡Libro devuelto exitosamente!");
    else
        Console.WriteLine("Error: No se encontró un préstamo activo con esos datos.");
    Pausar();
}

void ListarDisponiblesUI()
{
    Console.WriteLine("\n--- LIBROS DISPONIBLES ---");
    var libros = biblioteca.ObtenerLibrosDisponibles();
    foreach (var l in libros)
    {
        Console.WriteLine($"[{l.Codigo}] {l.Titulo} - Stock: {l.Stock}");
    }
    Pausar();
}

void ListarPrestamosUI()
{
    Console.WriteLine("\n--- PRÉSTAMOS ACTIVOS ---");
    var prestamos = biblioteca.ObtenerPrestamos();
    foreach (var p in prestamos)
    {
        Console.WriteLine($"Libro: {p.LibroPrestado.Titulo} | Usuario: {p.UsuarioSolicitante.Nombre} | Fecha: {p.FechaPrestamo}");
    }
    Pausar();
}

void HistorialUsuarioUI()
{
    Console.WriteLine("\n--- HISTORIAL DE USUARIO ---");
    Console.Write("Ingrese Código de Usuario: ");
    string codUsuario = Console.ReadLine() ?? "";
    
    var historial = biblioteca.ObtenerHistorialPorUsuario(codUsuario);
    
    if (historial.Count == 0)
    {
        Console.WriteLine("No hay historial para este usuario.");
    }
    else
    {
        foreach (var p in historial)
        {
            string estado = p.FechaDevolucion.HasValue ? $"Devuelto el {p.FechaDevolucion}" : "ACTIVO";
            Console.WriteLine($"Libro: {p.LibroPrestado.Titulo} | {estado}");
        }
    }
    Pausar();
}

void Pausar()
{
    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
    Console.ReadKey();
}
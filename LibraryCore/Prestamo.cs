using System;

namespace LibraryCore;

public class Prestamo
{
    public Libro LibroPrestado { get; set; }
    public Usuario UsuarioSolicitante { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion { get; set; } 

    public Prestamo(Libro libro, Usuario usuario, DateTime fecha)
    {
        LibroPrestado = libro;
        UsuarioSolicitante = usuario;
        FechaPrestamo = fecha;
    }
}
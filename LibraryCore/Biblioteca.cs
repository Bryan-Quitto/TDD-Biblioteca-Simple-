using System.Collections.Generic;
using System.Linq;

namespace LibraryCore;

public class Biblioteca
{
    private List<Libro> _libros = new List<Libro>();
    private List<Usuario> _usuarios = new List<Usuario>();
    private List<Prestamo> _prestamos = new List<Prestamo>();

    public bool RegistrarLibro(Libro libro)
    {
        if (!EsLibroValido(libro))
        {
            return false;
        }

        _libros.Add(libro);
        return true;
    }

    private bool EsLibroValido(Libro libro)
    {
        if (libro.Stock <= 0) return false;
        if (_libros.Any(l => l.Codigo == libro.Codigo)) return false;
        return true;
    }

    public List<Libro> ObtenerLibros()
    {
        return _libros;
    }

    public bool RegistrarUsuario(Usuario usuario)
    {
        if (!EsUsuarioValido(usuario))
        {
            return false;
        }

        _usuarios.Add(usuario);
        return true;
    }

    private bool EsUsuarioValido(Usuario usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nombre)) return false;
        if (_usuarios.Any(u => u.Codigo == usuario.Codigo)) return false;
        return true;
    }

    public List<Usuario> ObtenerUsuarios()
    {
        return _usuarios;
    }

    public bool PrestarLibro(string codigoLibro, string codigoUsuario)
    {
        var libro = _libros.FirstOrDefault(l => l.Codigo == codigoLibro);
        var usuario = _usuarios.FirstOrDefault(u => u.Codigo == codigoUsuario);

        if (!EsPrestamoValido(libro!, usuario!))
        {
            return false;
        }

        RealizarPrestamo(libro!, usuario!);
        return true;
    }

    private bool EsPrestamoValido(Libro libro, Usuario usuario)
    {
        if (libro == null || usuario == null) return false;
        if (libro.Stock <= 0) return false;
        return true;
    }

    private void RealizarPrestamo(Libro libro, Usuario usuario)
    {
        libro!.Stock--;
        _prestamos.Add(new Prestamo(libro, usuario, DateTime.Now));
    }

    public List<Prestamo> ObtenerPrestamos()
    {
        return _prestamos;
    }

    public bool DevolverLibro(string codigoLibro, string codigoUsuario)
    {
        var prestamo = BuscarPrestamoActivo(codigoLibro, codigoUsuario);

        if (prestamo == null)
        {
            return false;
        }

        FinalizarPrestamo(prestamo);
        return true;
    }

    private Prestamo? BuscarPrestamoActivo(string codigoLibro, string codigoUsuario)
    {
        return _prestamos.FirstOrDefault(p => 
            p.LibroPrestado.Codigo == codigoLibro && 
            p.UsuarioSolicitante.Codigo == codigoUsuario);
    }

    private void FinalizarPrestamo(Prestamo prestamo)
    {
        prestamo.LibroPrestado.Stock++;
        _prestamos.Remove(prestamo);
    }

}
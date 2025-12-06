using System.Collections.Generic;
using System.Linq;

namespace LibraryCore;

public class Biblioteca
{
    private List<Libro> _libros = new List<Libro>();
    private List<Usuario> _usuarios = new List<Usuario>();

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
}
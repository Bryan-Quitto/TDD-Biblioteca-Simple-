using System.Collections.Generic;
using System.Linq;

namespace LibraryCore;

public class Biblioteca
{
    private List<Libro> _libros = new List<Libro>();

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
}
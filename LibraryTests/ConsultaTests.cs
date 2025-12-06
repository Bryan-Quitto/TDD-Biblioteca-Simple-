using Xunit;
using LibraryCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTests;

public class ConsultaTests
{
    [Fact]
    public void ObtenerLibrosDisponibles_DebeRetornarSoloLibrosConStock()
    {
        // Arrange
        var biblioteca = new Biblioteca();
        biblioteca.RegistrarLibro(new Libro("L1", "Libro A", "A", 1));
        biblioteca.RegistrarLibro(new Libro("L2", "Libro B", "A", 0)); 
        biblioteca.RegistrarLibro(new Libro("L3", "Libro C", "A", 5));

        // Act
        List<Libro> disponibles = biblioteca.ObtenerLibrosDisponibles();

        // Assert
        Assert.Equal(2, disponibles.Count);
        Assert.DoesNotContain(disponibles, l => l.Codigo == "L2");
    }

    [Fact]
    public void ObtenerLibrosPrestados_DebeRetornarPrestamosActivos()
    {
        // Arrange
        var biblioteca = new Biblioteca();
        var libro = new Libro("L1", "Libro A", "A", 5);
        var usuario = new Usuario("U1", "Juan");
        
        biblioteca.RegistrarLibro(libro);
        biblioteca.RegistrarUsuario(usuario);
        biblioteca.PrestarLibro("L1", "U1");

        // Act
        var prestados = biblioteca.ObtenerPrestamos();

        // Assert
        Assert.Single(prestados);
        Assert.Equal("Juan", prestados[0].UsuarioSolicitante.Nombre);
    }
}
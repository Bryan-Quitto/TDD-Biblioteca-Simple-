using Xunit;
using LibraryCore;
using System.Linq;

namespace LibraryTests;

public class DevolucionTests
{
    [Fact]
    public void DevolverLibro_DebeAumentarStockYRemoverPrestamo()
    {
        // Arrange
        var biblioteca = new Biblioteca();
        var libro = new Libro("LIB001", "Libro Test", "Autor", 5);
        var usuario = new Usuario("USR001", "Usuario Test");

        biblioteca.RegistrarLibro(libro);
        biblioteca.RegistrarUsuario(usuario);
        
        biblioteca.PrestarLibro("LIB001", "USR001"); 

        // Act
        bool resultado = biblioteca.DevolverLibro("LIB001", "USR001");

        // Assert
        Assert.True(resultado);
        
        var libroGuardado = biblioteca.ObtenerLibros().First(l => l.Codigo == "LIB001");
        Assert.Equal(5, libroGuardado.Stock);

        Assert.Empty(biblioteca.ObtenerPrestamos());
    }

    [Fact]
    public void DevolverLibro_PrestamoNoExiste_DebeFallar()
    {
        var biblioteca = new Biblioteca();
        var libro = new Libro("LIB001", "Libro Test", "Autor", 5);
        var usuario = new Usuario("USR001", "Usuario Test");

        biblioteca.RegistrarLibro(libro);
        biblioteca.RegistrarUsuario(usuario);
        
        // Act
        bool resultado = biblioteca.DevolverLibro("LIB001", "USR001");

        // Assert
        Assert.False(resultado);
        Assert.Equal(5, libro.Stock);
    }
}
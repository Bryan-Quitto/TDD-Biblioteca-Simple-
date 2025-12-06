using Xunit;
using LibraryCore;
using System.Linq;

namespace LibraryTests;

public class PrestamoTests
{
    [Fact]
    public void PrestarLibro_DebeDisminuirStockYRegistrarPrestamo()
    {
        // Arrange
        var biblioteca = new Biblioteca();
        var libro = new Libro("LIB001", "Libro Test", "Autor", 5);
        var usuario = new Usuario("USR001", "Usuario Test");

        biblioteca.RegistrarLibro(libro);
        biblioteca.RegistrarUsuario(usuario);

        // Act
        bool resultado = biblioteca.PrestarLibro("LIB001", "USR001");

        // Assert
        Assert.True(resultado);
        
        var libroGuardado = biblioteca.ObtenerLibros().First(l => l.Codigo == "LIB001");
        Assert.Equal(4, libroGuardado.Stock);

        Assert.Single(biblioteca.ObtenerPrestamos());
    }
}
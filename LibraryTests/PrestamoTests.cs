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

    [Fact]
    public void PrestarLibro_LibroNoExiste_DebeFallar()
    {
        var biblioteca = new Biblioteca();
        biblioteca.RegistrarUsuario(new Usuario("USR001", "Juan"));
        
        bool resultado = biblioteca.PrestarLibro("LIB_FALSO", "USR001");
        Assert.False(resultado);
    }

    [Fact]
    public void PrestarLibro_UsuarioNoExiste_DebeFallar()
    {
        var biblioteca = new Biblioteca();
        biblioteca.RegistrarLibro(new Libro("LIB001", "Libro", "Autor", 5));

        bool resultado = biblioteca.PrestarLibro("LIB001", "USR_FALSO");
        Assert.False(resultado);
    }

    [Fact]
    public void PrestarLibro_SinStock_DebeFallar()
    {
        var biblioteca = new Biblioteca();
        var libro = new Libro("LIB001", "Libro Agotado", "Autor", 0); // Stock 0
        var usuario = new Usuario("USR001", "Juan");
        
        biblioteca.RegistrarLibro(libro);
        biblioteca.RegistrarUsuario(usuario);

        bool resultado = biblioteca.PrestarLibro("LIB001", "USR001");
        
        Assert.False(resultado);
        Assert.Equal(0, libro.Stock); // El stock debe mantenerse en 0, no bajar a -1
        Assert.Empty(biblioteca.ObtenerPrestamos());
    }

}
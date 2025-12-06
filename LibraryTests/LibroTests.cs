using Xunit;
using LibraryCore;
using System.Collections.Generic;

namespace LibraryTests;

public class LibroTests
{
    [Fact]
    public void RegistrarLibro_DebeGuardarLibroEnLaLista()
    {
        //Arrange
        var biblioteca = new Biblioteca();
        var libro = new Libro("LIB001", "Cien Años de Soledad", "Gabriel Garcia Marquez", 5);

        //Act
        bool resultado = biblioteca.RegistrarLibro(libro);

        //Assert
        Assert.True(resultado);
        
        List<Libro> librosGuardados = biblioteca.ObtenerLibros();
        Assert.Contains(libro, librosGuardados); 
    }

    [Fact]
    public void RegistrarLibro_ConCodigoDuplicado_NoDebeGuardar()
    {
        //Arrange
        var biblioteca = new Biblioteca();
        var libro1 = new Libro("LIB001", "Libro A", "Autor A", 3);
        var libro2 = new Libro("LIB001", "Libro B", "Autor B", 5);

        //Act
        biblioteca.RegistrarLibro(libro1);
        bool resultado = biblioteca.RegistrarLibro(libro2);

        //Assert
        Assert.False(resultado);
        Assert.Single(biblioteca.ObtenerLibros());
    }

    [Fact]
    public void RegistrarLibro_ConStockCeroONegativo_NoDebeGuardar()
    {
        //Arrange
        var biblioteca = new Biblioteca();
        var libroMalo = new Libro("LIB002", "Libro Malo", "Autor X", 0);

        //Act
        bool resultado = biblioteca.RegistrarLibro(libroMalo);

        //Assert
        Assert.False(resultado);
        Assert.Empty(biblioteca.ObtenerLibros());
    }
}
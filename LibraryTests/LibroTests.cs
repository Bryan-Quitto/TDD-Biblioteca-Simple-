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
}
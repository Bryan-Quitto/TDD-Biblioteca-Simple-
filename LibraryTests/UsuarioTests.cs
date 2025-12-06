using Xunit;
using LibraryCore;
using System.Collections.Generic;

namespace LibraryTests;

public class UsuarioTests
{
    [Fact]
    public void RegistrarUsuario_DebeGuardarUsuarioEnLaLista()
    {
        // Arrange
        var biblioteca = new Biblioteca();
        var usuario = new Usuario("USR001", "Juan Perez");

        // Act
        bool resultado = biblioteca.RegistrarUsuario(usuario);

        // Assert
        Assert.True(resultado);
        
        List<Usuario> usuariosGuardados = biblioteca.ObtenerUsuarios();
        Assert.Contains(usuario, usuariosGuardados);
    }

    [Fact]
    public void RegistrarUsuario_ConCodigoDuplicado_NoDebeGuardar()
    {
        // Arrange
        var biblioteca = new Biblioteca();
        var usuario1 = new Usuario("USR001", "Juan");
        var usuario2 = new Usuario("USR001", "Pedro"); // Mismo código

        // Act
        biblioteca.RegistrarUsuario(usuario1);
        bool resultado = biblioteca.RegistrarUsuario(usuario2);

        // Assert
        Assert.False(resultado);
        Assert.Single(biblioteca.ObtenerUsuarios());
    }

    [Fact]
    public void RegistrarUsuario_ConNombreVacio_NoDebeGuardar()
    {
        // Arrange
        var biblioteca = new Biblioteca();
        var usuarioSinNombre = new Usuario("USR002", ""); // Nombre vacío

        // Act
        bool resultado = biblioteca.RegistrarUsuario(usuarioSinNombre);

        // Assert
        Assert.False(resultado);
        Assert.Empty(biblioteca.ObtenerUsuarios());
    }
}
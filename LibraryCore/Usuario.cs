namespace LibraryCore;

public class Usuario
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public Usuario(string codigo, string nombre)
    {
        Codigo = codigo;
        Nombre = nombre;
    }
}
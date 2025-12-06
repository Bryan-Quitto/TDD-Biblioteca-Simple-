namespace LibraryCore;

public class Libro
{
    public string Codigo { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Stock { get; set; }

    public Libro(string codigo, string titulo, string autor, int stock)
    {
        Codigo = codigo;
        Titulo = titulo;
        Autor = autor;
        Stock = stock;
    }
}
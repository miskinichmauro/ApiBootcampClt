namespace ApiBootcampClt.Domain.Entities;

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = true;

    public ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
namespace APIhibridaASP.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string NombreMaterial {get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string unidadBase { get; set; } = string.Empty;
        public string? Categoria { get; set; }
    }
}

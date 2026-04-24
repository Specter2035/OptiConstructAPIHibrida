using System.ComponentModel.DataAnnotations;

namespace APIhibridaASP.Data
{
    public class Cliente
    {
        // Se cambio el nombre de la pk  porque Entity framework Core
        // no reconocia  "IdUsuario" como clave primaria ,lo hace cuando usualmente es Id como en el ej de la miss
        public int Id { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;

        public int UsuarioId { get; set; }

    }
}

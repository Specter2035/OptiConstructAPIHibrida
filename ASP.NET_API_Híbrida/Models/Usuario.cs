using System.ComponentModel.DataAnnotations;

namespace APIhibridaASP.Models
{
    public class Usuario
    {
        // Se cambio el nombre de la pk  porque Entity framework Core
        // no reconocia  "IdCliente" como clave primaria ,lo hace cuando usualmente es Id como en el ej de la miss
        public int Id { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public string NombreUsuario { get; set; } = string.Empty;

        public string Contrasenia { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string NumTelefono { get; set; } = string.Empty;

        public int Tipo { get; set; }
    }
}

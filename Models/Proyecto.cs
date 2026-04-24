using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIhibridaASP.Data
{
    public class Proyecto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int IdCliente { get; set; }

        public string NombrePr { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string DireccionTerreno { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; }

        public List<Plano> Plano { get; set; } = new List<Plano>(); //Se uso una lista porque el modelo en MongoDB puede contener  muchos planos registros dentro de un mismo documento,
                                                                    //y en el ej de la miss utiliza un  objeto ya que el pago solo tiene un detalle no varios 
    }

    public class Plano
    {
        public DateTime Fecha { get; set; }

        public string NombrePlano { get; set; } = string.Empty;

        public decimal Cotizacion { get; set; }
    }
}

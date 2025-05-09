using System.ComponentModel.DataAnnotations.Schema;

namespace Visitas.Dominio.Entidades
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string? Zona { get; set; }
        public string? Ciudad { get; set; }
    }

}

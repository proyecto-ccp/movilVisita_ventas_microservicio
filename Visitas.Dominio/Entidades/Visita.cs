
using System.ComponentModel.DataAnnotations.Schema;

namespace Visitas.Dominio.Entidades
{
    [Table("tbl_visita")]
    public class Visita: EntidadBase
    {
        [Column("idcliente")]
        public Guid IdCliente { get; set; }

        [NotMapped]
        public Cliente Cliente { get; set; } = new Cliente();

        [Column("idvendedor")]
        public Guid IdVendedor { get; set; }

        [Column("fecha_visita")]
        public DateTime FechaVisita { get; set; }

        [Column("motivo")]
        public string Motivo { get; set; }

        [Column("resultado")]
        public string? Resultado { get; set; }

        [Column("estado_visita")]
        public string Estado { get; set; }
    }
}

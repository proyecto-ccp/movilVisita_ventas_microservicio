using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Visitas.Dominio.Entidades
{
    public class EntidadBase
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}

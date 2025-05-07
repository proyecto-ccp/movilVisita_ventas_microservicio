using Microsoft.EntityFrameworkCore;
using Visitas.Dominio.Entidades;

namespace Visitas.Infraestructura.Repositorios
{
    public class VisitasDBContext : DbContext
    {
        public VisitasDBContext(DbContextOptions<VisitasDBContext> options) : base(options)
        {
        }
    
        public DbSet<Visita> Entidades { get; set; }
    }
}

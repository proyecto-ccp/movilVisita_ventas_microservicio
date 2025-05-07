using Visitas.Dominio.Entidades;

namespace Visitas.Dominio.Puertos.Repositorios
{
    public interface IVisitaRepositorio
    {
        Task CrearVisita(Visita visita);
        Task ActualizarVisita(Visita visita);
        Task<Visita> ObtenerVisitaPorId(int id);
        Task<List<Visita>> ObtenerVisitasPorVendedorId(Guid vendedorId);
        Task<List<Visita>> ObtenerVisitasPorClienteId(Guid clienteId);
        Task<List<Visita>> ObtenerVisitasPorFecha(DateTime fecha);
    }
}

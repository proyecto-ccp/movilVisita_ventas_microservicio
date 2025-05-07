
using Visitas.Aplicacion.Dto;

namespace Visitas.Aplicacion.Consultas
{
    public interface IConsultasVisitas
    {
        Task<VisitaOut> ObtenerVisitaPorId(int id);
        Task<VisitaOutList> ObtenerVisitasPorVendedorId(Guid vendedorId);
        Task<VisitaOutList> ObtenerVisitasPorFecha(DateTime fecha);
    }
}

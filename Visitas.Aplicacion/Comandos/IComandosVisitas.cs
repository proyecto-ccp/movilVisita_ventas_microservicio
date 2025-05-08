using Visitas.Aplicacion.Dto;

namespace Visitas.Aplicacion.Comandos
{
    public interface IComandosVisitas
    {
        Task<BaseOut> CrearVisita(VisitaIn visita);
        Task<BaseOut> ModificarVisita(VisitaModificarIn visita,int id);
    }
}

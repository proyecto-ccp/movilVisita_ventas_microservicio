
using Visitas.Dominio.Entidades;
using Visitas.Dominio.Puertos.Repositorios;
using Visitas.Infraestructura.RepositoriosGenericos;

namespace Visitas.Infraestructura.Repositorios
{
    public class VisitaRepositorio : IVisitaRepositorio
    {
        private readonly IRepositorioBase<Visita> _repositorioBase;

        public VisitaRepositorio(IRepositorioBase<Visita> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public async Task CrearVisita(Visita visita)
        {
            await _repositorioBase.Crear(visita);
        }

        public async Task ActualizarVisita(Visita visita)
        {
            await _repositorioBase.Actualizar(visita);
        }

        public async Task<Visita> ObtenerVisitaPorId(int id)
        {
            return await _repositorioBase.ObtenerPorId(id);
        }

        public async Task<List<Visita>> ObtenerVisitasPorFecha(DateTime fecha)
        {
            return await _repositorioBase.ObtenerPorFecha(fecha);
        }

        public async Task<List<Visita>> ObtenerVisitasPorClienteId(Guid id)
        {
            return await _repositorioBase.ObtenerPorGuid(id, "IdCliente");
        }

        public async Task<List<Visita>> ObtenerVisitasPorVendedorId(Guid id)
        {
            return await _repositorioBase.ObtenerPorGuid(id, "IdVendedor");
        }

        public async Task<List<Visita>> ObtenerVisitas()
        {
            return await _repositorioBase.ObtenerTodos();
        }
    }
}

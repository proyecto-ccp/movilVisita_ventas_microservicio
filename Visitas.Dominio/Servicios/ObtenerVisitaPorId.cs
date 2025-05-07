using Visitas.Dominio.Entidades;
using Visitas.Dominio.Puertos.Repositorios;

namespace Visitas.Dominio.Servicios
{
    public class ObtenerVisitaPorId(IVisitaRepositorio visitaRepositorio)
    {
        private readonly IVisitaRepositorio _visitaRepositorio = visitaRepositorio;
        public async Task<Visita> Ejecutar(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID de la visita debe ser mayor que cero.");
            }

            var visita = await _visitaRepositorio.ObtenerVisitaPorId(id);

            if (visita == null)
            {
                throw new KeyNotFoundException($"No se encontró una visita con el ID {id}.");
            }

            return visita;
        }
    }
}

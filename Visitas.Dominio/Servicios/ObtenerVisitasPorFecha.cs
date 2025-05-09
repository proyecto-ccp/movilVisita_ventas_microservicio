using Visitas.Dominio.Entidades;
using Visitas.Dominio.Puertos.Repositorios;

namespace Visitas.Dominio.Servicios
{
    public class ObtenerVisitasPorFecha(IVisitaRepositorio visitaRepositorio)
    {
        private readonly IVisitaRepositorio _visitaRepositorio = visitaRepositorio;

        public async Task<List<Visita>> Ejecutar(DateTime fecha, Guid vendedorId)
        {
            if (fecha == default)
            {
                throw new ArgumentException("La fecha no puede ser nula o inválida.");
            }

            var visitas = await _visitaRepositorio.ObtenerVisitasPorFecha(fecha, vendedorId);
            
            // Verifica si la fecha es antigua
            if (fecha < DateTime.Now)
            {
                throw new ArgumentException("La fecha no puede ser antigua.");
            }

            // Verifica si la lista de visitas está vacía o nula
            if (visitas == null || !visitas.Any())
            {
                throw new KeyNotFoundException($"No se encontraron visitas para la fecha {fecha.ToShortDateString()}.");
            }
            return visitas;
        }
    }
}

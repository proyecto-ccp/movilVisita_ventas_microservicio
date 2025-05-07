using Visitas.Dominio.Entidades;
using Visitas.Dominio.Puertos.Repositorios;

namespace Visitas.Dominio.Servicios
{
    public class ObtenerVisitasPorVendedorId(IVisitaRepositorio visitaRepositorio)
    {
        private readonly IVisitaRepositorio _visitaRepositorio = visitaRepositorio;

        public async Task<List<Visita>> Ejecutar(Guid vendedorId)
        {
            if (vendedorId == Guid.Empty)
            {
                throw new ArgumentException("El ID del vendedor no es un GUID válido.");
            }

            var visitas = await _visitaRepositorio.ObtenerVisitasPorVendedorId(vendedorId);

            // Verifica si la lista de visitas está vacía o nula
            if (visitas == null || !visitas.Any())
            {
                throw new KeyNotFoundException($"No se encontraron visitas para el vendedor con ID {vendedorId}.");
            }

            return visitas;
        }
    }
}

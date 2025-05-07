using Visitas.Dominio.Entidades;
using Visitas.Dominio.Puertos.Repositorios;

namespace Visitas.Dominio.Servicios
{
    public class CrearVisita(IVisitaRepositorio visitaRepositorio)
    {
        private readonly IVisitaRepositorio _visitaRepositorio = visitaRepositorio;

        public async Task<bool> Ejecutar(Visita visita)
        {
            if (ValidarVisita(visita))
            {
                visita.Estado = "CREADO";
                await _visitaRepositorio.CrearVisita(visita);
            }

            return true;
        }

        private bool ValidarVisita(Visita visita)
        {
            if (visita == null ||
                visita.IdCliente == Guid.Empty ||
                visita.IdVendedor == Guid.Empty ||
                visita.FechaVisita == default || // Validates that the date is not the default value
                string.IsNullOrEmpty(visita.Motivo))
            {
                throw new InvalidOperationException("Valores incorrectos para los parametros minimos.");
            }

            return true;
        }
    }
}

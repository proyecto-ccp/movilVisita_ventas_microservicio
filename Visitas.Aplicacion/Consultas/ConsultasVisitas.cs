using AutoMapper;
using System.Net;
using Visitas.Aplicacion.Dto;
using Visitas.Aplicacion.Enum;
using Visitas.Dominio.Servicios;

namespace Visitas.Aplicacion.Consultas
{
    public class ConsultasVisitas : IConsultasVisitas
    {
        private readonly ObtenerVisitaPorId _obtenerVisitaPorId;
        private readonly ObtenerVisitasPorVendedorId _obtenerVisitasPorVendedorId;
        private readonly ObtenerVisitasPorFecha _obtenerVisitasPorFecha;
        private readonly IMapper _mapper;

        public ConsultasVisitas(ObtenerVisitaPorId obtenerVisitaPorId, ObtenerVisitasPorVendedorId obtenerVisitasPorVendedorId, ObtenerVisitasPorFecha obtenerVisitasPorFecha, IMapper mapper)
        {
            _obtenerVisitaPorId = obtenerVisitaPorId;
            _obtenerVisitasPorVendedorId = obtenerVisitasPorVendedorId;
            _obtenerVisitasPorFecha = obtenerVisitasPorFecha;
            _mapper = mapper;
        }

        public async Task<VisitaOut> ObtenerVisitaPorId(int id)
        {
            VisitaOut VisitaOut = new();
            try
            {
                var Visita = await _obtenerVisitaPorId.Ejecutar(id);

                if (Visita == null || Visita.Id < 0)
                {
                    VisitaOut.Resultado = Resultado.SinRegistros;
                    VisitaOut.Mensaje = "Visita NO encontrada";
                    VisitaOut.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    VisitaOut.Resultado = Resultado.Exitoso;
                    VisitaOut.Mensaje = "Visita encontrada";
                    VisitaOut.Status = HttpStatusCode.OK;
                    VisitaOut.Visita = _mapper.Map<VisitaDto>(Visita);
                }
            }
            catch (Exception ex)
            {
                VisitaOut.Resultado = Resultado.Error;
                VisitaOut.Mensaje = ex.Message;
                VisitaOut.Status = HttpStatusCode.InternalServerError;
            }

            return VisitaOut;
        }

        public async Task<VisitaOutList> ObtenerVisitasPorVendedorId(Guid vendedorId)
        {
            VisitaOutList VisitaOutList = new()
            {
                Visitas = []
            };

            try
            {
                var Visitas = await _obtenerVisitasPorVendedorId.Ejecutar(vendedorId);

                if (Visitas == null || !Visitas.Any())
                {
                    VisitaOutList.Resultado = Resultado.SinRegistros;
                    VisitaOutList.Mensaje = "No se encontraron visitas";
                    VisitaOutList.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    VisitaOutList.Resultado = Resultado.Exitoso;
                    VisitaOutList.Mensaje = "Visitas encontradas";
                    VisitaOutList.Status = HttpStatusCode.OK;
                    VisitaOutList.Visitas = _mapper.Map<List<VisitaDto>>(Visitas);
                }
            }
            catch (Exception ex)
            {
                VisitaOutList.Resultado = Resultado.Error;
                VisitaOutList.Mensaje = ex.Message;
                VisitaOutList.Status = HttpStatusCode.InternalServerError;
            }
            return VisitaOutList;
        }

    public async Task<VisitaOutList> ObtenerVisitasPorFecha(DateTime fecha)
        {
            VisitaOutList VisitaOutList = new()
            {
                Visitas = []
            };

            try
            {
                var Visitas = await _obtenerVisitasPorFecha.Ejecutar(fecha);
                if (Visitas == null || !Visitas.Any())
                {
                    VisitaOutList.Resultado = Resultado.SinRegistros;
                    VisitaOutList.Mensaje = "No se encontraron visitas";
                    VisitaOutList.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    VisitaOutList.Resultado = Resultado.Exitoso;
                    VisitaOutList.Mensaje = "Visitas encontradas";
                    VisitaOutList.Status = HttpStatusCode.OK;
                    VisitaOutList.Visitas = _mapper.Map<List<VisitaDto>>(Visitas);
                }
            }
            catch (Exception ex)
            {
                VisitaOutList.Resultado = Resultado.Error;
                VisitaOutList.Mensaje = ex.Message;
                VisitaOutList.Status = HttpStatusCode.InternalServerError;
            }
            return VisitaOutList;
        }
    }
}

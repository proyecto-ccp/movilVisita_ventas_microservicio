using AutoMapper;
using System.Net;
using Visitas.Aplicacion.Dto;
using Visitas.Aplicacion.Enum;
using Visitas.Dominio.Entidades;
using Visitas.Dominio.Servicios;

namespace Visitas.Aplicacion.Comandos
{
    public class ComandosVisitas: IComandosVisitas
    {
        private readonly CrearVisita _crearVisita;
        private readonly ActualizarVisita  _modificarVisita;
        private readonly IMapper _mapper;

        public ComandosVisitas(CrearVisita crearVisita, ActualizarVisita modificarVisita, IMapper mapper)
        {
            _crearVisita = crearVisita;
            _modificarVisita = modificarVisita;
            _mapper = mapper;
        }

        public async Task<BaseOut> CrearVisita(VisitaIn visita)
        {
            BaseOut baseOut = new();

            try
            {
                var visitaDominio = _mapper.Map<Visita>(visita);
                await _crearVisita.Ejecutar(visitaDominio);
                baseOut.Mensaje = "Visita creada exitosamente";
                baseOut.Id = visitaDominio.Id;
                baseOut.Resultado = Resultado.Exitoso;
                baseOut.Status = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                baseOut.Resultado = Resultado.Error;
                baseOut.Mensaje = ex.Message;
                baseOut.Status = HttpStatusCode.InternalServerError;
            }

            return baseOut;
        }

        public async Task<BaseOut> ModificarVisita(VisitaModificarIn visita, int id)
        {
            BaseOut baseOut = new();
            try
            {
                var visitaDominio = _mapper.Map<Visita>(visita);
                visitaDominio.Id = id;
                await _modificarVisita.Ejecutar(visitaDominio);
                baseOut.Mensaje = "Visita modificada exitosamente";
                baseOut.Id = visitaDominio.Id;
                baseOut.Resultado = Resultado.Exitoso;
                baseOut.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                baseOut.Resultado = Resultado.Error;
                baseOut.Mensaje = ex.Message;
                baseOut.Status = HttpStatusCode.InternalServerError;
            }
            return baseOut;
        }

    }
}

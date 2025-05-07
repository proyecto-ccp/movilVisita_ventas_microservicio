using Microsoft.AspNetCore.Mvc;
using Visitas.Aplicacion.Comandos;
using Visitas.Aplicacion.Consultas;
using Visitas.Aplicacion.Dto;

namespace ServicioVisita.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class VisitaController : ControllerBase
    {
        private readonly IComandosVisitas _comandosVisitas;
        private readonly IConsultasVisitas _consultasVisitas;

        public VisitaController(IComandosVisitas comandosVisitas, IConsultasVisitas consultasVisitas)
        {
            _comandosVisitas = comandosVisitas;
            _consultasVisitas = consultasVisitas;
        }

        [HttpPost]
        [Route("CrearVisita")]
        [ProducesResponseType(typeof(VisitaOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> CrearVisita([FromBody] VisitaIn crearVisitaIn)
        {
            try
            {
                var resultado = await _comandosVisitas.CrearVisita(crearVisitaIn);

                if (resultado.Resultado != Visitas.Aplicacion.Enum.Resultado.Error)
                    return Ok(resultado);
                else
                    return Problem(resultado.Mensaje, statusCode: (int)resultado.Status, title: resultado.Resultado.ToString(), type: resultado.Resultado.ToString(), instance: HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("ModificarVisita")]
        [ProducesResponseType(typeof(VisitaOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ModificarVisita([FromBody] VisitaIn modificarVisitaIn)
        {
            try
            {
                var resultado = await _comandosVisitas.ModificarVisita(modificarVisitaIn);
                if (resultado.Resultado != Visitas.Aplicacion.Enum.Resultado.Error)
                    return Ok(resultado);
                else
                    return Problem(resultado.Mensaje, statusCode: (int)resultado.Status, title: resultado.Resultado.ToString(), type: resultado.Resultado.ToString(), instance: HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerVisita/{id}")]
        [ProducesResponseType(typeof(VisitaOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerVisitaPorId(int id)
        {
            try
            {
                var resultado = await _consultasVisitas.ObtenerVisitaPorId(id);
                if (resultado.Resultado != Visitas.Aplicacion.Enum.Resultado.Error)
                    return Ok(resultado);
                else
                    return Problem(resultado.Mensaje, statusCode: (int)resultado.Status, title: resultado.Resultado.ToString(), type: resultado.Resultado.ToString(), instance: HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerVisitasPorVendedorId/{vendedorId}")]
        [ProducesResponseType(typeof(VisitaOutList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerVisitasPorVendedorId(Guid vendedorId)
        {
            try
            {
                var resultado = await _consultasVisitas.ObtenerVisitasPorVendedorId(vendedorId);
                if (resultado.Resultado != Visitas.Aplicacion.Enum.Resultado.Error)
                    return Ok(resultado);
                else
                    return Problem(resultado.Mensaje, statusCode: (int)resultado.Status, title: resultado.Resultado.ToString(), type: resultado.Resultado.ToString(), instance: HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerVisitasPorFecha/{fecha}")]
        [ProducesResponseType(typeof(VisitaOutList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerVisitasPorFecha(DateTime fecha)
        {
            try
            {
                var resultado = await _consultasVisitas.ObtenerVisitasPorFecha(fecha);
                if (resultado.Resultado != Visitas.Aplicacion.Enum.Resultado.Error)
                    return Ok(resultado);
                else
                    return Problem(resultado.Mensaje, statusCode: (int)resultado.Status, title: resultado.Resultado.ToString(), type: resultado.Resultado.ToString(), instance: HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using Visitas.Aplicacion.Enum;
using System.Net;

namespace Visitas.Aplicacion.Dto
{
    public class BaseOut
    {
        public Resultado Resultado { get; set; }
        public string Mensaje { get; set; }
        public int? Id { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}

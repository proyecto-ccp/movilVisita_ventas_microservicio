namespace Visitas.Aplicacion.Dto
{
    public class VisitaIn
    {
        public Guid IdCliente { get; set; }
        public Guid IdVendedor { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Motivo { get; set; }
        public string Resultado { get; set; }
        public string Estado { get; set; }
        
    }
}

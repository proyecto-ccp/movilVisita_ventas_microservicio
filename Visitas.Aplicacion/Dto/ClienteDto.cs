namespace Visitas.Aplicacion.Dto
{
    public class ClienteDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Zona { get; set; }
        public string Ciudad { get; set; }
    }

    public class ClienteReponseDto 
    {
        public ClienteDto Cliente { get; set; }
        public int Resultado { get; set; }
        public string Mensaje { get; set; }
        public int Status { get; set; }
    }
}

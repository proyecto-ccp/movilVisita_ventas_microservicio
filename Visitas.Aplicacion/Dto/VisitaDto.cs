﻿using Visitas.Dominio.Entidades;

namespace Visitas.Aplicacion.Dto
{
    public class VisitaDto
    {
        public int Id { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdVendedor { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Motivo { get; set; }
        public string? Resultado { get; set; }
        public string Estado { get; set; }
    }

    public class VisitaOut : BaseOut
    {
        public VisitaDto Visita { get; set; }
    }

    public class VisitaOutList : BaseOut
    {
        public List<VisitaDto> Visitas { get; set; }
    }
}

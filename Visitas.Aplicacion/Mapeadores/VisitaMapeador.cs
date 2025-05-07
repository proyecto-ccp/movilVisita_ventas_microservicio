using AutoMapper;
using Visitas.Aplicacion.Dto;
using Visitas.Dominio.Entidades;

namespace Visitas.Aplicacion.Mapeadores
{
    public class VisitaMapeador: Profile
    {
        public VisitaMapeador() {
            CreateMap<Visita, VisitaDto>()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.IdVendedor, opt => opt.MapFrom(src => src.IdVendedor))
                .ForMember(dest => dest.FechaVisita, opt => opt.MapFrom(src => src.FechaVisita))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.Motivo))
                .ForMember(dest => dest.Resultado, opt => opt.MapFrom(src => src.Resultado))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ReverseMap();

            CreateMap<Visita,VisitaIn>()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.IdVendedor, opt => opt.MapFrom(src => src.IdVendedor))
                .ForMember(dest => dest.FechaVisita, opt => opt.MapFrom(src => src.FechaVisita))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.Motivo))
                .ForMember(dest => dest.Resultado, opt => opt.MapFrom(src => src.Resultado))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ReverseMap();

            CreateMap<VisitaOut,VisitaIn>()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.Visita.IdCliente))
                .ForMember(dest => dest.IdVendedor, opt => opt.MapFrom(src => src.Visita.IdVendedor))
                .ForMember(dest => dest.FechaVisita, opt => opt.MapFrom(src => src.Visita.FechaVisita))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.Visita.Motivo))
                .ForMember(dest => dest.Resultado, opt => opt.MapFrom(src => src.Visita.Resultado))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Visita.Estado))
                .ReverseMap();
        }
    }
}

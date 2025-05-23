﻿using AutoMapper;
using Visitas.Aplicacion.Dto;
using Visitas.Dominio.Entidades;

namespace Visitas.Aplicacion.Mapeadores
{
    public class VisitaMapeador: Profile
    {
        public VisitaMapeador() {
            CreateMap<Visita, VisitaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.IdVendedor, opt => opt.MapFrom(src => src.IdVendedor))
                .ForMember(dest => dest.FechaVisita, opt => opt.MapFrom(src => src.FechaVisita))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.Motivo))
                .ForMember(dest => dest.Resultado, opt => opt.MapFrom(src => src.Resultado))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForPath(dest => dest.Cliente.Nombre, opt => opt.MapFrom(src => src.Cliente.Nombre))
                .ForPath(dest => dest.Cliente.Apellido, opt => opt.MapFrom(src => src.Cliente.Apellido))
                .ForPath(dest => dest.Cliente.TipoDocumento, opt => opt.MapFrom(src => src.Cliente.TipoDocumento))
                .ForPath(dest => dest.Cliente.Documento, opt => opt.MapFrom(src => src.Cliente.Documento))
                .ForPath(dest => dest.Cliente.Email, opt => opt.MapFrom(src => src.Cliente.Email))
                .ForPath(dest => dest.Cliente.Telefono, opt => opt.MapFrom(src => src.Cliente.Telefono))
                .ForPath(dest => dest.Cliente.Direccion, opt => opt.MapFrom(src => src.Cliente.Direccion))
                .ForPath(dest => dest.Cliente.Ciudad, opt => opt.MapFrom(src => src.Cliente.Ciudad))
                .ForPath(dest => dest.Cliente.Zona, opt => opt.MapFrom(src => src.Cliente.Zona))
                .ReverseMap();

            CreateMap<Visita,VisitaIn>()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.IdVendedor, opt => opt.MapFrom(src => src.IdVendedor))
                .ForMember(dest => dest.FechaVisita, opt => opt.MapFrom(src => src.FechaVisita))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.Motivo))
                .ReverseMap();

            CreateMap<VisitaOut,VisitaIn>()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.Visita.IdCliente))
                .ForMember(dest => dest.IdVendedor, opt => opt.MapFrom(src => src.Visita.IdVendedor))
                .ForMember(dest => dest.FechaVisita, opt => opt.MapFrom(src => src.Visita.FechaVisita))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.Visita.Motivo))
                .ReverseMap();

            //Modificar
            CreateMap<Visita, VisitaModificarIn>()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.IdVendedor, opt => opt.MapFrom(src => src.IdVendedor))
                .ForMember(dest => dest.FechaVisita, opt => opt.MapFrom(src => src.FechaVisita))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.Motivo))
                .ForMember(dest => dest.Resultado, opt => opt.MapFrom(src => src.Resultado))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ReverseMap();

            CreateMap<VisitaOut, VisitaModificarIn>()
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

using AutoMapper;
using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;

namespace MosarticoApi.Application.Mapping
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.EnderecosDTOs, opt => opt.MapFrom(src => src.Enderecos))
                .ForMember(dest => dest.TelefonesDTOs, opt => opt.MapFrom(src => src.Telefones))
                .ForMember(dest => dest.ArtesDTOs, opt => opt.MapFrom(src => src.Artes))
                .ForMember(dest => dest.PerfilId, opt => opt.MapFrom(src => src.PerfilId))
                .ForMember(dest => dest.OficinaDTOs, opt => opt.MapFrom(src => src.UsuarioOficinas.Select(p => p.Oficinas).ToList()))
                .AfterMap((src, dest) => dest.Senha = string.Empty);

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.EnderecosDTOs))
                .ForMember(dest => dest.Telefones, opt => opt.MapFrom(src => src.TelefonesDTOs))
                .ForMember(dest => dest.Artes, opt => opt.MapFrom(src => src.ArtesDTOs))
                .ForMember(dest => dest.PerfilId, opt => opt.MapFrom(src => src.PerfilId))
                .AfterMap((src, dest) => dest.Senha = Utilidades.GerarHashMd5(src.Senha));

            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
            CreateMap<Perfil, PerfilDTO>().ReverseMap();

            CreateMap<Arte, ArteDTO>()
                .ForMember(dest => dest.ImagemArteDTOs, opt => opt.MapFrom(src => src.ImagemArte))
                .ForMember(dest => dest.TipoArteId, opt => opt.MapFrom(src => src.TipoArteId)).ReverseMap();

            CreateMap<ImagemArteDTO, ImagemArte>().ReverseMap();
            CreateMap<ImagemOficinaDTO, ImagemOficina>().ReverseMap();
            CreateMap<ImagemOngDTO, ImagemOng>().ReverseMap();

            CreateMap<Oficinas, OficinasDTO>()
                .ForMember(dest => dest.ImagensOficinaDTOs, opt => opt.MapFrom(src => src.ImagensOficina))
                .ForMember(dest => dest.UsuarioDTOs, opt => opt.MapFrom(src => src.UsuarioOficinas.Select(p => p.Usuario))).ReverseMap();

            CreateMap<Ong, OngDTO>()
                .ForMember(dest => dest.ImagensOngDTOs, opt => opt.MapFrom(src => src.ImagensOng))
                .ForMember(dest => dest.OficinaDTOs, opt => opt.MapFrom(src => src.Oficinas)).ReverseMap();
        }
    }
}

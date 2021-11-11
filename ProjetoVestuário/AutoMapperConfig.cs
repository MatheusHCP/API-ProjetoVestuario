using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjetoVestuário.Model;
using Entidades;

namespace ProjetoVestuário
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()

        {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Produto, produtoModel>();
                cfg.CreateMap<produtoModel, Produto>();
               
                cfg.CreateMap<Imagens, imagensModel>();
                cfg.CreateMap<imagensModel, Imagens>();
                
                cfg.CreateMap<produtoCategoria, produtoCategoriaModel>();
                cfg.CreateMap<produtoCategoriaModel, produtoCategoria>();
                
                cfg.CreateMap<produtoGenero, produtoGeneroModel>();
                cfg.CreateMap<produtoGeneroModel, produtoGenero>();
                
                cfg.CreateMap<produtoMarca, produtoMarcaModel>();
                cfg.CreateMap<produtoMarcaModel, produtoMarca>();

                cfg.CreateMap<produtoStatus, produtoStatusModel>();
                cfg.CreateMap<produtoStatusModel, produtoStatus>();

                cfg.CreateMap<produtoTamanho, produtoTamanhoModel>();
                cfg.CreateMap<produtoTamanhoModel, produtoTamanho>();

                cfg.CreateMap<usuarioEndereco, usuarioEnderecoModel>();
                cfg.CreateMap<usuarioEnderecoModel, usuarioEndereco>();

                cfg.CreateMap<Usuario, usuarioModel>();
                cfg.CreateMap<usuarioModel, Usuario>();

                cfg.CreateMap<usuarioTipo, usuarioTipoModel>();
                cfg.CreateMap<usuarioTipoModel, usuarioTipo>();


            });
            return config;

        }
    }
}

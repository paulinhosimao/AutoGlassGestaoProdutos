using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TesteAutoGlass.Dtos;
using TesteAutoGlass.Models;

namespace TesteAutoGlass.Mappings
{
    public class PerfilProduto : Profile
    {
        public PerfilProduto()
        {
            CreateMap<Produtos, ProdutoDto>()
                .ForMember(dest => dest.DescricaoFornecedor, opt => opt.MapFrom(src => src.fornecedores.Descricao))
                .ForMember(dest => dest.CNPJFornecedor, opt => opt.MapFrom(src => src.fornecedores.CNPJ))
                .ReverseMap();
        }

    }
}

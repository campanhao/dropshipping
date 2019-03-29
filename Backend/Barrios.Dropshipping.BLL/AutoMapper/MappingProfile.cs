using AutoMapper;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ProdutoDto, ProdutoDto>();
            CreateMap<ProdutoDto,ProdutoDto>();
            CreateMap<UsuarioEndereco, UsuarioEnderecoDto>();
            CreateMap<FormaPagamento, FormaPagamentoDto>();
            CreateMap<Pedido, PedidoDto>();
            CreateMap<PedidoEntrega, PedidoEntregaDto>();
            CreateMap<PedidoItem, PedidoItemDto>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<PedidoItemFornecedor, PedidoItemFornecedorDto>();
        }
    }
}
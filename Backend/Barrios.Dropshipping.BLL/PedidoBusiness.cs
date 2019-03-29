using AutoMapper;
using DAL;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class PedidoBusiness : Repository<Pedido>, IPedidoBusiness
    {
        #region Atributos
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoEntregaRepository _pedidoEntregaRepository;
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IProdutoBusiness _produtoBusiness;
        private readonly IPedidoItemBusiness _pedidoItemBusiness;
        private readonly IPedidoItemFornecedorBusiness _pedidoItemFornecedorBusiness;
        private readonly IFormaPagamentoBusiness _formaPagamentoBusiness;
        private readonly IUsuarioEnderecoBusiness _usuarioEnderecoBusiness;
        private readonly IStatusBusiness _statusBusiness;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public PedidoBusiness(IPedidoRepository pedidoRepository, Context context, IMapper mapper,
            IPedidoItemBusiness pedidoItemBusiness, IPedidoItemFornecedorBusiness pedidoItemFornecedorBusiness,
            IUsuarioBusiness usuarioBusiness, IProdutoBusiness produtoBusiness, IFormaPagamentoBusiness formaPagamentoBusiness,
            IUsuarioEnderecoBusiness usuarioEnderecoBusiness, IPedidoEntregaRepository pedidoEntregaRepository, IStatusBusiness statusBusiness)
            : base(context)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _pedidoItemBusiness = pedidoItemBusiness;
            _pedidoItemFornecedorBusiness = pedidoItemFornecedorBusiness;
            _usuarioBusiness = usuarioBusiness;
            _produtoBusiness = produtoBusiness;
            _formaPagamentoBusiness = formaPagamentoBusiness;
            _usuarioEnderecoBusiness = usuarioEnderecoBusiness;
            _pedidoEntregaRepository = pedidoEntregaRepository;
            _statusBusiness = statusBusiness;
        }

        public async Task<IEnumerable<PedidoDto>> GetAsync(int usuarioId)
        {

            if (await Task.Run(() => !_usuarioBusiness.Exists(x => x.UsuarioId == usuarioId)))
                throw new ArgumentException("Usuário não encontrado");

            var pedidos = await _pedidoRepository.GetListAsync(usuarioId);
            var pedidosDto = _mapper.Map<IEnumerable<PedidoDto>>(pedidos);

            foreach (var pedido in pedidosDto)
            {
                foreach (var item in pedido.PedidoItens)
                {
                    item.NomeProduto = _produtoBusiness.Get(item.ProdutoId).Nome;
                    item.PedidoItemFornecedor.StatusNome = _statusBusiness.Get(item.PedidoItemFornecedor.StatusId).Nome;            
                }
            }
            return await Task.Run(() => pedidosDto);
        }


        public Task GetAsync()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Métodos Públicos

        public async Task PostAsync(PedidoRequestDto dto, int usuarioId)
        {
            if (await Task.Run(() => !_usuarioBusiness.Exists(x => x.UsuarioId == usuarioId)))
                throw new ArgumentException("Usuário não encontrado");

            if (await Task.Run(() => !_formaPagamentoBusiness.Exists(x => x.FormaPagamentoId == dto.FormaPagamentoId)))
                throw new ArgumentException("Forma de Pagamento não encontrada");

            if (await Task.Run(() => !_usuarioEnderecoBusiness.Exists(x => x.UsuarioEnderecoId == dto.UsuarioEnderecoId)))
                throw new ArgumentException("Endereço de entrega não encontrado");

            foreach (var produto in dto.Itens)
            {
                var model = _produtoBusiness.Get(x => x.ProdutoId == produto.ProdutoId);
                if (model == null)
                    throw new ArgumentException("Produto não encontrado");
                else
                {
                    if (model.Ativo == false || model.EmEstoque == false)
                        throw new ArgumentException("Produto {0} indisponível", model.Nome);
                }
            }

            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    var obj = new Pedido()
                    {
                        UsuarioId = usuarioId,
                        ValorTotal = dto.ValorTotal,
                        FormaPagamentoId = dto.FormaPagamentoId,
                        Data = DateTime.Now
                    };

                    _pedidoRepository.Add(obj);

                    var endereco = _usuarioEnderecoBusiness.Get(dto.UsuarioEnderecoId);

                    _pedidoEntregaRepository.Add(new PedidoEntrega()
                    {
                        PedidoId = obj.PedidoId,
                        Logradouro = endereco.Logradouro,
                        Numero = endereco.Numero,
                        Complemento = endereco.Complemento,
                        Cidade = endereco.Cidade,
                        Bairro = endereco.Bairro,
                        Estado = endereco.Estado,
                        CEP = endereco.CEP
                    });

                    foreach (var produto in dto.Itens)
                    {
                        var model = _produtoBusiness.Get(produto.ProdutoId);

                        var item = new PedidoItem()
                        {
                            PedidoId = obj.PedidoId,
                            ProdutoId = produto.ProdutoId,
                            Quantidade = produto.Quantidade,
                            PrecoUnitario = produto.PrecoUnitario,
                            ValorTotal = produto.Quantidade * produto.PrecoUnitario
                        };
                        _pedidoItemBusiness.Add(item);

                        var itemFornecedor = new PedidoItemFornecedor()
                        {
                            PedidoItemId = item.PedidoItemId,
                            CodPedidoItemFornec = GerarPedidoFornecedor(model.FornecedorId, obj.PedidoId),
                            FornecedorId = model.FornecedorId,
                            UltimaAtualizacao = DateTime.Now,
                            StatusId = 1
                        };
                        _pedidoItemFornecedorBusiness.Add(itemFornecedor);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        private string GerarPedidoFornecedor(int fornecedorId, int pedidoId)
        {
            return string.Concat("PED-", pedidoId.ToString().PadLeft(10, '0'), "-F", fornecedorId.ToString().PadLeft(3, '0'));
        }
        #endregion

    }

}


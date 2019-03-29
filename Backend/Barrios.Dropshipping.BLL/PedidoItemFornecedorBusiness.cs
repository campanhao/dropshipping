using AutoMapper;
using DAL;
using DAL.Interfaces;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PedidoItemFornecedorBusiness : Repository<PedidoItemFornecedor>, IPedidoItemFornecedorBusiness
    {
        #region Atributos
        private readonly IPedidoItemFornecedorRepository _pedidoItemFornecedorRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public PedidoItemFornecedorBusiness(IPedidoItemFornecedorRepository pedidoItemFornecedorRepository, IFornecedorRepository fornecedorRepository, IStatusRepository statusRepository, Context context, IMapper mapper)
            : base(context)
        {
            _pedidoItemFornecedorRepository = pedidoItemFornecedorRepository;
            _fornecedorRepository = fornecedorRepository;
            _statusRepository = statusRepository;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public async Task<PedidoItemFornecedor> AtualizarItemAsync(PedidoItemStatusDto item, int id)
        {
            if (await Task.Run(() => !_fornecedorRepository.Exists(x => x.FornecedorId == id)))
                throw new ArgumentException("Fornecedor não encontrado");

            if (await Task.Run(() => !_pedidoItemFornecedorRepository.Exists(x => x.CodPedidoItemFornec == item.CodPedidoFornec && x.FornecedorId == id)))
                throw new ArgumentException("Item do pedido não encontrado");

            if (await Task.Run(() => !_statusRepository.Exists(x => x.StatusId == item.Status)))
                throw new ArgumentException("Status não encontrado");

            var pedidoItem = await _pedidoItemFornecedorRepository.GetAsync(id, item.CodPedidoFornec);

            pedidoItem.StatusId = item.Status;
            pedidoItem.Observacao = item.Observacao;
            _pedidoItemFornecedorRepository.Update(pedidoItem);
            pedidoItem = await _pedidoItemFornecedorRepository.GetAsync(id, item.CodPedidoFornec);
            return await Task.Run(() => pedidoItem);
        }
        #endregion
    }
}

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
    public class PedidoItemBusiness : Repository<PedidoItem>, IPedidoItemBusiness
    {
        #region Atributos
        private readonly IPedidoItemRepository _vendaItemRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public PedidoItemBusiness(IPedidoItemRepository vendaItemRepository, Context context, IMapper mapper)
            : base(context)
        {
            _vendaItemRepository = vendaItemRepository;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        #endregion
    }
}

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
    public class FormaPagamentoBusiness : Repository<FormaPagamento>, IFormaPagamentoBusiness
    {
        #region Atributos
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public FormaPagamentoBusiness(IFormaPagamentoRepository formaPagamentoRepository, Context context, IMapper mapper)
            :base(context)
        {
            _formaPagamentoRepository = formaPagamentoRepository;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public async Task<IEnumerable<FormaPagamentoDto>> GetListAsync()
        {
            var lst = await Task.Run(() => _formaPagamentoRepository.GetList());
            return _mapper.Map<IEnumerable<FormaPagamentoDto>>(lst);
        }
        #endregion
    }
}

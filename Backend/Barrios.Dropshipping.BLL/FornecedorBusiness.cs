using AutoMapper;
using DAL;
using DAL.Interfaces;
using Model;
using Model.Dto;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FornecedorBusiness : Repository<Fornecedor>, IFornecedorBusiness
    {
        #region Atributos
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public FornecedorBusiness(IFornecedorRepository fornecedorRepository, Context context, IMapper mapper)
            :base(context)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public async Task<Fornecedor> Get(FornecedorRequestDto requisicaoLogin)
        {
            var pin = Convert.ToBase64String((Encoding.UTF8.GetBytes(requisicaoLogin.Senha)));
            var fornecedor = await Task.Run(() => _fornecedorRepository.Get(x => x.Usuario == requisicaoLogin.Usuario && x.Senha == pin));
            return fornecedor;
        }
        #endregion
    }
}

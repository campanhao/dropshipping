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
    public class ProdutoBusiness : Repository<Produto>, IProdutoBusiness
    {
        #region Atributos
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public ProdutoBusiness(IProdutoRepository produtoRepository, Context context, IMapper mapper)
            : base(context)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public async Task<IEnumerable<ProdutoDto>> GetListAsync()
        {
            var produto = await _produtoRepository.GetListAsync();
            return _mapper.Map<IEnumerable<ProdutoDto>>(produto);
        }
        public async Task<IEnumerable<ProdutoDto>> GetListAsync(string nome)
        {
            var produto = await _produtoRepository.GetListAsync(nome);
            return _mapper.Map<IEnumerable<ProdutoDto>>(produto);
        }
        public async Task<IEnumerable<ProdutoDto>> GetListAsync(int categoriaId)
        {
            var produto = await _produtoRepository.GetListAsync(categoriaId);
            return _mapper.Map<IEnumerable<ProdutoDto>>(produto);
        }
        #endregion
    }
}

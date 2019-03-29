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
    public class CategoriaBusiness : Repository<Categoria>, ICategoriaBusiness
    {
        #region Atributos
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public CategoriaBusiness(ICategoriaRepository categoriaRepository, Context context, IMapper mapper)
            : base(context)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public async Task<IEnumerable<CategoriaDto>> GetListAsync()
        {
            var produto = await _categoriaRepository.GetListAsync();
            return _mapper.Map<IEnumerable<CategoriaDto>>(produto);
        }
        #endregion
    }
}

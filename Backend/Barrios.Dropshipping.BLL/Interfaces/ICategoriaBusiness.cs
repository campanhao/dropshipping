using DAL;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICategoriaBusiness : IRepository<Categoria>
    {
        Task<IEnumerable<CategoriaDto>> GetListAsync();
    }
}
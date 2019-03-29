using DAL;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProdutoBusiness : IRepository<Produto>
    {
        Task<IEnumerable<ProdutoDto>> GetListAsync();
        Task<IEnumerable<ProdutoDto>> GetListAsync(string nome);
        Task<IEnumerable<ProdutoDto>> GetListAsync(int categoriaId);
    }
}
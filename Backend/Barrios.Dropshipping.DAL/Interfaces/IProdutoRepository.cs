using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetListAsync();
        Task<IEnumerable<Produto>> GetListAsync(string nome);
        Task<IEnumerable<Produto>> GetListAsync(int categoriaId);
    }
}

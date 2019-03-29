using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Context contexto) : base(contexto)
        {
        }

        public async Task<IEnumerable<Produto>> GetListAsync()
        {
            return await DbContext.Set<Produto>().Include(x => x.PedidoItens).Where(x => x.EmEstoque == true && x.Ativo == true)
                .OrderBy(o => o.Nome)
                .ToListAsync();
        }
        public async Task<IEnumerable<Produto>> GetListAsync(string nome)
        {
            return await DbContext.Set<Produto>().Where(x => x.EmEstoque == true && x.Ativo == true &&
                         x.Nome.ToUpperInvariant().Contains(nome.ToUpperInvariant()))
                        .OrderBy(o => o.Nome)
                        .ToListAsync();
        }
        public async Task<IEnumerable<Produto>> GetListAsync(int categoriaId)
        {
            return await DbContext.Set<Produto>().Where(x => x.EmEstoque == true && x.Ativo == true &&
                         x.CategoriaId == categoriaId)
                        .OrderBy(o => o.Nome)
                        .ToListAsync();
        }
    }

}
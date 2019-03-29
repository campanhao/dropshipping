using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(Context contexto) : base(contexto)
        {
        }
        public async Task<IEnumerable<Pedido>> GetListAsync(int usuarioId)
        {
            return await DbContext.Set<Pedido>()
                .Include(x => x.Usuario)
                .Include(x => x.PedidoItens).ThenInclude(x => x.PedidoItemFornecedor)
                .Include(x => x.PedidoEntrega)
                .Where(x => x.UsuarioId == usuarioId)
                .OrderBy(o => o.Data)
                .ToListAsync();
        }
    }

}
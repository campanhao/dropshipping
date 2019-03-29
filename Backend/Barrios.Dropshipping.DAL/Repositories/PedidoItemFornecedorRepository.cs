using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class PedidoItemFornecedorRepository : Repository<PedidoItemFornecedor>, IPedidoItemFornecedorRepository
    {
        public PedidoItemFornecedorRepository(Context contexto) : base(contexto)
        {
        }
        public async Task<PedidoItemFornecedor> GetAsync(int fornecedorId, string codPedidoFornec)
        {
            return await DbContext.Set<PedidoItemFornecedor>().Include(x => x.Status).Where(x => x.FornecedorId == fornecedorId && x.CodPedidoItemFornec == codPedidoFornec)
                .FirstOrDefaultAsync();
        }
    }

}
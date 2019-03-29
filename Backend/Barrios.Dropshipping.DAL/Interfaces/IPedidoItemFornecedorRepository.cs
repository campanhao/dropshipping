using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPedidoItemFornecedorRepository : IRepository<PedidoItemFornecedor>
    {
        Task<PedidoItemFornecedor> GetAsync(int fornecedorId, string codPedidoFornec);
    }
}

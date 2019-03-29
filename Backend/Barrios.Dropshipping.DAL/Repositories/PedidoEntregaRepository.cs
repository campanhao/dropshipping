using DAL.Interfaces;
using Model;

namespace DAL
{
    public class PedidoEntregaRepository : Repository<PedidoEntrega>, IPedidoEntregaRepository
    {
        public PedidoEntregaRepository(Context contexto) : base(contexto)
        {
        }
    }

}
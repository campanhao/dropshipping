using DAL.Interfaces;
using Model;

namespace DAL
{
    public class FormaPagamentoRepository : Repository<FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(Context contexto) : base(contexto)
        {
        }
    }

}
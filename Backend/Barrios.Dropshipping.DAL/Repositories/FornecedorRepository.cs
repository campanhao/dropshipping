using DAL.Interfaces;
using Model;

namespace DAL
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(Context contexto) : base(contexto)
        {
        }
    }

}
using DAL.Interfaces;
using Model;

namespace DAL
{
    public class UsuarioEnderecoRepository : Repository<UsuarioEndereco>, IUsuarioEnderecoRepository
    {
        public UsuarioEnderecoRepository(Context contexto) : base(contexto)
        {
        }
    }

}
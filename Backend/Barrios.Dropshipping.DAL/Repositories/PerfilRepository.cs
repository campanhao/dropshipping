using DAL.Interfaces;
using Model;

namespace DAL
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(Context contexto) : base(contexto)
        {
        }
    }

}
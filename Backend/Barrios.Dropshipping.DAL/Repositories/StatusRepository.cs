using DAL.Interfaces;
using Model;

namespace DAL
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(Context contexto) : base(contexto)
        {
        }
    }

}
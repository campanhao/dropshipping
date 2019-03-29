using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context contexto) : base(contexto)
        {
        }
        public async Task<Usuario> GetAsync(int usuarioId)
        {
            return await DbContext.Set<Usuario>().Include(x => x.UsuarioEnderecos).Where(x => x.UsuarioId == usuarioId)
                .FirstOrDefaultAsync();
        }
    }

}
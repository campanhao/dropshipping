using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(Context contexto) : base(contexto)
        {
        }
        public async Task<IEnumerable<Categoria>> GetListAsync()
        {
            return await DbContext.Set<Categoria>()
                .ToListAsync();
        }
    }

}
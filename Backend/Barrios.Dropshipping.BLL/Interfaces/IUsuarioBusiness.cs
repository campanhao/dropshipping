using DAL;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUsuarioBusiness : IRepository<Usuario>
    {
        Task<Usuario> Get(UsuarioRequestDto requisicaoLogin);
        Task<IEnumerable<UsuarioEnderecoDto>> GetListAsync(int usuarioId);
    }
}
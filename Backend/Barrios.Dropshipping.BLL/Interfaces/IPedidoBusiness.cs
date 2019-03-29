using DAL;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPedidoBusiness : IRepository<Pedido>
    {
        Task PostAsync(PedidoRequestDto dto, int usuarioId);
        Task<IEnumerable<PedidoDto>> GetAsync(int usuarioId);
    }
}
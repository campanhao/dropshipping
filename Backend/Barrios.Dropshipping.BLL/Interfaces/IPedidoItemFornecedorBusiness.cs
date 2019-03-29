using DAL;
using Model;
using Model.Dto;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPedidoItemFornecedorBusiness : IRepository<PedidoItemFornecedor>
    {
        Task<PedidoItemFornecedor> AtualizarItemAsync(PedidoItemStatusDto item, int statusId);
    }
}
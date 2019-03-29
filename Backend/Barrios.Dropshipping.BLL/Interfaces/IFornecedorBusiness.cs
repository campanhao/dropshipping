using DAL;
using Model;
using Model.Dto;
using System.Threading.Tasks;

namespace BLL
{
    public interface IFornecedorBusiness : IRepository<Fornecedor>
    {
        Task<Fornecedor> Get(FornecedorRequestDto requisicaoLogin);
    }
}
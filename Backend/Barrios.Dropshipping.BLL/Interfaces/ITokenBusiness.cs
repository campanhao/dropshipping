using Model;
using System.Threading.Tasks;

namespace BLL
{
    public interface ITokenBusiness
    { 
        Task<string> LoginUsuario(Usuario cliente, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations);
        Task<string> LoginFornecedor(Fornecedor fornecedor, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations);
    }
}